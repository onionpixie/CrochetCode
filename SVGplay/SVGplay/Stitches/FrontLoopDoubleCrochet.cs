namespace SVGplay.Stitches
{
    class FrontLoopDoubleCrochet : Stitch
    {
        public FrontLoopDoubleCrochet() : base(StitchSymbol.fldc, 3, 1)  {  }

        public override void Draw(float x, float y, double pAngle)
        {
            var draw = new DrawStitches();
            draw.DrawFrontLoopDoubleCrochet(x, y, pAngle, HeightMultiplier);
        }
    }
}
