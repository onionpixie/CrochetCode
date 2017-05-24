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


        public DrawStitches(Graphics pG, Pen pP)
        {
            g = pG;
            p = pP;
            var parameters = DrawingParameters.GetInstance();
            widthOfStitchSymbols = parameters.stitchWidth;
            minRowHeight = parameters.singleUnitHeight;
            draw = new DrawingComponents(pG, pP);
            doubleRowHeight = minRowHeight * 2;
            tripleRowHeight = minRowHeight * 3;
            quadRowHeight = minRowHeight * 4;
        }
        public void DrawSingleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, minRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line

            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, length, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, length, pAngle - 90);

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
        }
        public void DrawHalfDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, doubleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint);
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public void DrawTopLine(float x, float y, double pAngle)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public void DrawTopLine(float x, float y, double pAngle, int widthMultiplier)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, (widthOfStitchSymbols* widthMultiplier), pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public void DrawDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, tripleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90); 

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
            PointF topLineStartPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle + 90);
            PointF topLineOtherEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle -90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
            draw.drawLine(topLineStartPoint, topLineOtherEndPoint);
        }
        public void DrawToplessDoubleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, tripleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
        }
        public void DrawTrebleCrochet(float x, float y, double pAngle)
        {
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, quadRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line

            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;
            float lengthOfVerticalLine = tripleRowHeight;
            float verticalOffset = (lengthOfVerticalLine * 0.6f) - (lengthOfVerticalLine*0.5f);
            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);
            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
            horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);
            horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90);
            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line

            PointF topLineStartPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle + 90);
            PointF topLineOtherEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle - 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
            draw.drawLine(topLineStartPoint, topLineOtherEndPoint);
        }
        public void DrawVerticalChainStitch(float x, float y)
        {
            PointF topLeftPoint = draw.CalculateTopLeft(x, y, minRowHeight);
            draw.drawEllipse(topLeftPoint, widthOfStitchSymbols, minRowHeight * 0.6f);
        }
        public void DrawHorizontalChainStitch(float x, float y, float rowHeight)
        {
            PointF topLeftPoint = draw.CalculateTopLeft(x-1.5f, y, rowHeight);
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
