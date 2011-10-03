using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuronDotNet.Core;
//using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.PSO;
using NeuronDotNet.Core.Initializers;
using System.Drawing;
using System.Windows.Forms;

namespace ENFORM
{
    public class Optimiser
    {
        private string filename;
        private DataAccess dataAccess;
        private Preprocessor preprocessor;
        private INetwork network;
        private int maxIterations = int.MaxValue;

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

            int learningRateFunction = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_LearningType"));
            double initialLR = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_InitialLearnRate"));
            double finalLR = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_FinalLearnRate"));
            int jitterEpoch = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_JitterEpoch"));
            double jitterNoiseLimit = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_JitterNoiseLimit"));
            maxIterations = Convert.ToInt32(dataAccess.GetParameter("Opt_Bp_MaxIterations"));
            minError = Convert.ToDouble(dataAccess.GetParameter("Opt_Bp_MinError"));

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

           
            LinearLayer inputLayer = new LinearLayer(preprocessor.ImageSize.Width * preprocessor.ImageSize.Height);
            SigmoidLayer hiddenLayer = new SigmoidLayer(total);
            hiddenLayer.InputGroups = inputGroups.Length;
            SigmoidLayer outputLayer = new SigmoidLayer(1);

            hiddenLayer.Initializer = new NormalizedRandomFunction();


            new PSOConnector(
                inputLayer, 
                hiddenLayer, 
                inputGroups, 
                preprocessor.ImageSize.Width, 
                preprocessor.ImageSize.Height
                );

            new PSOConnector(hiddenLayer, outputLayer);

            network = new PSONetwork(inputLayer, outputLayer);
            
            switch (learningRateFunction)
            {
                case 0:
                    network.SetLearningRate(initialLR);
                    break;
                case 1:
                    network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.ExponentialFunction(initialLR,finalLR));//exp
                    break;
                case 2:
                    network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.HyperbolicFunction(initialLR,finalLR));//hyp
                    break;
                case 3:
                    network.SetLearningRate(new NeuronDotNet.Core.LearningRateFunctions.LinearFunction(initialLR,finalLR));//lin
                    break;

                default:
                    throw new ArgumentOutOfRangeException("The learning rate index is out of range.\n");                  


            }
            

            
            //= new NeuronDotNet.Core.LearningRateFunctions.ExponentialFunction(0.3, 0.000005);
            network.JitterEpoch = jitterEpoch;
            network.JitterNoiseLimit = jitterNoiseLimit;



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
