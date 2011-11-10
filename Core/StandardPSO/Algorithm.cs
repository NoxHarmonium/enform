using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ENFORM.Core;

/*
Standard PSO 2007
 Contact for remarks, suggestions etc.:
 Maurice.Clerc@WriteMe.com
 
 Last update
 2010-08-13 PORT to C#
 2010-06-15 Fixed a small bug in position initialisation for discrete problems (thanks to Yue,Shuai)
 2010-03-24 Lennard-Jones problem
 2010-02-06 A few functions of the CEC 2005 benchmark
 2010-01-04 Fixed wrong fitness evaluation for G3 (function code 10)
 2009-12-29 Random number generator KISS (option). For more reproducible results
 2009-07-12 The initialisation space may be smaller than the search space (for tests)
 2009-06-03 Fixed a small mistake about the first best position
 2009-05-05 Step function
 2009-04-19 Schaffer f6, 2D Goldstein-Price
 2009-03-31 A small network optimisation 
 2009-03-12 Schwefel 2.2, Neumaier 3, G3 (constrained)
 2008-10-02 Two Schwefel functions
 2008-08-12 For information: save the best position over all runs
 2007-12-10 Warning about rotational invariance (valid here only on 2D)
 2007-11-22 stop criterion (option): distance to solution < epsilon
            and log_progress evaluation
 2007-11-21 Ackley function
 
  -------------------------------- Contributors 
 The works and comments of the following persons have been taken
 into account while designing this standard.  Sometimes this is for 
 including a feature, and sometimes for leaving out one. 
 
 Auger, Anne
 Blackwell, Tim
 Bratton, Dan
 Clerc, Maurice
 Croussette, Sylvain 
 Dattasharma, Abhi
 Eberhart, Russel
 Hansen, Nikolaus
 Keko, Hrvoje
 Kennedy, James 
 Krohling, Renato
 Langdon, William
 Li, Wentao
 Liu, Hongbo 
 Miranda, Vladimiro
 Poli, Riccardo
 Serra, Pablo
 Stickel, Manfred
 
 -------------------------------- Motivation
Quite often, researchers claim to compare their version of PSO 
with the "standard one", but the "standard one" itself seems to vary!
Thus, it is important to define a real standard that would stay 
unchanged for at least one year.
This PSO version does not intend to be the best one on the market
(in particular, there is no adaptation of the swarm size nor of the
coefficients). This is simply very near to the original version (1995),
with just a few improvements based on some recent works.
 --------------------------------- Metaphors
swarm: A team of communicating people (particles)
At each time step
    Each particle chooses a few informants at random, selects the best
    one from this set, and takes into account the information given by
    the chosen particle.
    If it finds no particle better than itself, then the "reasoning" is:
    "I am the best, so I just take my current velocity and my previous
    best position into account" 
----------------------------------- Parameters/Options
clamping := true/false => whether to use clamping positions or not
randOrder:= true/false => whether to avoid the bias due to the loop
                on particles "for s = 1 to swarm_size ..." or not
rotation := true/false => whether the algorithm is sensitive 
                to a rotation of the landscape or not 
You may also modify the following ones, although suggested values
are either hard coded or automatically computed:
S := swarm size
K := maximum number of particles _informed_ by a given one
w := first cognitive/confidence coefficient
c := second cognitive/confidence coefficient
 ----------------------------------- Equations
For each particle and each dimension
Equation 1:	v(t+1) = w*v(t) + R(c)*(p(t)-x(t)) + R(c)*(g(t)-x(t))
Equation 2:	x(t+1) = x(t) + v(t+1)
where
v(t) := velocity at time t
x(t) := position at time t
p(t) := best previous position of the particle
g(t) := best position amongst the best previous positions
        of the informants of the particle
R(c) := a number coming from a random distribution, which depends on c
In this standard, the distribution is uniform on [0,c]
Note 1:
When the particle has no informant better than itself,
it implies p(t) = g(t)
Therefore, Equation 1 gets modified to:
v(t+1) = w*v(t) + R(c)*(p(t)-x(t))
Note 2:
When the "non sensitivity to rotation" option is activated
(p(t)-x(t)) (and (g(t)-x(t))) are replaced by rotated vectors, 
so that the final DNPP (Distribution of the Next Possible Positions)
is not dependent on the system of co-ordinates.
 ----------------------------------- Information links topology 
A lot of work has been done about this topic. The main result is this: 
There is no "best" topology. Hence the random approach used here.  
 ----------------------------------- Initialisation
Initial positions are chosen at random inside the search space 
(which is supposed to be a hyperparallelepiped, and often even
a hypercube), according to a uniform distribution.
This is not the best way, but the one used in the original PSO.
Each initial velocity is simply defined as the half-difference of two
random positions. It is simple, and needs no additional parameter.
However, again, it is not the best approach. The resulting distribution
is not even uniform, as is the case for any method that uses a
uniform distribution independently for each component.
The mathematically correct approach needs to use a uniform
distribution inside a hypersphere. It is not very difficult,
and was indeed used in some PSO versions.  However, it is quite
different from the original one. 
Moreover, it may be meaningless for some heterogeneous problems,
when each dimension has a different "interpretation".
------------------------------------ From SPSO-06 to SPSO-07
The main differences are:
1. option "non sensitivity to rotation of the landscape"
    Note: although theoretically interesting, this option is quite
        computer time consuming, and the improvement in result may
        only be marginal. 
2. option "random permutation of the particles before each iteration"
    Note: same remark. Time consuming, no clear improvement
3. option "clamping position or not"
    Note: in a few rare cases, not clamping positions may induce an
    infinite run, if the stop criterion is the maximum number of 
    evaluations
        
4. probability p of a particular particle being an informant of another
    particle. In SPSO-06 it was implicit (by building the random infonetwork)
    Here, the default value is directly computed as a function of (S,K),
    so that the infonetwork is exactly the same as in SPSO-06.
    However, now it can be "manipulated" ( i.e. any value can be assigned)
    
5. The search space can be quantised (however this algorithm is _not_
   for combinatorial problems)
Also, the code is far more modular. It means it is slower, but easier
to translate into another language, and easier to modify.
 ----------------------------------- Use
 Define the problem (you may add your own one in problemDef() and perf())
 Choose your options
 Run and enjoy!
   
 */
