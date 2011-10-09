using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSO_2007
{

    /// <summary>
    /// List of optimsation problems for use in SPSO.
    /// See problemDef( ) for precise definitions.
    /// </summary>
    public enum OptimisationProblem
    {
        /// <summary>
        /// Parabola Function (Sphere)
        /// </summary>
        Parabola_Sphere = 0,
        /// <summary>
        /// Griewank Function
        /// </summary>
        Griewank = 1,
        /// <summary>
        /// Rosenbrock Function (Banana)
        /// </summary>
        Rosenbrock_Banana = 2,
        /// <summary>
        /// Rastrigin Function
        /// </summary>
        Rastrigin = 3,
        /// <summary>
        /// Tripod Problem (Dimention 2)
        /// </summary>
        Tripod_d2 = 4,
        /// <summary>
        /// Ackley Function
        /// </summary>
        Ackley = 5,
        /// <summary>
        /// Schwefel Function
        /// </summary>
        Schwefel = 6,
        /// <summary>
        /// Schwefel Function 1.2
        /// </summary>
        Schwefel_1_2 = 7,
        /// <summary>
        /// Schwefel Function 2.22
        /// </summary>
        Schwefel_2_22 = 8,
        /// <summary>
        /// Neumaier Function (3)
        /// </summary>
        Neumaier_3 = 9,
        /// <summary>
        /// G3
        /// </summary>
        G3 = 10,
        /// <summary>
        /// Network Optimisation
        /// Warning: see problemDef() and also perf() for problem elements (number of BTS and BSC)
        /// </summary>
        Network_optimisation = 11,
        /// <summary>
        /// Another Schwefel Function
        /// </summary>
        Schwefel_2 = 12,
        /// <summary>
        /// 2D Goldstein-Price Function
        /// </summary>
        TWOD_Goldstein_Price = 13,
        /// <summary>
        /// Schaffer function (f6)
        /// </summary>
        Schaffer_f6 = 14,
        /// <summary>
        /// Step problem
        /// </summary>
        Step = 15,
        /// <summary>
        /// Schewfel 2.21
        /// </summary>
        Schwefel_2_21 = 16,
        /// <summary>
        /// Lennard Jones problem
        /// </summary>
        Lennard_Jones = 17,
        /// <summary>
        /// Gear Train problem
        /// </summary>
        Gear_Train = 18,
        Test = 99,

        /// <summary>
        /// Shifted Parabola/Sphere (F1) 
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F1 = 100,
        /// <summary>
        /// Shifted Rosenbrock (F6)
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F6 = 102,
        /// <summary>
        /// Shifted Rastrigin (F9)
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F9 = 103,
        /// <summary>
        /// Schwefel (F2)
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F2 = 104,
        /// <summary>
        /// Non-rotated Griewank (F7)
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F7 = 105,
        /// <summary>
        /// Non-rotated Ackley (F8)
        /// CEC 2005 benchmark  (Use no more than 30D. See cec2005data.c) 
        /// </summary>
        F8 = 106,

        //CUSTOM
        Neural_Network = 200

    }



}
