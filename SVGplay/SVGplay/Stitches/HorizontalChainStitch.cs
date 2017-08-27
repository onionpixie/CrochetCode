namespace SVGplay.Stitches
{
    class HorizontalChainStitch : Stitch
    {
        public HorizontalChainStitch() : base(StitchSymbol.ch, 0.6f, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawHorizontalChainStitch(x, y, pAngle, heightMultiplier);
        }
    }
}

