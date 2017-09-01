using System.Drawing;

namespace SVGplay.Stitches
{
    public class BackLoopSingleCrochet : Stitch
    {
        public BackLoopSingleCrochet() : base(StitchSymbol.blsc, 1, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
           return draw.DrawBackLoopSingleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
