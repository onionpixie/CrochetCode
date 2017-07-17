using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{   
    class DrawingComponents
    {
        Graphics g;
        Pen p;
        static float widthOfStitchSymbols;
        float halfWidthOfStitchSymbols = widthOfStitchSymbols/2;
        private Drawing draw;

        public DrawingComponents(Graphics pG, Pen pP)
        {
            g = pG;
            p = pP;
            var parameters = DrawingParameters.GetInstance();
            widthOfStitchSymbols = parameters.stitchWidth;
            draw = new Drawing(pG, pP);
        }

        //public static void SetWidthOfStitchSymbols(float newWidth)
        //{
        //    widthOfStitchSymbols = newWidth;
        //}

        //public float GetWidthOfStitchSymbols()
        //{
        //    return widthOfStitchSymbols;
        //}
        public void drawHorizontalLineOfStitchWidth (float x, float y, float pWidth)
        {
            draw.drawLine(x, y, x + pWidth, y);
        }
        public void drawTopLine(float x, float y)
        {
            g.DrawLine(p, new PointF(x, y), new PointF((x + widthOfStitchSymbols), y));
        }
        public void drawHorizontalMiddleLine(float x, float y, float pHeight)
        {
            g.DrawLine(p, new PointF(x, (y + (pHeight / 2))), new PointF(x + widthOfStitchSymbols, (y + (pHeight / 2))));
        }
        public PointF drawVerticalMiddleLine(float x, float y, float pHeight)
        {
            float x1 = x + halfWidthOfStitchSymbols;
            float y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF(x1, y2));
            PointF midPoint = new PointF((x1 + x1) / 2, (y + y2) / 2);
            return midPoint;
        }

        public void drawCentralDiagLine(float x, float y, float pHeight)
        {
            float firstQuarterWidth = widthOfStitchSymbols * 0.3f;
            float thirdQuarterWidth = widthOfStitchSymbols * 0.7f;
            float twoFifthsY = pHeight * 0.4f;
            float threeFifthsY = pHeight * 0.5f;
            g.DrawLine(p, new PointF(x + firstQuarterWidth, y + twoFifthsY), new PointF(x + thirdQuarterWidth, y + threeFifthsY));
        }
        public void drawCentralDiagLine(PointF center, float pHeight)
        {
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;
            PointF startingPoint = new PointF((center.X - halfLength), center.Y - (halfLength*0.9f));
            PointF endPoint = new PointF((center.X + halfLength), center.Y + (halfLength * 0.9f));
            g.DrawLine(p, startingPoint, endPoint);
        }

        public void drawOuterArcs(float x, float y, float pHeight)
        {
            g.DrawArc(p, x, y + 1, widthOfStitchSymbols + 1.5f, pHeight - 1, 270, 180);
            g.DrawArc(p, x - 1.5f, y + 1, widthOfStitchSymbols + 1.5f, pHeight - 1, 270, -180);
        }
        public void drawInnerArcs(float x, float y, float pHeight)
        {
            g.DrawArc(p, x + 3, y + 1, widthOfStitchSymbols * 0.5f, pHeight - 1, 270, 180);
            g.DrawArc(p, x + 2, y + 1, widthOfStitchSymbols * 0.5f, pHeight - 1, 270, -180);
        }
        public PointF drawDiagonalCenterLineToRightStitch(float x, float y, float pHeight)
        {
            //float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;
            float x1 = x + halfWidthOfStitchSymbols;           
            float y2 = y + pHeight;
            float centerOfAdjacentStitch = widthOfStitchSymbols + halfWidthOfStitchSymbols;
            float x2 = x + centerOfAdjacentStitch;
            g.DrawLine(p, new PointF(x1, y), new PointF(x2, y2));
            PointF midPoint = new PointF((x1 + x2) / 2, (y + y2) / 2);
            return midPoint;
        }
        public PointF drawDiagonalCenterLineToLeftStitch(float x, float y, float pHeight)
        {
            float x1 = x + halfWidthOfStitchSymbols;
            float x2 = x - halfWidthOfStitchSymbols;
            float y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF((x2), y2));
            PointF midPoint = new PointF((x1 + x2) / 2, (y + y2) / 2);
            return midPoint;
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        public void drawLine(PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
        }
        public void drawEllipse(PointF topLeft, float pHeight, float pWidth)
        {
            g.DrawEllipse(p, topLeft.X, topLeft.Y, pWidth, pHeight );
        }        
    }
}


