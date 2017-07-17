using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class CalculatePoints
    {
        static float widthOfStitchSymbols;

        public CalculatePoints()
        {
            var parameters = DrawingParameters.GetInstance();
            widthOfStitchSymbols = parameters.stitchWidth;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
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
