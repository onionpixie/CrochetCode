using System.Drawing;

namespace SVGplay.Stitches
{
    class DoubleCrochet : Stitch
    {
        public DoubleCrochet() : base(StitchSymbol.dc, 3, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            return draw.DrawDoubleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
