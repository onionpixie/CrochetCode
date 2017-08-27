namespace SVGplay.Stitches
{
    class DoubleTrebleCrochet : Stitch
    {
        public DoubleTrebleCrochet() : base(StitchSymbol.dtr, 4, 1) { }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawDoubleTrebleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