namespace SPSO_2007
{
    public class Algorithm
    {

        //const int D_max = 114;		// Max number of dimensions of the search space
        const int R_max = 500;	// Max number of runs
        const int S_max = 910;	// Max swarm size
        NPack.MersenneTwister rand = new NPack.MersenneTwister(); //System Random Number Generator

        // Global variables
        static double sqrtD;

        // File(s);
       // static FileStream f_run;
        //static FileStream f_synth;

        private int d;
        private int g;
        private int[] index = new int[S_max];
        private int[] indexTemp = new int[S_max];
        // Iteration number (time step)
        //int iterBegin;
        private int[,] LINKS = new int[S_max, S_max];	// Information links
        private int m;
        //int noEval;
        private double normPX = 0.0, normGX = 0.0;
       // private int noStop;
        private int outside;
        private double p;
        private Velocity PX;
        private Result R;

        public Result PSOResult
        {
            get { return R; }
            set { R = value; }
        }
        private Matrix RotatePX = new Matrix();
        private Matrix RotateGX = new Matrix();
        private int s0, s, s1;
        private double zz;
        private Velocity aleaV = new Velocity();
        private double error;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }
        private double errorPrev;
        private int initLinks;
        private int iter;
        private int nFailure = 0;		// Number of unsuccessful runs
        private int run = 0;

        private Position bestBest; // Best position over all runs
        // Current dimension
        private double errorMean = 0;// Average error
        private double errorMin = double.MaxValue;		// Best result over all runs
        private double[] errorMeanBest = new double[R_max];
        private double evalMean = 0;		// Mean number of evaluations

        private double logProgressMean = 0.0;

        private Problem pb;
        private Parameters param;
        private Result result;

        private int runMax;

        public Result Result
        {
            get { return result; }
            set { result = value; }
        }

        public double[] BestResult
        {
            get
            {
                return PSOResult.SW.P[PSOResult.SW.best].x;
            }

        }

        public double BestFitness
        {
            get
            {
                return PSOResult.SW.P[PSOResult.SW.best].f;
            }
        }

        

        // =================================================
        public Algorithm(Problem pb, Parameters param)
        {
            this.pb = pb;
            bestBest = new Position(pb.SS.D);
            PX = new Velocity(pb.SS.D);
            R = new SPSO_2007.Result(pb.SS.D);

            //f_run = File.OpenWrite("f_run.txt");
            //f_synth = File.OpenWrite("f_synth.txt");

            // ----------------------------------------------- PROBLEM


            this.param = param;
            runMax = 100;
            if (runMax > R_max) runMax = R_max;


           

            Utils.Logger.Log("\n c = {0},  w = {1}", param.c, param.w);
            //---------------
            sqrtD = Math.Sqrt(pb.SS.D);

            //------------------------------------- RUNS	
            /*
            for (run = 0; run < runMax; run++)
            {
               
            }		// End loop on "run"
            */
            // ---------------------END 


            // Save	
            //TODO: Fix up writing out to files
            /*fUtils.Logger.Log(f_synth, "%f %f %.0f%% %f   ",
                     errorMean, variance, successRate, evalMean);
            for (d = 0; d < pb.SS.D; d++) fUtils.Logger.Log(f_synth, " %f", bestBest.x[d]);
            fUtils.Logger.Log(f_synth, "\n");
             * */

            return; // End of main program
        }

