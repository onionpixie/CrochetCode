using System.Drawing;

namespace SVGplay.Stitches
{
    class FrontLoopDoubleCrochet : Stitch
    {
        public FrontLoopDoubleCrochet() : base(StitchSymbol.fldc, 3, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            return draw.DrawFrontLoopDoubleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
