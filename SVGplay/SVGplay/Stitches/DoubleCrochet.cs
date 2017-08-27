namespace SVGplay.Stitches
{
    class DoubleCrochet : Stitch
    {
        public DoubleCrochet() : base(StitchSymbol.dc, 3, 1)  {  }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawDoubleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
