using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Model
{
    public enum PointPositionWithLine
    {
        OutOfBoundary = 0,
        Left = 1,
        Right = 2,
        OnTheLineOrHorizonal = 3,
    }
}
