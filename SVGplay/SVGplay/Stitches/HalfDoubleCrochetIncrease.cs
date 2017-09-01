using System.Drawing;

namespace SVGplay.Stitches
{
    public class HalfDoubleCrochetIncrease : Stitch
    {
        public HalfDoubleCrochetIncrease() : base(StitchSymbol.hdcinc, 2, 1)  {  }

        public override PointF Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            var nextPoints = draw.DrawHalfDoubleCrochetIncrease(x, y, pAngle, HeightMultiplier);
            return nextPoints[0];
        }
    }
}
