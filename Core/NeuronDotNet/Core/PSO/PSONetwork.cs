/***********************************************************************************************
 COPYRIGHT 2008 Vijeth D

 This file is part of NeuronDotNet.
 (Project Website : http://neurondotnet.freehostia.com)

 NeuronDotNet is a free software. You can redistribute it and/or modify it under the terms of
 the GNU General Public License as published by the Free Software Foundation, either version 3
 of the License, or (at your option) any later version.

 NeuronDotNet is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 See the GNU General Public License for more details.

 You should have received a copy of the GNU General Public License along with NeuronDotNet.
 If not, see <http://www.gnu.org/licenses/>.

***********************************************************************************************/

using System;
using System.Runtime.Serialization;
using SPSO_2007;
using System.Collections.Generic;
using ENFORM.Core;

namespace NeuronDotNet.Core.PSO
{
    
    
    /// <summary>
    /// This class extends a <see cref="Network"/> and represents a Backpropagation neural network.
    /// </summary>
    [Serializable]
    public class PSONetwork : Network
    {
        private double meanSquaredError;
        private bool isValidMSE;
        private TrainingSet trainingSet;
        private int currentIteration;
        private int trainingEpochs;
        private Problem psoProblem;      
        private Parameters psoParameters;
        private int evaluations = 0;
        private SPSO_2007.Algorithm pso;
        public int Evaluations
        {
            get { return evaluations; }
            set { evaluations = value; }
        }

        public Parameters PsoParameters
        {
            get { return psoParameters; }
            set { psoParameters = value; }
        }

        public Problem PsoProblem
        {
            get { return psoProblem; }
            set { psoProblem = value; }
        }

        public double[] AllWeights
        {
            get
            {
                return getAllWeights();
            }
            set
            {
                setAllWeights(value);

            }

        }

        /// <summary>
        /// Gets the value of mean squared error
        /// </summary>
        /// <value>
        /// Mean squared value of error in current training epoch
        /// </value>
        public override double MeanSquaredError
        {
            get { return isValidMSE ? meanSquaredError : 0d; }
        }

        /// <summary>
        /// Creates a new Back Propagation Network, with the specified input and output layers. (You
        /// are required to connect all layers using appropriate synapses, before using the constructor.
        /// Any changes made to the structure of the network after its creation may lead to complete
        /// malfunctioning)
        /// </summary>
        /// <param name="inputLayer">
        /// The input layer
        /// </param>
        /// <param name="outputLayer">
        /// The output layer
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>inputLayer</c> or <c>outputLayer</c> is <c>null</c>
        /// </exception>
        public PSONetwork(ActivationLayer inputLayer, ActivationLayer outputLayer)
            : base(inputLayer, outputLayer, TrainingMethod.Supervised)
        {
            this.meanSquaredError = 0d;
            this.isValidMSE = false;

            // Re-Initialize the network
            Initialize();

            double[] weights = getAllWeights();

            PsoProblem = new Problem(OptimisationProblem.Neural_Network, new Problem.FitnessHandler(getFitness), weights);
        }

        /// <summary>
        /// Deserialization Constructor
        /// </summary>
        /// <param name="info">
        /// Serialization information to deserialize and obtain the data
        /// </param>
        /// <param name="context">
        /// Serialization context to use
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>info</c> is <c>null</c>
        /// </exception>
        public PSONetwork(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            


        }

        /// <summary>
        /// <para>
        /// Trains the network for the given training sample (Online training mode). Note that this
        /// method trains the sample only once irrespective of the values of <c>currentIteration</c>
        /// and <c>trainingEpochs</c>. Those arguments are just used to adjust training parameters
        /// which are dependent on training progress.
        /// </para>
        /// </summary>
        /// <param name="trainingSample">
        /// Training sample to use
        /// </param>
        /// <param name="currentIteration">
        /// Current training epoch
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// If <c>trainingSample</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <c>trainingEpochs</c> is not positive, or if <c>currentIteration</c> is negative or if
        /// <c>currentIteration</c> is less than <c>trainingEpochs</c>
        /// </exception>
        public override void Learn(TrainingSample trainingSample, int currentIteration, int trainingEpochs)
        {
            meanSquaredError = 0d;
            isValidMSE = true;
            base.Learn(trainingSample, currentIteration, trainingEpochs);
        }

        /// <summary>
        /// Invokes BeginEpochEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingSet">
        /// Training set which is about to be trained
        /// </param>
        protected override void OnBeginEpoch(int currentIteration, TrainingSet trainingSet)
        {
            meanSquaredError = 0d;
            isValidMSE = false;
            base.OnBeginEpoch(currentIteration, trainingSet);
        }

        /// <summary>
        /// Invokes EndEpochEvent
        /// </summary>
        /// <param name="currentIteration">
        /// Current training iteration
        /// </param>
        /// <param name="trainingSet">
        /// Training set which got trained successfully this epoch
        /// </param>
        protected override void OnEndEpoch(int currentIteration, TrainingSet trainingSet)
        {
            meanSquaredError /= trainingSet.TrainingSampleCount;
            isValidMSE = true;
            base.OnEndEpoch(currentIteration, trainingSet);
        }

