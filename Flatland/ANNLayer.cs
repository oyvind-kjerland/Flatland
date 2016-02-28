using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    class ANNLayer
    {

        // 2D array of weights where each row are the output weights of one node
        public double[,] Weights { get; set; }

        // activation function as sigmoid, tangent, etc
        public ActivationFunction ActivationFunction { get; set; }

        // The output of the layer
        public double[] output;

        public int numNodes { get; private set; }
        public int numOutputs { get; private set; }

        public ANNLayer(int numNodes, int numOutputs)
        {

            this.numNodes = numNodes;
            this.numOutputs = numOutputs;

            Weights = new double[numNodes, numOutputs];

            output = new double[numOutputs];

            

        }

        public void Calculate(double[] input)
        {
            // Clear the output
            for (int i = 0; i < numOutputs; i++) output[i] = 0;

            // Iterate over each node in the layer
            for (int i=0; i<numNodes; i++)
            {

                // Get the activation
                double activation = ActivationFunction.Activate(input[i]);

                // Add the contribution to the outputs
                for (int j=0; j<numOutputs; j++)
                {
                    output[j] += Weights[i, j] * activation;
                }
            }
               
        }
    }
}
