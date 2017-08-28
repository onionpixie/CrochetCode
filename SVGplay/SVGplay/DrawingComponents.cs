using System;
using System.Drawing;

namespace SVGplay
{
    class DrawingComponents
    {
        Graphics g;
        Pen p;
        static float widthOfStitchSymbols;
        float halfWidthOfStitchSymbols = widthOfStitchSymbols/2;

        public DrawingComponents()
        {
            var parameters = DrawingParameters.GetInstance();
            g = parameters.Graphics;
            p = parameters.Pen;
            widthOfStitchSymbols = parameters.StitchWidth;
        }

        public void DrawHorizontalLineOfStitchWidth (float x, float y, float pWidth)
        {
            g.DrawLine(p, x, y, x + pWidth, y);
        }
        public void DrawTopLine(float x, float y)
        {
            g.DrawLine(p, new PointF(x, y), new PointF((x + widthOfStitchSymbols), y));
        }
        public void DrawHorizontalMiddleLine(float x, float y, float pHeight)
        {
            g.DrawLine(p, new PointF(x, (y + (pHeight / 2))), new PointF(x + widthOfStitchSymbols, (y + (pHeight / 2))));
        }
        public PointF DrawVerticalMiddleLine(float x, float y, float pHeight)
        {
            var x1 = x + halfWidthOfStitchSymbols;
            var y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF(x1, y2));
            var midPoint = new PointF((x1 + x1) / 2, (y + y2) / 2);
            return midPoint;
        }

        public void DrawCentralDiagLine(float x, float y, float pHeight)
        {
            var firstQuarterWidth = widthOfStitchSymbols * 0.3f;
            var thirdQuarterWidth = widthOfStitchSymbols * 0.7f;
            var twoFifthsY = pHeight * 0.4f;
            var threeFifthsY = pHeight * 0.5f;
            g.DrawLine(p, new PointF(x + firstQuarterWidth, y + twoFifthsY), new PointF(x + thirdQuarterWidth, y + threeFifthsY));
        }
        public void DrawCentralDiagLine(PointF center, float pHeight)
        {
            var length = widthOfStitchSymbols * 0.5f;
            var halfLength = length / 2;
            var startingPoint = new PointF((center.X - halfLength), center.Y - (halfLength*0.9f));
            var endPoint = new PointF((center.X + halfLength), center.Y + (halfLength * 0.9f));
            g.DrawLine(p, startingPoint, endPoint);
        }

        public void DrawOuterArcs(float x, float y, float pHeight)
        {
            g.DrawArc(p, x, y + 1, widthOfStitchSymbols + 1.5f, pHeight - 1, 270, 180);
            g.DrawArc(p, x - 1.5f, y + 1, widthOfStitchSymbols + 1.5f, pHeight - 1, 270, -180);
        }
        public void DrawInnerArcs(float x, float y, float pHeight)
        {
            g.DrawArc(p, x + 3, y + 1, widthOfStitchSymbols * 0.5f, pHeight - 1, 270, 180);
            g.DrawArc(p, x + 2, y + 1, widthOfStitchSymbols * 0.5f, pHeight - 1, 270, -180);
        }
        public PointF DrawDiagonalCenterLineToRightStitch(float x, float y, float pHeight)
        {
            var x1 = x + halfWidthOfStitchSymbols;
            var y2 = y + pHeight;
            var centerOfAdjacentStitch = widthOfStitchSymbols + halfWidthOfStitchSymbols;
            var x2 = x + centerOfAdjacentStitch;
            g.DrawLine(p, new PointF(x1, y), new PointF(x2, y2));
            var midPoint = new PointF((x1 + x2) / 2, (y + y2) / 2);
            return midPoint;
        }
        public PointF DrawDiagonalCenterLineToLeftStitch(float x, float y, float pHeight)
        {
            var x1 = x + halfWidthOfStitchSymbols;
            var x2 = x - halfWidthOfStitchSymbols;
            var y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF((x2), y2));
            var midPoint = new PointF((x1 + x2) / 2, (y + y2) / 2);
            return midPoint;
        }
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        public void DrawLine(PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
        }
        public void DrawEllipse(PointF topLeft, float pHeight, float pWidth)
        {
            g.DrawEllipse(p, topLeft.X, topLeft.Y, pWidth, pHeight );
        }        
    }
}


