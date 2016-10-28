﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top6Question3
{
  public sealed class Circle
  {
    private double radius=3;
     
    public double Calculate(Func<double,double> op)
    {
      return op(radius);
    }
  }
}
