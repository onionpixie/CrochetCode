using System.Drawing;

namespace SVGplay.Stitches
{
    class TrebleCrochet : Stitch
    {
        public TrebleCrochet() : base(StitchSymbol.tr, 4, 1)  { }

        public override PointF Draw(float x, float y, double pAngle)
        {            
            var draw = new DrawStitches();
            return draw.DrawTrebleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
