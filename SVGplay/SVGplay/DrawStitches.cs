using System;
using System.Drawing;

namespace SVGplay
{
    class DrawStitches
    {       
        float widthOfStitchSymbols; 
        float minRowHeight;
        Graphics g;
        Pen p;
        private DrawingComponents draw;
        float doubleRowHeight;
        float tripleRowHeight;
        float quadRowHeight;
        private float rowSpacing = 5.0f;
        private CalculatePoints calcPoints;

        public DrawStitches(Graphics pG, Pen pP)
        {
            g = pG;
            p = pP;
            draw = new DrawingComponents(pG, pP);

            var parameters = DrawingParameters.GetInstance();
            widthOfStitchSymbols = parameters.stitchWidth;
            minRowHeight = parameters.singleUnitHeight;           
            doubleRowHeight = minRowHeight * 2;
            tripleRowHeight = minRowHeight * 3;
            quadRowHeight = minRowHeight * 4;

            calcPoints = new CalculatePoints();
        }
        public void DrawSingleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards
            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, minRowHeight, pAngle);         

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            DrawHorizontalLine(verticalLineMidPoint, pAngle, length);
        }        

        public PointF DrawHalfDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards
            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, doubleRowHeight, pAngle);

            PointF topLineMidPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            float length = widthOfStitchSymbols * 0.5f;
            DrawHorizontalLine(topLineMidPoint, pAngle, length);

            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, rowSpacing, pAngle);
            return pointForNextStitch;
        }

        public PointF DrawVerticalLine(PointF startPoint, float height, double pAngle) // return end point of line.
        {
            PointF verticalLineEndPoint = calcPoints.CalculateEndPoint(startPoint, height, pAngle); // find end point of line
            draw.drawLine(startPoint, verticalLineEndPoint); // draw vertical line
            return verticalLineEndPoint;
        }

        public void DrawHorizontalLine(PointF midPoint, double pAngle, float length)
        {
            PointF horizontalLineStartPoint = new PointF(midPoint.X, midPoint.Y);
            PointF horizontalLineEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, length, pAngle + 90);
            PointF horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, length, pAngle - 90);

            draw.drawLine(horizontalLineOtherEndPoint, horizontalLineEndPoint); // draw horizontal line
        }
        public void DrawTopLine(float x, float y, double pAngle)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public void DrawTopLine(float x, float y, double pAngle, int widthMultiplier)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, (widthOfStitchSymbols* widthMultiplier), pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public PointF DrawDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = calcPoints.CalculateEndPoint(verticalLineStartPoint, tripleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90); 

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
            PointF topLineStartPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, length, pAngle + 90);
            PointF topLineOtherEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, length, pAngle -90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
            draw.drawLine(topLineStartPoint, topLineOtherEndPoint);
            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, rowSpacing, pAngle);
            return pointForNextStitch;
        }
        public void DrawToplessDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = calcPoints.CalculateEndPoint(verticalLineStartPoint, tripleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
        }
        public void DrawTrebleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = calcPoints.CalculateEndPoint(verticalLineStartPoint, quadRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;
            float lengthOfVerticalLine = tripleRowHeight;
            float verticalOffset = (lengthOfVerticalLine * 0.6f) - (lengthOfVerticalLine*0.5f);
            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);
            PointF horizontalLineEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);
            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
            horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);
            horizontalLineEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);
            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line

            PointF topLineStartPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, length, pAngle + 90);
            PointF topLineOtherEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, length, pAngle - 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
            draw.drawLine(topLineStartPoint, topLineOtherEndPoint);
        }
        public void DrawVerticalChainStitch(float x, float y)
        {
            PointF topLeftPoint = calcPoints.CalculateTopLeft(x, y, minRowHeight);
            draw.drawEllipse(topLeftPoint, widthOfStitchSymbols, minRowHeight * 0.6f);
        }
        public void DrawHorizontalChainStitch(float x, float y, float rowHeight)
        {
            PointF topLeftPoint = calcPoints.CalculateTopLeft(x-1.5f, y, rowHeight);
            draw.drawEllipse(topLeftPoint, minRowHeight * 0.6f, widthOfStitchSymbols);
        }
        public void drawFrontLoopOnly(float x, float y)
        {
            g.DrawArc(p, x, y, 5, 3, 0, 180);
        }
        public void drawBackLoopOnly(float x, float y)
        {
            g.DrawArc(p, x, y, 5, 3, 0, -180);
        }
        public void drawFrontPostDoubleCrochet(float x, float y)
        {
            float stitchHeigth = minRowHeight * 3;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            g.DrawArc(p, x, (y + stitchHeigth), widthOfStitchSymbols, (minRowHeight / 2), 270, 270);
        }
        public void drawBackPostDoubleCrochet(float x, float y)
        {
            float stitchHeigth = minRowHeight * 3;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            g.DrawArc(p, x, (y + stitchHeigth), widthOfStitchSymbols, (minRowHeight / 2), 270, -270);
        }
        public void drawDiagStitch(float x, float y)
        {
            draw.drawDiagonalCenterLineToLeftStitch(x, y, minRowHeight);
            draw.drawDiagonalCenterLineToRightStitch(x, y, minRowHeight);
            draw.drawTopLine(x, y);
        }
        public void drawThreeLoopPuffStitch(float x, float y, int heightMultiple)
        {
            float pHeigth = minRowHeight * heightMultiple;
            draw.drawTopLine(x, y);
            draw.drawVerticalMiddleLine(x, y, pHeigth);
            draw.drawOuterArcs(x, y, pHeigth);
        }
        public void drawFiveLoopPuffStitch(float x, float y, int heightMultiple)
        {
            float pHeight = minRowHeight * heightMultiple;
            draw.drawTopLine(x, y);
            draw.drawVerticalMiddleLine(x, y, pHeight);
            draw.drawOuterArcs(x, y, pHeight);
            draw.drawInnerArcs(x, y, pHeight);
        }
    }
}
