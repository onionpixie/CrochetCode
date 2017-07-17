using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    public class DrawingParameters
    {
        private DrawingParameters() { }

        static DrawingParameters theParameters = null;
        public static DrawingParameters GetInstance()
        {
            if (theParameters == null)
            {
                theParameters = new DrawingParameters();
            }

            return theParameters;
        }

        public float stitchWidth = 10.0f;
        public float singleUnitHeight = 10.0f;
        public bool circle = false;
        public Graphics g { get; set; }
        public Pen p = new Pen(Brushes.Black, 1);
        public float rowSpacing = 5.0f;
        public float stitchSpacing = 3.0f;
        public double stitchRotation = 270;
    }
}