        public void StartRun()
        {
            //srand (clock () / 100);	// May improve pseudo-randomness   
            InitPSO();
            Result = PSOResult;


        }

        public void EndRun()
        {
            if (Result.error > pb.epsilon) // Failure
            {
                nFailure = nFailure + 1;
            }

            // Memorize the best (useful if more than one run)
            if (Result.error < bestBest.f)
                bestBest = Result.SW.P[Result.SW.best].Clone();

            pb.perf(bestBest, pb.function, pb.objective);

            // Result display
            Utils.Logger.Log("\nRun {0}. Eval {1}. Error {2} \n", run, Result.nEval, Result.error);
            //for (d=0;d<pb.SS.D;d++) Utils.Logger.Log(" %f",result.SW.P[result.SW.best].x[d]);

            // Save result
            //TODO: Fix up writing out to files
            /*fUtils.Logger.Log(f_run, "\n%i %.0f %e ", run + 1, result.nEval, error);
                for (d = 0; d < pb.SS.D; d++) fUtils.Logger.Log(f_run, " %f", result.SW.P[result.SW.best].x[d]);
             */
            // Compute/store some statistical information
            if (run == 0)
                errorMin = Result.error;
            else if (Result.error < errorMin)
                errorMin = Result.error;
            evalMean = evalMean + Result.nEval;
            errorMean = errorMean + Result.error;
            errorMeanBest[run] = Result.error;
            logProgressMean = logProgressMean - Math.Log(Result.error);
            run++;

        }

        public void Finish()
        {


            // Display some statistical information
            evalMean /= runMax;
            errorMean /= runMax;
            logProgressMean /= runMax;

            Utils.Logger.Log("\n Eval. (mean)= {0}", evalMean);
            Utils.Logger.Log("\n Error (mean) = {0}", errorMean);
            // Variance
            double variance = 0;
            for (run = 0; run < runMax; run++)
            {
                variance += Math.Pow(errorMeanBest[run] - errorMean, 2);
            }
            variance = Math.Sqrt(variance / runMax);
            Utils.Logger.Log("\n Std. dev. {0}", variance);
            Utils.Logger.Log("\n Log_progress (mean) = {0}", logProgressMean);
            // Success rate and minimum value
            Utils.Logger.Log("\n Failure(s) {0}", nFailure);
            Utils.Logger.Log("\n Success rate = {0}%", 100 * (1 - nFailure / (double)runMax));

            Utils.Logger.Log("\n Best min value = {0}", errorMin);
            Utils.Logger.Log("\nPosition of the optimum: ");
            for (int d = 0; d < pb.SS.D; d++)
            { Utils.Logger.Log(" {0}", bestBest.x[d]); }
        }

