namespace SVGplay.Stitches
{
    public class BackLoopSingleCrochet : Stitch
    {
        public BackLoopSingleCrochet() : base(StitchSymbol.blsc, 1, 1)  {  }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawBackLoopSingleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
