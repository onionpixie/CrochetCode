using System.Drawing;

namespace SVGplay
{
    public class DrawingParameters
    {   
        private float stitchWidth = 10.0f;        
        private float singleUnitHeight = 10.0f;                
        private bool circle = false;  
        private Pen pen = new Pen(Brushes.Black, 1);        
        private float rowSpacing = 5.0f;        
        private float stitchSpacing = 3.0f;
        private double stitchRotation = 270;
        private float xIndentForRows = 50.0f;

        public Graphics Graphics { get; set; }
        public double StitchRotation { get => stitchRotation; set => stitchRotation = value; }
        public float XIndentForRows { get => xIndentForRows; set => xIndentForRows = value; }
        public float StitchSpacing { get => stitchSpacing; }
        public float RowSpacing { get => rowSpacing; }
        public bool Circle { get => circle; set => circle = value; }
        public Pen Pen { get => pen; set => pen = value; }
        public float SingleUnitHeight { get => singleUnitHeight; }
        public float StitchWidth { get => stitchWidth; }

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
    }
}
