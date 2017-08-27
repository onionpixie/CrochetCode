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

        private float stitchWidth = 10.0f;
        public float StitchWidth { get => stitchWidth; }

        private float singleUnitHeight = 10.0f;
        public float SingleUnitHeight { get => singleUnitHeight; }
        
        private bool circle = false;
        public bool Circle { get => circle; set => circle = value; }

        public Graphics Graphics { get; set; }        

        private Pen pen = new Pen(Brushes.Black, 1);
        public Pen Pen { get => pen; set => pen = value; }
        
        private float rowSpacing = 5.0f;
        public float RowSpacing { get => rowSpacing; }

        private float stitchSpacing = 3.0f;
        public float StitchSpacing { get => stitchSpacing;  }

        private double stitchRotation = 270;
        public double StitchRotation { get => stitchRotation; set => stitchRotation = value; }

    }
}
