namespace SVGplay.Stitches
{
    class VerticalChainStitch : Stitch
    {
        public VerticalChainStitch() : base(StitchSymbol.vch, 1, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawVerticalChainStitch(x, y, pAngle, HeightMultiplier);
        }
    }
}

