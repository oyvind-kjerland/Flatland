﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland
{
    public abstract class ActivationFunction
    {
        abstract public double Activate(double input);
    }
}
