using System.Drawing;

namespace SVGplay.Stitches
{
    class LineCrochetStitch : Stitch
    {
        public LineCrochetStitch() : base(StitchSymbol.line, 0, 0)  { }

        public override PointF Draw(float x, float y, double pAngle)
        {
            return new PointF(x, y);
        }
    }
}
