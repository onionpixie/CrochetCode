using System;
using System.Collections.Generic;
using System.Drawing;

namespace SVGplay
{
    class DrawStitches
    {        
        private DrawingComponents draw;
        
        private float minRowHeight;
        private Graphics g;
        private Pen p;
        private CalculatePoints calcPoints;
        private float rowSpacing;
                
        private float stitchWidth;
        private float halfWidth;
        private float quarterWidth;
        private float angleOffset;

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
        internal CalculatePoints CalcPoints { get => calcPoints; set => calcPoints = value; }
        public float MinRowHeight { get => minRowHeight; set => minRowHeight = value; }
        public Graphics G { get => g; set => g = value; }
        public Pen P { get => p; set => p = value; }
        public float AngleOffset { get => angleOffset; set => angleOffset = value; }

        public DrawStitches()
        {
            var parameters = DrawingParameters.GetInstance();
            G = parameters.Graphics;
            P = parameters.Pen;
            StitchWidth = parameters.StitchWidth;
            MinRowHeight = parameters.SingleUnitHeight;
            RowSpacing = parameters.RowSpacing;
            draw = new DrawingComponents();
            CalcPoints = new CalculatePoints();
            AngleOffset = parameters.OffsetForIncrease;
        }       

        public PointF DrawSingleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);         

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, HalfWidth);

            return CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);
        }

        internal PointF DrawFrontLoopSingleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, HalfWidth);

            DrawFrontLoopFromCenterPoint(verticalLineStartPoint);

            return CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);
        }

        internal PointF DrawBackLoopSingleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, HalfWidth);

            DrawBackLoopFromCenterPoint(verticalLineStartPoint);

            return CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);
        }

        private void DrawFrontLoopFromCenterPoint(PointF verticalLineStartPoint)
        {
            var startX = verticalLineStartPoint.X - HalfWidth;
            var startY = verticalLineStartPoint.Y - (minRowHeight * 0.5f);

            G.DrawArc(P, startX, startY, StitchWidth, minRowHeight * 0.5f, 0, 180);
        }

        private void DrawBackLoopFromCenterPoint(PointF verticalLineStartPoint)
        {
            var startX = verticalLineStartPoint.X - HalfWidth;
            var startY = verticalLineStartPoint.Y ;

            G.DrawArc(P, startX, startY, StitchWidth, minRowHeight * 0.5f, 0, -180);
        }

        //public void DrawFrontLoopOnly(float x, float y)
        //{
        //    G.DrawArc(P, x, y, 5, 3, 0, 180);
        //}


        public PointF DrawHalfDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth);

            PointF pointForNextStitch = CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;
        }

        public PointF DrawVerticalLine(PointF startPoint, float heightMultiplier, double pAngle) // return end point of line.
        {
            PointF verticalLineEndPoint = CalcPoints.CalculateEndPoint(startPoint, heightMultiplier*MinRowHeight, pAngle); // find end point of line

            draw.DrawLine(startPoint, verticalLineEndPoint); // draw vertical line

            return verticalLineEndPoint;
        }

        public void DrawHorizontalLineFromMidPoint(PointF midPoint, double pAngle, float length)
        {
            PointF horizontalLineEndPoint = CalcPoints.CalculateEndPoint(midPoint, length, pAngle + 90);

            PointF horizontalLineOtherEndPoint = CalcPoints.CalculateEndPoint(midPoint, length, pAngle - 90);

            draw.DrawLine(horizontalLineOtherEndPoint, horizontalLineEndPoint); // draw horizontal line
        }

        public void DrawHorizontalLine(float x, float y, double pAngle, int widthMultiplier)
        {
            var topLineStartPoint = new PointF(x, y);

            PointF topLineEndPoint = CalcPoints.CalculateEndPoint(topLineStartPoint, (StitchWidth* widthMultiplier), pAngle + 90);

            draw.DrawLine(topLineStartPoint, topLineEndPoint);
        }

        public PointF DrawDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line            

            return CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);
        }

        internal PointF DrawFrontLoopDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line 

            DrawFrontLoopFromCenterPoint(verticalLineStartPoint);

            return CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);       
        }

        public void DrawToplessDoubleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line  
        }

        public PointF DrawTrebleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line                      

            var lengthOfVerticalLine = pHeightMultiplier * MinRowHeight;

            var verticalOffset = lengthOfVerticalLine * 0.05f;

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            var upperMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);

            var lowerMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);

            DrawHorizontalLineFromMidPoint(upperMidPoint, pAngle, QuarterWidth); // draw center line 1  
            
            DrawHorizontalLineFromMidPoint(lowerMidPoint, pAngle, QuarterWidth); // draw center line 2             

            PointF pointForNextStitch = CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;            
        }

        public PointF DrawDoubleTrebleCrochet(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint, pAngle, HalfWidth); // draw top line            

            var verticalOffset = (pHeightMultiplier * MinRowHeight) * 0.05f;

            PointF verticalLineMidPoint = CalcPoints.CalculateMidPoint(verticalLineStartPoint, verticalLineEndPoint); // midpoint of vertical line which we want horizontal to cross through

            var upperMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y + verticalOffset);

            var lowerMidPoint = new PointF(verticalLineMidPoint.X, verticalLineMidPoint.Y - verticalOffset);

            DrawHorizontalLineFromMidPoint(upperMidPoint, pAngle, QuarterWidth); // draw center line 1  

            DrawHorizontalLineFromMidPoint(lowerMidPoint, pAngle, QuarterWidth); // draw center line 2   

            DrawHorizontalLineFromMidPoint(verticalLineMidPoint, pAngle, QuarterWidth); // draw center line 3 

            PointF pointForNextStitch = CalcPoints.CalculateEndPoint(verticalLineEndPoint, RowSpacing, pAngle);

            return pointForNextStitch;
        }

        public PointF DrawVerticalChainStitch(float x, float y, double pAngle, float heightMultiplier)
        {
            PointF topLeftPoint = CalcPoints.CalculateTopLeft(x, y, MinRowHeight * heightMultiplier);

            draw.DrawEllipse(topLeftPoint, StitchWidth, MinRowHeight * 0.6f);

            return new PointF(x, y);

        }

        public PointF DrawHorizontalChainStitch(float x, float y, double pAngle, float heightMultiplier)
        {
            PointF topLeftPoint = CalcPoints.CalculateTopLeft(x - 1.5f, y, MinRowHeight*heightMultiplier);

            draw.DrawEllipse(topLeftPoint, MinRowHeight * heightMultiplier, StitchWidth);

            return new PointF(x, y);
        }

        public void DrawDiagStitch(float x, float y)
        {
            draw.DrawDiagonalCenterLineToLeftStitch(x, y, MinRowHeight);
            draw.DrawDiagonalCenterLineToRightStitch(x, y, MinRowHeight);
            draw.DrawTopLine(x, y);
        }

        public List<PointF> DrawHalfDoubleCrochetIncrease(float x, float y, double pAngle, float pHeightMultiplier)
        {
            var verticalLineStartPoint = new PointF(x, y); //this is the bottom of the stitch, line will be drawn upwards

            PointF verticalLineEndPoint1 = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle + angleOffset);
            PointF verticalLineEndPoint2 = DrawVerticalLine(verticalLineStartPoint, pHeightMultiplier, pAngle - angleOffset);

            DrawHorizontalLineFromMidPoint(verticalLineEndPoint1, pAngle, QuarterWidth);
            DrawHorizontalLineFromMidPoint(verticalLineEndPoint2, pAngle, QuarterWidth);

            var nextPoints = new List<PointF>
            {
                CalcPoints.CalculateEndPoint(verticalLineEndPoint1, RowSpacing, pAngle),
                CalcPoints.CalculateEndPoint(verticalLineEndPoint2, RowSpacing, pAngle)
            };

            return nextPoints;
        }
        
        public void DrawBackLoopOnly(float x, float y)
        {
            G.DrawArc(P, x, y, 5, 3, 0, -180);
        }

        public void DrawFrontPostDoubleCrochet(float x, float y)
        {
            var stitchHeigth = MinRowHeight * 3;
            draw.DrawVerticalMiddleLine(x, y, stitchHeigth);
            draw.DrawTopLine(x, y);
            draw.DrawCentralDiagLine(x, y, stitchHeigth);
            G.DrawArc(P, x, (y + stitchHeigth), StitchWidth, (MinRowHeight / 2), 270, 270);
        }

        public void DrawBackPostDoubleCrochet(float x, float y)
        {
            var stitchHeigth = MinRowHeight * 3;
            draw.DrawVerticalMiddleLine(x, y, stitchHeigth);
            draw.DrawTopLine(x, y);
            draw.DrawCentralDiagLine(x, y, stitchHeigth);
            G.DrawArc(P, x, (y + stitchHeigth), StitchWidth, (MinRowHeight / 2), 270, -270);
        }

        

        public void DrawThreeLoopPuffStitch(float x, float y, int heightMultiple)
        {
            var pHeigth = MinRowHeight * heightMultiple;
            draw.DrawTopLine(x, y);
            draw.DrawVerticalMiddleLine(x, y, pHeigth);
            draw.DrawOuterArcs(x, y, pHeigth);
        }

        public void DrawFiveLoopPuffStitch(float x, float y, int heightMultiple)
        {
            var pHeight = MinRowHeight * heightMultiple;
            draw.DrawTopLine(x, y);
            draw.DrawVerticalMiddleLine(x, y, pHeight);
            draw.DrawOuterArcs(x, y, pHeight);
            draw.DrawInnerArcs(x, y, pHeight);
        }
    }
}
