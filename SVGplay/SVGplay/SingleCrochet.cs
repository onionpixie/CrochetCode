using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{

    public class SingleCrochet : Stitch
    {
        public SingleCrochet() : base(StitchSymbol.sc, 1, 1)  {  }

        public override void Draw(float x, float y, double pAngle)
        {
            var parameters = DrawingParameters.GetInstance();
            var draw = new DrawStitches(parameters.g, parameters.p);
            draw.DrawSingleCrochet(x, y, pAngle);
        }
    }
}
