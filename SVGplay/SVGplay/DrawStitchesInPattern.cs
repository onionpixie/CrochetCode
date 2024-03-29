﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class DrawStitchesInPattern
    {
        bool leftToRight = true;
        
        float currentY;
        int currentRow = 0;
        float x = 50.0f;        
        
        bool isCircle = DrawingParameters.GetInstance().Circle;
        float cumulativeRowHeight = 10;
        PointF startingCoords;
        private double angleSpacing = 360 / 12;
        List<PointF> topPoints = new List<PointF>();

        private DrawingParameters parameters;

        private float y = 0;
        private List<float> rowHeights = new List<float>();

        public List<float> RowHeights { get => rowHeights; set => rowHeights = value; }
        public float Y { get => y; set => y = value; }
        public DrawingParameters Parameters { get => parameters; set => parameters = value; }

        public DrawStitchesInPattern(List<float> pRowHeights, float pY)
        {
            RowHeights = pRowHeights;
            Y = pY;
            currentY = Y;
            Parameters = DrawingParameters.GetInstance();
        }        

        public void DrawChart(List<Stitch> pStitches, List<int> pNumStitches)
        {
            for (var i = 0; i < pStitches.Count; i++)
            {
                if (pStitches[i].HeightMultiplier == 0)
                {
                    InsertTurn();                   
                }
                else if (pStitches[i].Symbol == Stitch.StitchSymbol.vch)
                {
                    var tempY = Y;
                    for (var j = 0; j < pNumStitches[i]; j++)
                    {
                        pStitches[i].Draw(x, tempY, Parameters.StitchRotation);
                        tempY -= pStitches[i].HeightMultiplier * Parameters.SingleUnitHeight;
                    }
                    SetNewX(pStitches[i].WidthMultiplier);
                }
                else
                {
                    for (var j = 0; j < pNumStitches[i]; j++)
                    {
                        pStitches[i].Draw(x, Y, Parameters.StitchRotation);

                        SetNewX(pStitches[i].WidthMultiplier);
                    }
                }
            }            
        }

        private void InsertTurn()
        {
            if (leftToRight)
            {
                leftToRight = false;
                x -= (Parameters.StitchWidth + Parameters.StitchSpacing);
            }
            else
            {
                leftToRight = true;
                x = parameters.XIndentForRows;
            }

            Y -= (RowHeights[currentRow] + 7);
            currentRow++;
        }

        private void SetNewX(float widthMultipleer)
        {
            if (leftToRight)
            {
                x += Parameters.StitchSpacing + (Parameters.StitchWidth * widthMultipleer);
            }
            else
            {
                x -= Parameters.StitchSpacing + (Parameters.StitchWidth * widthMultipleer);
            }
        }

        public void CircleSetup()
        {
            if (isCircle) /// has to have 12 stitches in first circle atm
            {
                x = Y;
                startingCoords = new PointF(x, y + cumulativeRowHeight);
                for (var i = 0; i < 12; i++) // i < no of stitches in circle
                {
                    if (i == 0)
                    {
                        Parameters.StitchRotation = 270;
                    }
                    else
                    {
                        Parameters.StitchRotation += angleSpacing; // needs to actually be 360/no of stitches in first row of circle
                    }

                    if (Parameters.StitchRotation > 360)
                    {
                        Parameters.StitchRotation -= 360;
                    }

                    var TempX = x + (cumulativeRowHeight * (float)Math.Cos(DegreeToRadian(Parameters.StitchRotation)));
                    var TempY = y + (cumulativeRowHeight * (float)Math.Sin(DegreeToRadian(Parameters.StitchRotation)));
                    var tempPoint = new PointF(TempX, TempY);
                    topPoints.Add(tempPoint);
                }
                x = topPoints[0].X;
                y = topPoints[0].Y;
                Parameters.StitchRotation = 270;
                }
            }

        public void DrawStitchinCircle(List<Stitch> pStitches, List<int> pNumStitches)
        {
            var stitchNum = 0;
            var index = 0;
            foreach (var stitch in pStitches)
            {
                if (stitch.Symbol == Stitch.StitchSymbol.line)
                {
                    x = topPoints[stitchNum].X;
                    y = topPoints[stitchNum].Y;
                    cumulativeRowHeight = cumulativeRowHeight + RowHeights[currentRow] + 7;
                    currentRow++;
                    PointF origin = startingCoords;
                    PointF firstStitchNewRound = topPoints[stitchNum];
                    Parameters.StitchRotation = 270 - ((Angle(origin, firstStitchNewRound) + 180) - 270);
                    angleSpacing = 360 / ((currentRow) * 12);
                    stitchNum++;
                }

                for (var i = 0; i < pNumStitches[index]; i++)
                {
                    var nextCoords = pStitches[i].Draw(x, y, Parameters.StitchRotation);
                    topPoints.Add(nextCoords);
                    Parameters.StitchRotation += angleSpacing;

                    if (Parameters.StitchRotation > 360)
                    {
                        Parameters.StitchRotation -= 360;
                    }

                    stitchNum++;
                    x = topPoints[stitchNum].X;
                    y = topPoints[stitchNum].Y;
                }
                index++;
            }
        }
        
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        const double Rad2Deg = 180.0 / Math.PI;

        

        private double Angle(PointF start, PointF end)
        {
            return Math.Atan2(start.Y - end.Y, end.X - start.X) * Rad2Deg;
        }
    }
}


    //public void drawStitch(Stitch.StitchSymbol stitch)
    //{
    //    if (isCircle != true)
    //    {
    //        switch (stitch)
    //        {                
    //            case Stitch.StitchSymbol.puff:
    //                draw.drawThreeLoopPuffStitch(x, y, 3);
    //                if (leftToRight)
    //                {
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                else
    //                {
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                break;
    //            case Stitch.StitchSymbol.dc2tog:
    //                if (leftToRight)
    //                {
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation + 10);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation - 10);
    //                    double tempAngle = (280 + 260) * 0.5f;
    //                    float tempX = x - widthOfStitchSymbols - (stitchSpacing * 0.5f);
    //                    float tempY = y - rowSpacings[row];
    //                    draw.DrawTopLine(tempX, tempY, tempAngle);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                else
    //                {
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation - 10);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation + 10);
    //                    double tempAngle = (280 + 260) * 0.5f;
    //                    float tempX = x + widthOfStitchSymbols + (stitchSpacing * 0.5f);
    //                    float tempY = y - rowSpacings[row];
    //                    draw.DrawTopLine(tempX, tempY, tempAngle);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                break;
    //            case Stitch.StitchSymbol.dc3tog:
    //                if (leftToRight)
    //                {
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation + 15);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation);
    //                    float tempX = x - widthOfStitchSymbols;
    //                    float tempY = y - rowSpacings[row];
    //                    draw.DrawTopLine(tempX, tempY, stitchRotation, 2);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation - 15);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                else
    //                {
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation - 15);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation);
    //                    float tempX = x + widthOfStitchSymbols;
    //                    float tempY = y - rowSpacings[row];
    //                    draw.DrawTopLine(tempX, tempY, stitchRotation, 2);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    draw.DrawToplessDoubleCrochet(x, y, stitchRotation + 15);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                break;
    //            case Stitch.StitchSymbol.dcinc:
    //                if (leftToRight)
    //                {
    //                    draw.DrawDoubleCrochet(x, y, stitchRotation - 10);
    //                    draw.DrawDoubleCrochet(x, y, stitchRotation + 10);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                else
    //                {
    //                    draw.DrawDoubleCrochet(x, y, stitchRotation - 10);
    //                    draw.DrawDoubleCrochet(x, y, stitchRotation + 10);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                break;
    //            case Stitch.StitchSymbol.dc5shell:
    //                if (leftToRight)
    //                {
    //                    float tempX = x + (widthOfStitchSymbols * 2.5f);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation - 60);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation - 30);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation + 30);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation + 60);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                    x += (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                else
    //                {
    //                    float tempX = x - (widthOfStitchSymbols * 2.5f);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation - 60);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation - 30);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation + 30);
    //                    draw.DrawDoubleCrochet(tempX, y, stitchRotation + 60);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                    x -= (widthOfStitchSymbols + stitchSpacing);
    //                }
    //                break;
    //            default:
    //                throw new Exception("Unknown stitch symbol");
    //        }
    //    }
    //    else if (isCircle == true)
    //    {
    //        switch (stitch)
    //        {
    //            case Stitch.StitchSymbol.hdc:
    //                nextCoords = draw.DrawHalfDoubleCrochet(x, y, stitchRotation);
    //                topPoints.Add(nextCoords);
    //                stitchRotation = stitchRotation + angleSpacing;
    //                if (stitchRotation > 360)
    //                {
    //                    stitchRotation = stitchRotation - 360;
    //                }
    //                //x = startingCoords.X + (cumulativeRowHeight * (float)Math.Cos(DegreeToRadian(stitchRotation)));
    //                //y = startingCoords.Y + (cumulativeRowHeight * (float)Math.Sin(DegreeToRadian(stitchRotation)));
    //                stitchNum++;
    //                x = topPoints[stitchNum].X;
    //                y = topPoints[stitchNum].Y;
    //                //y = topPoints[stitchNum].Y + (7 * (float)Math.Sin(DegreeToRadian(stitchRotation)));
    //                break;
    //            case Stitch.StitchSymbol.hdcinc:
    //                
    //            case Stitch.StitchSymbol.dc:
    //                nextCoords = draw.DrawDoubleCrochet(x, y, stitchRotation);
    //                topPoints.Add(nextCoords);
    //                stitchRotation = stitchRotation + angleSpacing;
    //                if (stitchRotation > 360)
    //                {
    //                    stitchRotation = stitchRotation - 360;
    //                }
    //                //x = startingCoords.X + (cumulativeRowHeight * (float)Math.Cos(DegreeToRadian(stitchRotation)));
    //                //y = startingCoords.Y + (cumulativeRowHeight * (float)Math.Sin(DegreeToRadian(stitchRotation)));
    //                stitchNum++;
    //                x = topPoints[stitchNum].X;
    //                y = topPoints[stitchNum].Y;
    //                //y = topPoints[stitchNum].Y + (7 * (float)Math.Sin(DegreeToRadian(stitchRotation)));
    //                break;
    //            case Stitch.StitchSymbol.dcinc:
    //                nextCoords = draw.DrawDoubleCrochet(x, y, stitchRotation - 15);
    //                topPoints.Add(nextCoords);
    //                nextCoords = draw.DrawDoubleCrochet(x, y, stitchRotation + 15);
    //                topPoints.Add(nextCoords);
    //                stitchRotation = stitchRotation + angleSpacing;
    //                if (stitchRotation > 360)
    //                {
    //                    stitchRotation = stitchRotation - 360;
    //                }
    //                stitchNum++;
    //                x = topPoints[stitchNum].X;
    //                y = topPoints[stitchNum].Y;
    //                //x = startingCoords.X + (cumulativeRowHeight * (float)Math.Cos(DegreeToRadian(stitchRotation)));
    //                //y = startingCoords.Y + (cumulativeRowHeight * (float)Math.Sin(DegreeToRadian(stitchRotation)));
    //                break;
    //            case Stitch.StitchSymbol.line:
    //                x = topPoints[stitchNum].X;
    //                y = topPoints[stitchNum].Y;
    //                cumulativeRowHeight = cumulativeRowHeight + rowSpacings[row] + 7;
    //                row++;
    //                PointF origin = startingCoords;
    //                PointF firstStitchNewRound = topPoints[stitchNum];
    //                stitchRotation = 270-((Angle(origin, firstStitchNewRound)+180)-270);
    //                angleSpacing = 360 / ((row) * 12);
    //                break;
    //            case Stitch.StitchSymbol.end:
    //                break;

//            default:
//                throw new Exception("Unknown stitch symbol is circle");
//        }

//    }
//}
