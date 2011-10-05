using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.PSO;
using NeuronDotNet.Core.Initializers;
using System.Drawing;

using SPSO_2007;
namespace ENFORM
{
    public class Optimiser
    {
        private string filename;
        private DataAccess dataAccess;
        private Preprocessor preprocessor;
        private INetwork network;
        private int maxIterations = int.MaxValue;
        private int maxTime = -1;

        public int MaxTime
        {
            get { return maxTime; }
            set { maxTime = value; }
        }

        public int MaxIterations
        {
            get { return maxIterations; }
            set { maxIterations = value; }
        }
        private double minError = 0.0;

        public INetwork Network
        {
            get { return network; }
            set { network = value; }
        }
        private TrainingSet set;
        
        public Optimiser(string filename)
        {
            this.filename = filename;

            dataAccess = new DataAccess(filename);
            preprocessor = new Preprocessor();

            preprocessor.ImageSize = new Size(Convert.ToInt32(dataAccess.GetParameter("Master_Width")), Convert.ToInt32(dataAccess.GetParameter("Master_Height")));
            preprocessor.KeepAspectRatio = Convert.ToBoolean(dataAccess.GetParameter("Master_Aspect"));
            preprocessor.ScalingMethod = (ScalingMethods)Convert.ToInt32(dataAccess.GetParameter("Master_Resize"));
            preprocessor.ContrastStretch = Convert.ToBoolean(dataAccess.GetParameter("Filter_Stretch"));
            preprocessor.Histogram = Convert.ToBoolean(dataAccess.GetParameter("Filter_Histo"));
            preprocessor.Gaussian = Convert.ToBoolean(dataAccess.GetParameter("Filter_Gaussian"));
            preprocessor.GaussianStrength = Convert.ToInt32(dataAccess.GetParameter("Filter_BlurStr"));
            preprocessor.ContrastAdjustment = Convert.ToBoolean(dataAccess.GetParameter("Filter_Contrast"));
            preprocessor.ContrastStrength = Convert.ToDecimal(dataAccess.GetParameter("Filter_ContrastStr"));
            preprocessor.Greyscale = Convert.ToBoolean(dataAccess.GetParameter("Filter_Greyscale"));
            preprocessor.Bradley = Convert.ToBoolean(dataAccess.GetParameter("Filter_Bradley"));
            preprocessor.Threshold = Convert.ToBoolean(dataAccess.GetParameter("Filter_Threshold"));
            preprocessor.ThresholdStrength = Convert.ToDecimal(dataAccess.GetParameter("Filter_ThresholdStr"));

            /*
            dataAccess.SetParameter("Opt_Bp_LearningType", cmbLearningRateType.SelectedItem.ToString());
            dataAccess.SetParameter("Opt_Bp_InitialLearnRate", txtInitialRate.Text);
            dataAccess.SetParameter("Opt_Bp_FinalLearnRate", txtFinalRate.Text);
            dataAccess.SetParameter("Opt_Bp_JitterEpoch", txtJitterEpoch.Text);
            dataAccess.SetParameter("Opt_Bp_JitterNoiseLimit", txtJitterNoiseLimit.Text);
            dataAccess.SetParameter("Opt_Bp_MaxIterations", txtMaxIterations.Text);
            dataAccess.SetParameter("Opt_Bp_MinError", txtMinimumError.Text);
            */
            bool usePSO = false;
            bool useBP = false;
            try
            {
                useBP = Convert.ToBoolean(dataAccess.GetParameter("Opt_Bp_Enabled"));
            }
            catch (Exception)
            {
                Utils.Log("Warning unable to read BP params");
            }
            try
            {
                usePSO = Convert.ToBoolean(dataAccess.GetParameter("Opt_Pso_Enabled"));
            }
            catch (Exception)
            {
                Utils.Log("Warning unable to read PSO params");
            }

            if (usePSO && useBP)
            {
                throw new NotImplementedException("At this current time you cannot use both BP and PSO");

            }

            InputGroup[] inputGroups = dataAccess.GetInputGroups();
            SourceItem[] sourceItems = dataAccess.GetSourceItems();

            foreach (SourceItem item in sourceItems)
            {
                item.InternalImage = preprocessor.Process((Bitmap)item.InternalImage);

            }

            int total = 0;
            foreach (InputGroup inputGroup in inputGroups)
            {
                if (inputGroup.InputGroupType == InputGroupType.Grid)
                {
                    total += (inputGroup.Segments) * (inputGroup.Segments);
                }
                else
                {
                    total += inputGroup.Segments;
                }

            }

            maxIterations = Convert.ToInt32(dataAccess.GetParameter("Opt_Global_MaxIterations"));
            minError = Convert.ToDouble(dataAccess.GetParameter("Opt_Global_MinError"));
            maxTime = Convert.ToInt32(dataAccess.GetParameter("Opt_Global_MaxTime")); 



            if (useBP)
            {

                int learningRateFunction = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_LearningType"));
                double initialLR = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_InitialLearnRate"));
                double finalLR = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_FinalLearnRate"));
                int jitterEpoch = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_JitterEpoch"));
                double jitterNoiseLimit = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_JitterNoiseLimit"));
               

                

                NeuronDotNet.Core.Backpropagation.LinearLayer inputLayer = new NeuronDotNet.Core.Backpropagation.LinearLayer(preprocessor.ImageSize.Width * preprocessor.ImageSize.Height);
                NeuronDotNet.Core.Backpropagation.SigmoidLayer hiddenLayer = new NeuronDotNet.Core.Backpropagation.SigmoidLayer(total);
                hiddenLayer.InputGroups = inputGroups.Length;
                NeuronDotNet.Core.Backpropagation.SigmoidLayer outputLayer = new NeuronDotNet.Core.Backpropagation.SigmoidLayer(1);

                hiddenLayer.Initializer = new NormalizedRandomFunction();


                new BackpropagationConnector(
                    inputLayer,
                    hiddenLayer,
                    inputGroups,
                    preprocessor.ImageSize.Width,
                    preprocessor.ImageSize.Height
                    );

                new BackpropagationConnector(hiddenLayer, outputLayer);

                network = new BackpropagationNetwork(inputLayer, outputLayer);

                switch (learningRateFunction)
                {
                    case 0:
                        network.SetLearningRate(initialLR);
                        break;
                    case 1:
                        network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.ExponentialFunction(initialLR, finalLR));//exp
                        break;
                    case 2:
                        network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.HyperbolicFunction(initialLR, finalLR));//hyp
                        break;
                    case 3:
                        network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.LinearFunction(initialLR, finalLR));//lin
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("The learning rate index is out of range.\n");
                }
                network.JitterEpoch = jitterEpoch;
                network.JitterNoiseLimit = jitterNoiseLimit;

            }


            if (usePSO)
            {
                double minP = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_MinP"));
                double maxP = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_MaxP"));
                double minI = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_MinI"));
                double maxI = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_MaxI"));
                double quant = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_Quant"));

                int clamping = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Clamping"));
                int initLinks = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_InitLinks"));
                int randomness = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Randomness"));
                int randOrder = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_ParticleOrder"));
                int rotation = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Rotation"));

                int dimensions = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Dimensions"));
                int swarmSize = Convert.ToInt32(dataAccess.GetParameter("Opt_Pso_Particles"));
                double k = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_k"));
                double p = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_p"));
                double w = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_w"));
                double c = Convert.ToDouble(dataAccess.GetParameter("Opt_Pso_c"));


                Parameters param = new Parameters();
                param.clamping = clamping;
                // 0 => no clamping AND no evaluation. WARNING: the program
                // 				may NEVER stop (in particular with option move 20 (jumps)) 1
                // *1 => classical. Set to bounds, and velocity to zero

                param.initLink = initLinks; // 0 => re-init links after each unsuccessful iteration
                // 1 => re-init links after each successful iteration

                param.rand = randomness; // 0 => Use KISS as random number generator. 
                // Any other value => use the system one

                param.randOrder = randOrder; // 0 => at each iteration, particles are modified
                //     always according to the same order 0..S-1
                //*1 => at each iteration, particles numbers are
                //		randomly permutated
                param.rotation = rotation;
                // WARNING. Experimental code, completely valid only for dimension 2
                // 0 =>  sensitive to rotation of the system of coordinates
                // 1 => non sensitive (except side effects), 
                // 			by using a rotated hypercube for the probability distribution
                //			WARNING. Quite time consuming!

                param.stop = 0;	// Stop criterion
                // 0 => error < pb.epsilon
                // 1 => eval >= pb.evalMax		
                // 2 => ||x-solution|| < pb.epsilon              

                // =========================================================== 
                // RUNs

                // Initialize some objects
                //pb = new Problem(function);

                // You may "manipulate" S, p, w and c
                // but here are the suggested values
                param.S = swarmSize;
                if (param.S > 910) param.S = 910;
        

                param.K = (int)k;
                param.p = p;
                // (to simulate the global best PSO, set param.p=1)
                //param.p=1;
       
                param.w = w;
                param.c = c;



                NeuronDotNet.Core.PSO.LinearLayer inputLayer = new NeuronDotNet.Core.PSO.LinearLayer(preprocessor.ImageSize.Width * preprocessor.ImageSize.Height);
                NeuronDotNet.Core.PSO.SigmoidLayer hiddenLayer = new NeuronDotNet.Core.PSO.SigmoidLayer(total);
                hiddenLayer.InputGroups = inputGroups.Length;
                NeuronDotNet.Core.PSO.SigmoidLayer outputLayer = new NeuronDotNet.Core.PSO.SigmoidLayer(1);

                hiddenLayer.Initializer = new NormalizedRandomFunction();


                new PSOConnector(
                    inputLayer,
                    hiddenLayer,
                    inputGroups,
                    preprocessor.ImageSize.Width,
                    preprocessor.ImageSize.Height
                    );

                new PSOConnector(hiddenLayer, outputLayer);

                PSONetwork n = new PSONetwork(inputLayer, outputLayer);
                

                n.PsoParameters = param;
                n.PsoProblem.MaxI = maxI;
                n.PsoProblem.MinI = minI;
                n.PsoProblem.MaxP = maxP;
                n.PsoProblem.MinP = minP;
                n.PsoProblem.Quantisation = quant;
                network = n;
                
            }

            
            

            

           
           
            
           
            

            
           



            set = new TrainingSet(preprocessor.ImageSize.Width * preprocessor.ImageSize.Height, 1);
            foreach (SourceItem item in sourceItems)
            {
                

                double[] weights = Utils.getImageWeights(item.InternalImage, inputGroups);              
                set.Add(new TrainingSample(weights, new double[] { (double)item.SampleType }));
                


            }
            network.EndEpochEvent += new TrainingEpochEventHandler(network_EndEpochEvent);
            network.Initialize();
        }

        void network_EndEpochEvent(object sender, TrainingEpochEventArgs e)
        {           
            
            if (network.MeanSquaredError <= minError)
            {
                network.StopLearning();
            }
        }

        public double Optimise()
        {            
            return Optimise(maxIterations);
        }

        public double Optimise(int iterations)
        {
                           
                Network.Learn(set, iterations);
                return Network.MeanSquaredError;   
        }

        

        private double getAverageValue(Bitmap image, Rectangle area)
        {
            long average = 0;
            for (int i = area.X; i < area.Width; i++)
            {
                for (int j = area.Y; j < area.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    average += (long)pixel.ToArgb();

                }

            }

            return (double)average / (area.Width * area.Height);

        }

    }
}
