using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class LineCrochetStitch : Stitch
    {
        public LineCrochetStitch() : base(StitchSymbol.line, 0, 0)  { }

        public override void Draw(float x, float y, double pAngle)
        {
            
        }
    }
}
