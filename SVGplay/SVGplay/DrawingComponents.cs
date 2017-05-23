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
            //float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;
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
            //float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;
            float x1 = x + halfWidthOfStitchSymbols;
            float x2 = x - halfWidthOfStitchSymbols;
            float y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF((x2), y2));
            PointF midPoint = new PointF((x1 + x2) / 2, (y + y2) / 2);
            return midPoint;
        }
        public PointF drawDiagonalCenterLineToLeft(float x, float y, float pHeigth)
        {
            //float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;
            float centerOfLeftStitchBelow = x + halfWidthOfStitchSymbols + 1.5f;
            float x1 = x + widthOfStitchSymbols+3.0f;
            float y2 = y + pHeigth;
            g.DrawLine(p, new PointF(x1, y), new PointF(centerOfLeftStitchBelow, y2));
            PointF midPoint = new PointF((x1 + centerOfLeftStitchBelow) / 2, (y + y2) / 2);
            return midPoint;
        }
        public PointF drawDiagonalCenterLineToRight(float x, float y, float pHeight)
        {
            //float halfWidthOfStitchSymbols = widthOfStitchSymbols / 2;
            float centerOfRightStitchBelow = x + halfWidthOfStitchSymbols + widthOfStitchSymbols +4.5f;
            float x1 = x + widthOfStitchSymbols +3.0f;
            float y2 = y + pHeight;
            g.DrawLine(p, new PointF(x1, y), new PointF(centerOfRightStitchBelow, y2));
            PointF midPoint = new PointF((x1 + centerOfRightStitchBelow) / 2, (y + y2) / 2);
            return midPoint;
        }
        //public LineCoordinates drawLineUpAtAngle(PointF startPoint, float pHeight, double degrees)
        //{
        //    float cosAngle = (float)Math.Cos(DegreeToRadian(degrees));
        //    float sinAngle = (float)Math.Sin(DegreeToRadian(degrees));
        //    PointF endpoint = new PointF((startPoint.X + pHeight * cosAngle), (startPoint.Y + pHeight * sinAngle));
        //    g.DrawLine(p, startPoint, endpoint);
        //    PointF midPoint = new PointF((endpoint.X + startPoint.X) / 2, (endpoint.Y + startPoint.Y) / 2);
        //    LineCoordinates lineCoordinates;
        //    lineCoordinates.midPoint = midPoint;
        //    lineCoordinates.botPoint = startPoint;
        //    lineCoordinates.topPoint = endpoint;
        //    return lineCoordinates;
        //}
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        //public void drawCentralDiagLine(PointF center, float pHeight, double degrees)
        //{
        //    float length = widthOfStitchSymbols * 0.5f;
        //    float halfLength = length / 2;
        //    float cosAngle = (float)Math.Cos(DegreeToRadian(degrees));
        //    float sinAngle = (float)Math.Sin(DegreeToRadian(degrees));
        //    PointF endpoint = new PointF((center.X + halfLength * cosAngle), (center.Y + halfLength * sinAngle));
        //    g.DrawLine(p, center, endpoint);
        //    float cosAngle180 = (float)Math.Cos(DegreeToRadian(degrees+180));
        //    float sinAngle180 = (float)Math.Sin(DegreeToRadian(degrees+180));
        //    endpoint = new PointF((center.X + halfLength * cosAngle180), (center.Y + halfLength * sinAngle180));
        //    g.DrawLine(p, center, endpoint);
        //}
        // public void drawTopLine(PointF center, double degrees)
        //{
        //    float cosAngle = (float)Math.Cos(DegreeToRadian(degrees));
        //    float sinAngle = (float)Math.Sin(DegreeToRadian(degrees));
        //    float length = widthOfStitchSymbols * 0.5f;
        //    float halfLength = length / 2;
        //    PointF endpoint = new PointF((center.X + halfLength * cosAngle), (center.Y + halfLength * sinAngle));
        //    g.DrawLine(p, center, endpoint);
        //    float cosAngle180 = (float)Math.Cos(DegreeToRadian(degrees + 180));
        //    float sinAngle180 = (float)Math.Sin(DegreeToRadian(degrees + 180));
        //    endpoint = new PointF((center.X + halfLength * cosAngle180), (center.Y + halfLength * sinAngle180));
        //    g.DrawLine(p, center, endpoint);
        //}
        public struct LineCoordinates
        {
            public PointF midPoint;
            public PointF topPoint;
            public PointF botPoint;
        }
        public void drawLine(PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
        }
        public void drawEllipse(PointF topLeft, float pHeight, float pWidth)
        {
            g.DrawEllipse(p, topLeft.X, topLeft.Y, pWidth, pHeight );
        }
        public PointF CalculateCenterBasePoint(float pX, float pY, float pHeight, float pWidth, double pAngle)
        {
            double hAngle = pAngle + 90;
            float cosAngle = (float)Math.Cos(DegreeToRadian(hAngle));
            float sinAngle = (float)Math.Sin(DegreeToRadian(hAngle));
            float halfWidth = pWidth * 0.5f;
            float x2 = pX + (halfWidth * cosAngle);
            float y2 = pY + (halfWidth * sinAngle);
            float cospAngel = (float)Math.Cos(DegreeToRadian(pAngle));
            float sinpAngle = (float)Math.Sin(DegreeToRadian(pAngle));
            float x3 = x2 - (pHeight * cospAngel);
            float y3 = y2 - (pHeight * sinpAngle);
            return new PointF(x3, y3);
        }
        public PointF CalculateEndPoint(PointF startPoint, float pLength, double pAngle)
        {
            float cosAngle = (float)Math.Cos(DegreeToRadian(pAngle));
            float sinAngle = (float)Math.Sin(DegreeToRadian(pAngle));
            float x2 = startPoint.X + (pLength * cosAngle);
            float y2 = startPoint.Y + (pLength * sinAngle);
            PointF endpoint = new PointF(x2, y2);
            return endpoint;
        }
        public PointF CalculateMidPoint(PointF startPoint, PointF endPoint)
        {
            PointF midPoint = new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            return midPoint;
        }
        public PointF CalculateTopLeft(float pX, float pY, float pHeight)
        {
            float y = pY - pHeight;
            float x = pX - (widthOfStitchSymbols * 0.3f);
            return new PointF(x, y);
        }
    }
}


