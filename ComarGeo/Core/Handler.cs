using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Core
{
    public class Handler
    {
        #region Field

        protected double epsilon;
        #endregion

        #region Constructor

        public Handler()
        {
            epsilon = 0.001;
        }

        public Handler(double epsilon)
        {
            this.epsilon = epsilon;
        }
        #endregion

        #region Private Method

        protected bool _IsZero(double val)
        {
            return Math.Abs(val) < epsilon;
        }

        protected bool _IsSame(double val1, double va2)
        {
            return Math.Abs(val1 - va2) <= epsilon;
        }
        #endregion
    }
}
