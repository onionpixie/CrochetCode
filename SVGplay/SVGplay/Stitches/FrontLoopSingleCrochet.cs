using System.Drawing;

namespace SVGplay.Stitches
{
    public class FrontLoopSingleCrochet : Stitch
    {
        public FrontLoopSingleCrochet() : base(StitchSymbol.flsc, 1, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            return draw.DrawFrontLoopSingleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
