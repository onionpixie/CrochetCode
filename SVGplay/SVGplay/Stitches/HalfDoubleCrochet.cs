namespace SVGplay.Stitches
{
    class HalfDoubleCrochet : Stitch
    {
        public HalfDoubleCrochet() : base(StitchSymbol.hdc, 2, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawHalfDoubleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