        // ===============================================================
        // PSO
        private void InitPSO()
        {



            aleaV.size = pb.SS.D;
            RotatePX.size = pb.SS.D;
            RotateGX.size = pb.SS.D;
            // -----------------------------------------------------
            // INITIALISATION
            p = param.p; // Probability threshold for random topology
            PSOResult.SW.S = param.S; // Size of the current swarm

            // Position and velocity
            for (s = 0; s < PSOResult.SW.S; s++)
            {
                PSOResult.SW.X[s].size = pb.SS.D;
                PSOResult.SW.V[s].size = pb.SS.D;

                for (d = 0; d < pb.SS.D; d++)
                {
                    PSOResult.SW.X[s].x[d] = rand.NextDouble(pb.SS.minInit[d], pb.SS.maxInit[d]);
                    PSOResult.SW.V[s].v[d] = (rand.NextDouble(pb.SS.min[d], pb.SS.max[d]) - PSOResult.SW.X[s].x[d]) / 2;
                }
                // Take quantisation into account
                //Position.quantis(PSOResult.SW.X[s], pb.SS);

                // First evaluations
                PSOResult.SW.X[s].f =
                    pb.perf(PSOResult.SW.X[s], pb.function, pb.objective);

                PSOResult.SW.P[s] = PSOResult.SW.X[s].Clone();	// Best position = current one
                PSOResult.SW.P[s].improved = 0;	// No improvement
            }

            // If the number max of evaluations is smaller than 
            // the swarm size, just keep evalMax particles, and finish
            if (PSOResult.SW.S > pb.evalMax) PSOResult.SW.S = pb.evalMax;
            PSOResult.nEval = PSOResult.SW.S;

            // Find the best
            PSOResult.SW.best = 0;

            switch (param.stop)
            {
                default:
                    errorPrev = PSOResult.SW.P[PSOResult.SW.best].f; // "distance" to the wanted f value (objective)
                    break;

                case 2:
                    errorPrev = Position.distanceL(PSOResult.SW.P[PSOResult.SW.best], pb.solution, 2); // Distance to the wanted solution
                    break;
            }

            for (s = 1; s < PSOResult.SW.S; s++)
            {
                switch (param.stop)
                {
                    default:
                        zz = PSOResult.SW.P[s].f;
                        if (zz < errorPrev)
                        {
                            PSOResult.SW.best = s;
                            errorPrev = zz;
                        }
                        break;

                    case 2:
                        zz = Position.distanceL(PSOResult.SW.P[PSOResult.SW.best], pb.solution, 2);
                        if (zz < errorPrev)
                        {
                            PSOResult.SW.best = s;
                            errorPrev = zz;
                        }
                        break;
                }
            }
            // Display the best
            Utils.Logger.Log(" Best value after init. {0} ", errorPrev);
            //	Utils.Logger.Log( "\n Position :\n" );
            //	for ( d = 0; d < SS.D; d++ ) Utils.Logger.Log( " %f", R.SW.P[R.SW.best].x[d] );

            initLinks = 1;		// So that information links will beinitialized
            // Note: It is also a flag saying "No improvement"
            //noStop = 0;
            Error = errorPrev;
            // ---------------------------------------------- ITERATIONS
            iter = 0;

        }


