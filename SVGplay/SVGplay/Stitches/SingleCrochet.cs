using System.Drawing;

namespace SVGplay.Stitches
{
    public class SingleCrochet : Stitch
    {
        public SingleCrochet() : base(StitchSymbol.sc, 1, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            return draw.DrawSingleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
