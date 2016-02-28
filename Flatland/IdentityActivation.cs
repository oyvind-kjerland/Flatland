using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    class IdentityActivation : ActivationFunction
    {
        public override double Activate(double input)
        {
            return input;
        }
    }
}
