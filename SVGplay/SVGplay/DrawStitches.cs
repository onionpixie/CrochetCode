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
        }
        //public void drawSingleCrochet(float x, float y, float pWidth)
        //{
        //    draw.drawHorizontalMiddleLine(x, y, widthOfStitchSymbols);
        //    draw.drawVerticalMiddleLine(x, y, minRowHeight);

        //}
        public void drawSingleCrochet(float x, float y, double pAngle)
        {
            //PointF verticalLineStartPoint = draw.CalculateCenterBasePoint(x, y, minRowHeight, widthOfStitchSymbols, pAngle); // establish bottom center coordinate
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, minRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            //PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            //PointF horizontalLineStartPoint = new PointF(x, verticalLineMidPoint.Y);
            //PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            //draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line


            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, length, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, length, pAngle - 90);

            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
        }
        //public void drawHalfDoubleCrochet(float x, float y)
        //{
        //    draw.drawTopLine(x, y);
        //    draw.drawVerticalMiddleLine(x, y, minRowHeight*2);
        //}
        public void drawHalfDoubleCrochet(float x, float y, double pAngle)
        {
            //PointF verticalLineStartPoint = draw.CalculateCenterBasePoint(x, y, doubleRowHeight, widthOfStitchSymbols, pAngle); // establish bottom center coordinate
            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, doubleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint);
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        public void drawTopLine(float x, float y, double pAngle)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, widthOfStitchSymbols, pAngle + 90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
        }
        //public void drawDoubleCrochet(float x, float y)
        //{
        //    var midPoint = draw.drawVerticalMiddleLine(x, y, minRowHeight*3);
        //    draw.drawTopLine(x, y);
        //    draw.drawCentralDiagLine(midPoint, minRowHeight*3);
        //}

        public void drawDoubleCrochet(float x, float y, double pAngle)
        {
            //PointF verticalLineStartPoint = draw.CalculateCenterBasePoint(x, y, tripleRowHeight, widthOfStitchSymbols, pAngle); // establish bottom center coordinate

            PointF verticalLineStartPoint = new PointF(x, y);
            PointF verticalLineEndPoint = draw.CalculateEndPoint(verticalLineStartPoint, tripleRowHeight, pAngle); // find end point of line
            draw.drawLine(verticalLineStartPoint, verticalLineEndPoint); // draw vertical line
            PointF verticalLineMidPoint = draw.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through
            float length = widthOfStitchSymbols * 0.5f;
            float halfLength = length / 2;

            PointF horizontalLineStartPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y);
            PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle + 90);
            PointF horizontalLineOtherEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, halfLength, pAngle - 90); 

            //PointF horizontalLineStartPoint = new PointF(x + halfLength, verticalLineMidPoint.Y);
            //PointF horizontalLineEndPoint = draw.CalculateEndPoint(horizontalLineStartPoint, length+1, pAngle + 90); //+1 allows for thickness of vertical line
            draw.drawLine(horizontalLineStartPoint, horizontalLineEndPoint); // draw horizontal line
            draw.drawLine(horizontalLineStartPoint, horizontalLineOtherEndPoint); // draw horizontal line
            PointF topLineStartPoint = new PointF(verticalLineEndPoint.X, verticalLineEndPoint.Y);
            PointF topLineEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle + 90);
            PointF topLineOtherEndPoint = draw.CalculateEndPoint(topLineStartPoint, length, pAngle -90);
            draw.drawLine(topLineStartPoint, topLineEndPoint);
            draw.drawLine(topLineStartPoint, topLineOtherEndPoint);
        }
        public void drawToplessDoubleCrochet(float x, float y, double pAngle)
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
        public void drawTrebleCrochet(float x, float y)
        {
            float stitchHeigth = minRowHeight*4;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            draw.drawCentralDiagLine(x, y + 2, stitchHeigth);
        }
        public void drawDoubleTrebleCrochet(float x, float y)
        {
            float stitchHeigth = minRowHeight*5;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            draw.drawCentralDiagLine(x, y + 2, stitchHeigth);
            draw.drawCentralDiagLine(x, y + 4, stitchHeigth);
        }
        public void drawVerticalChainStitch(float x, float y)
        {
            PointF topLeftPoint = draw.CalculateTopLeft(x, y, minRowHeight);
            draw.drawEllipse(topLeftPoint,  widthOfStitchSymbols, minRowHeight * 0.6f);
            //g.DrawEllipse(p, x, y, minRowHeight * 0.7f, minRowHeight);

        }
        public void drawHorizontalChainStitch(float x, float y, float rowHeight)
        {
            PointF topLeftPoint = draw.CalculateTopLeft(x-1.5f, y, rowHeight);
            draw.drawEllipse(topLeftPoint, minRowHeight * 0.6f, widthOfStitchSymbols);
            //g.DrawEllipse(p, x, y, widthOfStitchSymbols, minRowHeight * 0.6f);
        }
        public void drawDC2Tog(float x, float y)
        {
            var midPoint = draw.drawDiagonalCenterLineToLeft(x, y, minRowHeight *3);
            draw.drawCentralDiagLine(midPoint, minRowHeight * 3);
            var midPoint2 = draw.drawDiagonalCenterLineToRight(x, y, minRowHeight * 3);
            draw.drawCentralDiagLine(midPoint2, minRowHeight * 3);
            draw.drawTopLine(x + (widthOfStitchSymbols/2) + 3.0f, y);
            
            //draw.drawTopLine(x + widthOfStitchSymbols, y);
            //x = x - pHeigth;
            //drawCentralDiagLine(x, y, pHeigth);
            //x = x + pHeigth + pHeigth;
            //drawCentralDiagLine(x, y, pHeigth);
        }
        public void drawDC3Tog(float x, float y)
        {
            x = x + widthOfStitchSymbols +3.0f;
            var midPoint = draw.drawDiagonalCenterLineToLeftStitch(x, y, minRowHeight * 3);
            draw.drawCentralDiagLine(midPoint, minRowHeight * 3);
            var midPoint2 = draw.drawDiagonalCenterLineToRightStitch(x, y, minRowHeight * 3);
            draw.drawCentralDiagLine(midPoint2, minRowHeight * 3);
            var midPoint3 = draw.drawVerticalMiddleLine(x, y, minRowHeight * 3);
            draw.drawCentralDiagLine(midPoint3, minRowHeight * 3);
            draw.drawTopLine(x, y);
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

        //public void drawFiveDCShell(float x, float y, bool leftToRight)
        //{
        //    float pHeight = minRowHeight * 3;
        //    float xTopLeft;
        //    if (leftToRight)
        //    {
        //        xTopLeft = x;
        //    }
        //    else
        //    {
        //        xTopLeft = x - ((widthOfStitchSymbols + 3) * 4);
        //    }
        //    float xCenterStitch = xTopLeft + ((widthOfStitchSymbols + 3) * 2);
        //    draw.drawTopLine(xCenterStitch, y);
        //    var midPoint1 = draw.drawVerticalMiddleLine(xCenterStitch, y, pHeight);
        //    draw.drawCentralDiagLine(midPoint1, pHeight);
        //    float yBottomCenter = y + pHeight;
        //    PointF centerBaseOfShell = new PointF(xCenterStitch + (widthOfStitchSymbols/2), yBottomCenter);
        //    var midPoint2 = draw.drawLineUpAtAngle(centerBaseOfShell, pHeight, 210);
        //    draw.drawCentralDiagLine(midPoint2.midPoint, pHeight, 290);
        //    var midPoint3 = draw.drawLineUpAtAngle(centerBaseOfShell, pHeight, 240);
        //    draw.drawCentralDiagLine(midPoint3.midPoint, pHeight, 330);
        //    var midPoint4 = draw.drawLineUpAtAngle(centerBaseOfShell, pHeight, 300);
        //    draw.drawCentralDiagLine(midPoint4.midPoint, pHeight, 30);
        //    var midPoint5 = draw.drawLineUpAtAngle(centerBaseOfShell, pHeight, 330);
        //    draw.drawCentralDiagLine(midPoint5.midPoint, pHeight, 60);
        //}
    }
}
