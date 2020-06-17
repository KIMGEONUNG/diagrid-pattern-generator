using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Utility
{
    [DebuggerDisplay("X : {X} , Y : {Y} , Val : {Val} , CenX {PixelCenterX} , CenY {PixelCenterY}")]
    public struct Pixel
    {
        #region Field

        private int x;
        private int y;
        private byte val;
        private double pixelCenterX;
        private double pixelCenterY;
        #endregion

        #region Property

        public int X { get => x; }
        public int Y { get => y;}
        public byte Val { get => val;}
        public double PixelCenterX { get => pixelCenterX; }
        public double PixelCenterY { get => pixelCenterY; }
        #endregion

        #region Constructor
        public Pixel(int x, int y, byte val, double centerX, double centerY)
        {
            this.x = x;
            this.y = y;
            this.val = val;
            this.pixelCenterX = centerX;
            this.pixelCenterY = centerY;
        }
        #endregion
    }
}
