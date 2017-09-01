using System.Drawing;

namespace SVGplay.Stitches
{
    class DoubleTrebleCrochet : Stitch
    {
        public DoubleTrebleCrochet() : base(StitchSymbol.dtr, 4, 1) { }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            return draw.DrawDoubleTrebleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
