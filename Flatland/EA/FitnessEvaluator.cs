using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland.EA
{
    abstract class FitnessEvaluator
    {
        abstract public float Evaluate(Individual individual);
    }
}
