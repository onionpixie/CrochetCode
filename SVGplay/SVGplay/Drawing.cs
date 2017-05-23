using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class Drawing
    {
        Graphics g;
        Pen p;
       // static float widthOfStitchSymbols;
       // float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;

        public Drawing(Graphics pG, Pen pP)
        {
            g = pG;
            p = pP;
            //var parameters = DrawingParameters.GetInstance();
            //widthOfStitchSymbols = parameters.stitchWidth;

        }
        public void drawLine(float x1, float y1, float x2, float y2)
        {
            g.DrawLine(p, new PointF(x1, y1), new PointF(x2, y2));
        }
        public void drawLine(PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
            
        }
    }
}
