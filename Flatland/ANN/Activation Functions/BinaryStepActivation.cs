using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland.ANN.Activation_Functions
{
    class BinaryStepActivation : ActivationFunction
    {
        public override double Activate(double input)
        {
            return (input >= 0.0) ? 1 : 0;
        }
    }
}
