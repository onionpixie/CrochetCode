using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class TrebleCrochet : Stitch
    {
        public TrebleCrochet() : base(StitchSymbol.tr, 4, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            var parameters = DrawingParameters.GetInstance();
            var draw = new DrawStitches(parameters.g, parameters.p);
            draw.DrawTrebleCrochet(x, y, pAngle);
        }
    }
}
