using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class HalfDoubleCrochet : Stitch
    {
        public HalfDoubleCrochet() : base(StitchSymbol.hdc, 2, 1)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            var parameters = DrawingParameters.GetInstance();
            var draw = new DrawStitches(parameters.g, parameters.p);
            draw.DrawHalfDoubleCrochet(x, y, pAngle);
        }
    }
}
