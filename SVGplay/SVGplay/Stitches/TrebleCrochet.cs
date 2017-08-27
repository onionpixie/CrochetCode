namespace SVGplay.Stitches
{
    class TrebleCrochet : Stitch
    {
        public TrebleCrochet() : base(StitchSymbol.tr, 4, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {            
            var draw = new DrawStitches();
            draw.DrawTrebleCrochet(x, y, pAngle, heightMultiplier);
        }
    }
}
