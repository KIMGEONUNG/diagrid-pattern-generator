using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Utility
{
    public class IntensionLayer
    {
        #region Field

        private Bitmap bitmap;
        #endregion

        #region Constructor

        public IntensionLayer(Bitmap _bitmap)
        {
            this.bitmap = _bitmap;
        }
        #endregion

        #region Method

        public List<Pixel> GetPixels(double width, double height)
        {
            var rs = new List<Pixel>();

            int bitWidth = bitmap.Width;
            int bitHeight = bitmap.Height;
            double xUnit = width / (double)bitWidth;
            double yUnit = height / (double)bitHeight;
            for (int j = 0; j < bitHeight; j++)
            {
                for (int i = 0; i < bitWidth; i++)
                {
                    double xPixcelCenter = (i + 0.5) * xUnit;
                    double yPixcelCenter = (j + 0.5) * yUnit;

                    Color pixel = bitmap.GetPixel(i, j);
                    
                    rs.Add(new Pixel(i, j, (byte)(255 - pixel.G), xPixcelCenter, yPixcelCenter));
                }
            }

            return rs;
        }
        #endregion
    }
}
