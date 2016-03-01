using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland.EA.DomainSpecific
{
    class BinaryToANNWeightsDeveloper : PhenotypeDeveloper
    {

        public int NumBitsPerWeight { get; set; }
        public int NumWeights { get; set; }

        public override Phenotype Develop(Genotype genotype)
        {
            BinaryGenotype binaryGenotype = (BinaryGenotype)genotype;

            ANNWeightPhenotype annWeightPhenotype = new ANNWeightPhenotype();

            double max = Math.Pow(2, numBitsPerWeight);

            double[] weights = new double[numWeights];
            int weight = 0;
            int weightIndex = 0;

            for (int i=0; i<binaryGenotype.BitVector.Length; i++)
            {
                weight += binaryGenotype.BitVector[i] << (i % numBitsPerWeight);
                if (i % numBitsPerWeight == numBitsPerWeight - 1)
                {
                    // Calculating a weight between 0 and 1
                    weights[weightIndex] = (double)weight / max;
                    weight = 0;
                    weightIndex++;
                }
            }

            annWeightPhenotype.Weights = weights;
            return annWeightPhenotype;
        }
    }
}