        /// <summary>
        /// A protected helper function used to train single learning sample
        /// </summary>
        /// <param name="trainingSample">
        /// Training sample to use
        /// </param>
        /// <param name="currentIteration">
        /// Current training epoch (Assumed to be positive and less than <c>trainingEpochs</c>)
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs (Assumed to be positive)
        /// </param>
        protected override void LearnSample(TrainingSample trainingSample, int currentIteration, int trainingEpochs)
        {
            // No validation here
            int layerCount = layers.Count;

            // Set input vector
            inputLayer.SetInput(trainingSample.InputVector);

            for (int i = 0; i < layerCount; i++)
            {
                layers[i].Run();
            }

            // Set Errors
            meanSquaredError += (outputLayer as ActivationLayer).SetErrors(trainingSample.OutputVector);            
        }

        private double getFitness(double[] weights)
        {
            meanSquaredError = 0.0;
            this.setAllWeights(weights);          
            
            

            for (int index = 0; index < trainingSet.TrainingSampleCount; index++)
            {
                //TrainingSample randomSample = trainingSet[index];
                // Learn a random training sample

                LearnSample(trainingSet[index], currentIteration, trainingEpochs);

                

            }

            return meanSquaredError / (double)trainingSet.TrainingSampleCount;
        }

        protected void setAllWeights(double[] weights)
        {
            

            int layerCount = layers.Count;
            int weightCount = 0;

            // Backpropagate errors


            for (int i = layerCount; i > 0; )
            {
                ActivationLayer layer = layers[--i] as ActivationLayer;
                foreach (ActivationNeuron neuron in layer.Neurons)
                {
                    neuron.bias = weights[weightCount++];
                    
                    foreach (ISynapse synapse in neuron.SourceSynapses)
                    {
                        synapse.Weight = weights[weightCount++];
                    }

                }
            }

        }


        protected double[] getAllWeights()
        {
            int layerCount = layers.Count;

            List<double> weights = new List<double>();
            
            // Backpropagate errors
            
            
            for (int i = layerCount; i > 0; )
            {
                ActivationLayer layer = layers[--i] as ActivationLayer;
                foreach (ActivationNeuron neuron in layer.Neurons)
                {
                    weights.Add(neuron.Bias);
                    foreach (ISynapse synapse in neuron.SourceSynapses)
                    {
                        weights.Add(synapse.Weight);
                    }

                }
            }


            return weights.ToArray();
        }

        public void SetBestWeights()
        {
            if (pso != null)
            {
                this.setAllWeights(pso.BestResult);
            }
        }

        /// <summary>
        /// Trains the neural network for the given training set (Batch Training)
        /// </summary>
        /// <param name="trainingSet">
        /// The training set to use
        /// </param>
        /// <param name="trainingEpochs">
        /// Number of training epochs. (All samples are trained in some random order, in every
        /// training epoch)
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if <c>trainingSet</c> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if <c>trainingEpochs</c> is zero or negative
        /// </exception>
        public override void Learn(TrainingSet trainingSet, int trainingEpochs)
        {
            this.trainingSet = trainingSet;
            this.trainingEpochs = trainingEpochs;

            // Validate
            Helper.ValidateNotNull(trainingSet, "trainingSet");
            Helper.ValidatePositive(trainingEpochs, "trainingEpochs");
            if ((trainingSet.InputVectorLength != inputLayer.NeuronCount)
                || (trainingMethod == TrainingMethod.Supervised && trainingSet.OutputVectorLength != outputLayer.NeuronCount)
                || (trainingMethod == TrainingMethod.Unsupervised && trainingSet.OutputVectorLength != 0))
            {
                throw new ArgumentException("Invalid training set");
            }

            // Reset isStopping
            isStopping = false;


            // Re-Initialize the network
            Initialize();           
            
           
            pso = new SPSO_2007.Algorithm(PsoProblem,PsoParameters);
            pso.StartRun();

            for (currentIteration = 0; currentIteration < trainingEpochs;)
            {
                //int[] randomOrder = Helper.GetRandomOrder(trainingSet.TrainingSampleCount);
                // Beginning a new training epoch
                OnBeginEpoch(currentIteration, trainingSet);

                // Check for Jitter Epoch
                /*
                if (jitterEpoch > 0 && currentIteration % jitterEpoch == 0)
                {
                    for (int i = 0; i < connectors.Count; i++)
                    {
                        connectors[i].Jitter(jitterNoiseLimit);
                    }
                }
                */


                Evaluations = pso.NextIteration();
                currentIteration++;

                meanSquaredError = pso.BestFitness;// *trainingSet.TrainingSampleCount;
                


                // Training Epoch successfully complete
                OnEndEpoch(currentIteration, trainingSet);

                // Check if we need to stop
                if (isStopping) {
                    pso.EndRun();
                    this.setAllWeights(pso.BestResult);
                    
                    isStopping = false; 
                    return; 
                }
            }

        }
    }
}