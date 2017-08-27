using System;
using System.Drawing;

namespace SVGplay
{
    class DrawStitches
    {              
        float minRowHeight;
        private Graphics g;
        private Pen p;
        private DrawingComponents draw;
        private CalculatePoints calcPoints;

        private float rowSpacing;
        private float stitchWidth;
        private float halfWidth;
        private float quarterWidth;

        

        public float StitchWidth
        {
            get => stitchWidth;
            set
            {
                stitchWidth = value;
                HalfWidth = stitchWidth * 0.5f;
                QuarterWidth = stitchWidth * 0.25f;
                
            }
        }

        public float HalfWidth { get => halfWidth; set => halfWidth = value; }
        public float QuarterWidth { get => quarterWidth; set => quarterWidth = value; }
        public float RowSpacing { get => rowSpacing; set => rowSpacing = value; }

        public DrawStitches()
        {
            var parameters = DrawingParameters.GetInstance();
            g = parameters.Graphics;
            p = parameters.Pen;
            StitchWidth = parameters.StitchWidth;
            minRowHeight = parameters.SingleUnitHeight;
            RowSpacing = parameters.RowSpacing;

            draw = new DrawingComponents();

            calcPoints = new CalculatePoints();
        }       

        public void DrawSingleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);         

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, HalfWidth);
        }        

        public PointF DrawHalfDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth);

            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;
        }

        public PointF DrawVerticalLine(PointF startPoint, float heightMultiplier, double pAngle) // return end point of line.
        {
            PointF verticalLineEndPoint = calcPoints.CalculateEndPoint(startPoint, heightMultiplier*minRowHeight, pAngle); // find end point of line

            draw.DrawLine(startPoint, verticalLineEndPoint); // draw vertical line

            return verticalLineEndPoint;
        }

        public void DrawHorizontalLineFromMidPoint(PointF midPoint, double pAngle, float length)
        {
            PointF horizontalLineEndPoint = calcPoints.CalculateEndPoint(midPoint, length, pAngle + 90);

            PointF horizontalLineOtherEndPoint = calcPoints.CalculateEndPoint(midPoint, length, pAngle - 90);

            draw.DrawLine(horizontalLineOtherEndPoint, horizontalLineEndPoint); // draw horizontal line
        }

        public void DrawTopLine(float x, float y, double pAngle)
        {
            PointF topLineStartPoint = new PointF(x, y);
            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, StitchWidth, pAngle + 90);
            draw.DrawLine(topLineStartPoint, topLineEndPoint);
        }

        public void DrawTopLine(float x, float y, double pAngle, int widthMultiplier)
        {
            var topLineStartPoint = new PointF(x, y);

            PointF topLineEndPoint = calcPoints.CalculateEndPoint(topLineStartPoint, (StitchWidth* widthMultiplier), pAngle + 90);

            draw.DrawLine(topLineStartPoint, topLineEndPoint);
        }

        public PointF DrawDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line            

            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;
        }

        public void DrawToplessDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line  
        }

        public PointF DrawTrebleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line                      

            var lengthOfVerticalLine = pHeightMultiplier * minRowHeight;

            var verticalOffset = lengthOfVerticalLine * 0.05f;

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            var upperMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);

            var lowerMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);

            DrawHorizontalLineFromMidPoint(upperMidPoint, pAngle, QuarterWidth); // draw center line 1  
            
            DrawHorizontalLineFromMidPoint(lowerMidPoint, pAngle, QuarterWidth); // draw center line 2             

            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;            
        }

        public PointF DrawDoubleTrebleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line            

            var verticalOffset = (pHeightMultiplier * minRowHeight) * 0.05f;

            PointF verticalLineMidPoint = calcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            var upperMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);

            var lowerMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);

            DrawHorizontalLineFromMidPoint(upperMidPoint, pAngle, QuarterWidth); // draw center line 1  

            DrawHorizontalLineFromMidPoint(lowerMidPoint, pAngle, QuarterWidth); // draw center line 2   

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line 3 

            PointF pointForNextStitch = calcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;
        }

        public void DrawVerticalChainStitch(float x, float y, double pAngle, float heightMultiplier)
        {
            PointF topLeftPoint = calcPoints.CalculateTopLeft(x, y, minRowHeight * heightMultiplier);

            draw.DrawEllipse(topLeftPoint, StitchWidth, minRowHeight * 0.6f);
        }

        public void DrawVerticalChainStitch(float x, float y)
        {
            
        }

        public void DrawHorizontalChainStitch(float x, float y, double pAngle, float heightMultiplier)
        {
            PointF topLeftPoint = calcPoints.CalculateTopLeft(x - 1.5f, y, minRowHeight*heightMultiplier);

            draw.DrawEllipse(topLeftPoint, minRowHeight * heightMultiplier, StitchWidth);
        }

        public void DrawHorizontalChainStitch(float x, float y, float rowHeight)
        {

        }

        public void DrawFrontLoopOnly(float x, float y)
        {
            g.DrawArc(p, x, y, 5, 3, 0, 180);
        }

        public void drawBackLoopOnly(float x, float y)
        {
            g.DrawArc(p, x, y, 5, 3, 0, -180);
        }

        public void DrawFrontPostDoubleCrochet(float x, float y)
        {
            var stitchHeigth = minRowHeight * 3;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            g.DrawArc(p, x, (y + stitchHeigth), StitchWidth, (minRowHeight / 2), 270, 270);
        }

        public void DrawBackPostDoubleCrochet(float x, float y)
        {
            var stitchHeigth = minRowHeight * 3;
            draw.drawVerticalMiddleLine(x, y, stitchHeigth);
            draw.drawTopLine(x, y);
            draw.drawCentralDiagLine(x, y, stitchHeigth);
            g.DrawArc(p, x, (y + stitchHeigth), StitchWidth, (minRowHeight / 2), 270, -270);
        }

        public void DrawDiagStitch(float x, float y)
        {
            draw.drawDiagonalCenterLineToLeftStitch(x, y, minRowHeight);
            draw.drawDiagonalCenterLineToRightStitch(x, y, minRowHeight);
            draw.drawTopLine(x, y);
        }

        public void DrawThreeLoopPuffStitch(float x, float y, int heightMultiple)
        {
            var pHeigth = minRowHeight * heightMultiple;
            draw.drawTopLine(x, y);
            draw.drawVerticalMiddleLine(x, y, pHeigth);
            draw.drawOuterArcs(x, y, pHeigth);
        }

        public void DrawFiveLoopPuffStitch(float x, float y, int heightMultiple)
        {
            var pHeight = minRowHeight * heightMultiple;
            draw.drawTopLine(x, y);
            draw.drawVerticalMiddleLine(x, y, pHeight);
            draw.drawOuterArcs(x, y, pHeight);
            draw.drawInnerArcs(x, y, pHeight);
        }
    }
}
