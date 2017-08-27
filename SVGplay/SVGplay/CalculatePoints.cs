using System;
using System.Drawing;

namespace SVGplay
{
    class CalculatePoints
    {
        private float widthOfStitchSymbols;

        public float WidthOfStitchSymbols { get => widthOfStitchSymbols; private set => widthOfStitchSymbols = value; }

        public CalculatePoints()
        {
            var parameters = DrawingParameters.GetInstance();
            WidthOfStitchSymbols = parameters.StitchWidth;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public PointF CalculateEndPoint(PointF startPoint, float pLength, double pAngle)
        {
            var cosAngle = (float)Math.Cos(DegreeToRadian(pAngle));
            var sinAngle = (float)Math.Sin(DegreeToRadian(pAngle));
            var x2 = startPoint.X + (pLength * cosAngle);
            var y2 = startPoint.Y + (pLength * sinAngle);
            var endpoint = new PointF(x2, y2);
            return endpoint;
        }

        public PointF CalculateMidPoint(PointF startPoint, PointF endPoint)
        {
            return new PointF((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
        }

        public PointF CalculateTopLeft(float pX, float pY, float pHeight)
        {
            var y = pY - pHeight;
            var x = pX - (WidthOfStitchSymbols * 0.3f);
            return new PointF(x, y);
        }
    }
}