        public int NextIteration()
        {
            int numClamped = 0;
            iter++;

            if (initLinks == 1)	// Random topology
            {
                // Who informs who, at random
                for (s = 0; s < PSOResult.SW.S; s++)
                {
                    for (m = 0; m < PSOResult.SW.S; m++)
                    {
                        if (rand.NextDouble() < p) LINKS[m, s] = 1;	// Probabilistic method
                        else LINKS[m, s] = 0;
                    }
                    LINKS[s, s] = 1;
                }
            }

            // The swarm MOVES
            //Utils.Logger.Log("\nIteration %i",iter);
            for (int i = 0; i < PSOResult.SW.S; i++)
                index[i] = i;
            //Permutate the index order
            if (param.randOrder == 1)
            {
                index.Shuffle(7, PSOResult.SW.S);
            }

            Velocity GX = new Velocity(pb.SS.D);
            for (s0 = 0; s0 < PSOResult.SW.S; s0++)	// For each particle ...
            {


                s = index[s0];
                // ... find the first informant
                s1 = 0;
                while (LINKS[s1, s] == 0) s1++;
                if (s1 >= PSOResult.SW.S) s1 = s;

                // Find the best informant			
                g = s1;
                for (m = s1; m < PSOResult.SW.S; m++)
                {
                    if (LINKS[m, s] == 1 && PSOResult.SW.P[m].f < PSOResult.SW.P[g].f)
                        g = m;
                }

                //.. compute the new velocity, and move

                // Exploration tendency
                for (d = 0; d < pb.SS.D; d++)
                {
                    PSOResult.SW.V[s].v[d] = param.w * PSOResult.SW.V[s].v[d];
                    // Prepare Exploitation tendency  p-x
                    PX.v[d] = PSOResult.SW.P[s].x[d] - PSOResult.SW.X[s].x[d];
                    if (g != s)
                        GX.v[d] = PSOResult.SW.P[g].x[d] - PSOResult.SW.X[s].x[d];// g-x
                }
                PX.size = pb.SS.D;
                GX.size = pb.SS.D;


                // Option "non sentivity to rotation"				
                if (param.rotation > 0)
                {
                    normPX = Velocity.normL(PX, 2);
                    if (g != s) normGX = Velocity.normL(GX, 2);
                    if (normPX > 0)
                    {
                        RotatePX = Matrix.MatrixRotation(PX);
                    }

                    if (g != s && normGX > 0)
                    {
                        RotateGX = Matrix.MatrixRotation(GX);
                    }
                }

                // Exploitation tendencies
                switch (param.rotation)
                {
                    default:
                        for (d = 0; d < pb.SS.D; d++)
                        {
                            PSOResult.SW.V[s].v[d] = PSOResult.SW.V[s].v[d] + rand.NextDouble(0.0, param.c) * PX.v[d];
                            if (g != s)
                                PSOResult.SW.V[s].v[d] = PSOResult.SW.V[s].v[d] + rand.NextDouble(0.0, param.c) * GX.v[d];
                        }
                        break;

                    case 1:
                        // First exploitation tendency
                        if (normPX > 0)
                        {
                            zz = param.c * normPX / sqrtD;
                            aleaV = rand.NextVector(pb.SS.D, zz);
                            Velocity expt1 = RotatePX.VectorProduct(aleaV);

                            for (d = 0; d < pb.SS.D; d++)
                            {
                                PSOResult.SW.V[s].v[d] = PSOResult.SW.V[s].v[d] + expt1.v[d];
                            }
                        }

                        // Second exploitation tendency
                        if (g != s && normGX > 0)
                        {
                            zz = param.c * normGX / sqrtD;
                            aleaV = rand.NextVector(pb.SS.D, zz);
                            Velocity expt2 = RotateGX.VectorProduct(aleaV);
                            for (d = 0; d < pb.SS.D; d++)
                            {
                                PSOResult.SW.V[s].v[d] = PSOResult.SW.V[s].v[d] + expt2.v[d];
                            }
                        }
                        break;
                }

                // Update the position
                for (d = 0; d < pb.SS.D; d++)
                {
                    PSOResult.SW.X[s].x[d] = PSOResult.SW.X[s].x[d] + PSOResult.SW.V[s].v[d];
                }

                // --------------------------
                //noEval = 1;

                // Quantisation
                //Position.quantis(PSOResult.SW.X[s], pb.SS);

                switch (param.clamping)
                {
                    case 0:	// No clamping AND no evaluation
                        outside = 0;

                        for (d = 0; d < pb.SS.D; d++)
                        {
                            if (PSOResult.SW.X[s].x[d] < pb.SS.min[d] || PSOResult.SW.X[s].x[d] > pb.SS.max[d])
                                outside++;
                        }

                        //if (outside == 0)	// If inside, the position is evaluated
                        {
                            PSOResult.SW.X[s].f =
                                pb.perf(PSOResult.SW.X[s], pb.function, pb.objective);
                            PSOResult.nEval = PSOResult.nEval + 1;
                        }
                        break;

                    case 1:	// Set to the bounds, and v to zero
                        for (d = 0; d < pb.SS.D; d++)
                        {
                            if (PSOResult.SW.X[s].x[d] < pb.SS.min[d])
                            {
                                PSOResult.SW.X[s].x[d] = pb.SS.min[d];
                                PSOResult.SW.V[s].v[d] = 0;

                                numClamped++;
                            }

                            if (PSOResult.SW.X[s].x[d] > pb.SS.max[d])
                            {
                                PSOResult.SW.X[s].x[d] = pb.SS.max[d];
                                PSOResult.SW.V[s].v[d] = 0;
                                numClamped++;
                            }
                        }

                        PSOResult.SW.X[s].f = pb.perf(PSOResult.SW.X[s], pb.function, pb.objective);
                        PSOResult.nEval = PSOResult.nEval + 1;
                        break;
                }

                // ... update the best previous position
                if (PSOResult.SW.X[s].f < PSOResult.SW.P[s].f)	// Improvement
                {
                    PSOResult.SW.P[s] = PSOResult.SW.X[s].Clone();

                    // ... update the best of the bests
                    if (PSOResult.SW.P[s].f < PSOResult.SW.P[PSOResult.SW.best].f)
                    {
                        PSOResult.SW.best = s;
                    }
                }
            }			// End of "for (s0=0 ...  "	
            // Check if finished
            switch (param.stop)
            {
                default:
                    Error = PSOResult.SW.P[PSOResult.SW.best].f;
                    break;

                case 2:
                    Error = Position.distanceL(PSOResult.SW.P[PSOResult.SW.best], pb.solution, 2);
                    break;
            }
            //error= fabs(error - pb.epsilon);

            if (Error < errorPrev)	// Improvement
            {
                initLinks = 0;
            }
            else			// No improvement
            {
                initLinks = 1;	// Information links will be	reinitialized	
            }

            if (param.initLink == 1) initLinks = 1 - initLinks;

            errorPrev = Error;





            //return (int)PSOResult.nEval;
            return numClamped;
        }
    }
}
