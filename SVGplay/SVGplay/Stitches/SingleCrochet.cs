namespace SVGplay.Stitches
{
    public class SingleCrochet : Stitch
    {
        public SingleCrochet() : base(StitchSymbol.sc, 1, 1)  {  }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawSingleCrochet(x, y, pAngle, heightMultiplier);
        }
    }
}
