using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland.EA.DomainSpecific
{
    class BinaryToANNWeightsDeveloper : PhenotypeDeveloper
    {



        public override Phenotype Develop(Genotype genotype)
        {
            BinaryGenotype binaryGenotype = (BinaryGenotype)genotype;

            ANNWeightPhenotype annWeightPhenotype = new ANNWeightPhenotype();


            return annWeightPhenotype;
        }
    }
}
