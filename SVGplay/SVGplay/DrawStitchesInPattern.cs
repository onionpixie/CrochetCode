using System;
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
        float y = 0;
        float currentY;
        int row = 0;
        float x = 10.0f;
        float stitchSpacing = 3.0f;
        double stitchRotation = 270;
        DrawStitches draw;
        //DrawingParameters parameters = DrawingParameters.GetInstance();
        float widthOfStitchSymbols = DrawingParameters.GetInstance().stitchWidth;
        List<float> rowSpacings = new List<float>();

        public DrawStitchesInPattern(List<float> rowHeights, Graphics pG, Pen pP, float pY)
        {
            rowSpacings = rowHeights;
            draw = new DrawStitches(pG, pP);
            y = pY;
            currentY = y;
        }

        public void ChartGo(List<Stitch> stitchPattern)
        {
            foreach (var stitch in stitchPattern)
            {
                for (int i = 0; i < stitch.number; i++)
                {
                    if (stitch.symbol == Stitch.StitchSymbol.vch)
                    {
                        float tempY = y;
                        float vertOffset = 0;
                        vertOffset = vertOffset + i;
                        tempY = y - (vertOffset * widthOfStitchSymbols);
                        draw.drawVerticalChainStitch(x, tempY);

                        if (i == stitch.number - 1)
                        {
                            if (leftToRight)
                            {
                                x += (widthOfStitchSymbols + stitchSpacing);
                            }
                            else
                            {
                                x -= (widthOfStitchSymbols + stitchSpacing);
                            }
                        }
                    }
                    else
                    {
                        drawStitch(stitch.symbol);
                    }
                }
            }
        }

        public void drawStitch(Stitch.StitchSymbol stitch)
        {
            
            switch (stitch)
            {
                case Stitch.StitchSymbol.ch:
                    draw.drawHorizontalChainStitch(x, y, rowSpacings[row]);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.sc:
                    draw.drawSingleCrochet(x, y, stitchRotation);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.dc:
                    draw.drawDoubleCrochet(x, y, stitchRotation);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.hdc:
                    draw.drawHalfDoubleCrochet(x, y, stitchRotation);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.tr:
                    draw.drawTrebleCrochet(x, y);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.fpdc:
                    draw.drawFrontPostDoubleCrochet(x, y);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.turn:
                    if (leftToRight)
                    {
                        leftToRight = false;
                        y = currentY - (rowSpacings[row] + 7);
                        currentY = y;
                        row++;
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        leftToRight = true;
                        x = 10.0f;
                        y = currentY - (rowSpacings[row] + 7);
                        currentY = y;
                        row++;
                       // x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.line:
                    break;
                case Stitch.StitchSymbol.skip:
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.end:
                    break;
                case Stitch.StitchSymbol.vch:
                    draw.drawVerticalChainStitch(x, y);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.puff:
                    draw.drawThreeLoopPuffStitch(x, y, 3);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.dc2tog:
                    //draw.drawDC2Tog(x, y);
                    if (leftToRight)
                    {
                        draw.drawToplessDoubleCrochet(x, y, stitchRotation + 10);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        draw.drawToplessDoubleCrochet(x, y, stitchRotation - 10);
                        double tempAngle = (280 + 260) * 0.5f;
                        float tempX = x - widthOfStitchSymbols - (stitchSpacing*0.5f);
                        float tempY = y - rowSpacings[row];
                        draw.drawTopLine(tempX, tempY, tempAngle);
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        draw.drawToplessDoubleCrochet(x, y, stitchRotation-10);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        draw.drawToplessDoubleCrochet(x, y, stitchRotation+10);
                        double tempAngle = (280 + 260) * 0.5f;
                        float tempX = x + widthOfStitchSymbols + (stitchSpacing * 0.5f);
                        float tempY = y - rowSpacings[row];
                        draw.drawTopLine(tempX, tempY, tempAngle);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.dc3tog:
                    draw.drawDC3Tog(x, y);
                    if (leftToRight)
                    {
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                case Stitch.StitchSymbol.dc5shell: 
                    if (leftToRight)
                    {
                        float tempX = x + (widthOfStitchSymbols * 2.5f);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation - 60);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation - 30);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation + 30);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation + 60);
                        //draw.drawFiveDCShell(x, y, true);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                        x += (widthOfStitchSymbols + stitchSpacing);
                    }
                    else
                    {
                        float tempX = x - (widthOfStitchSymbols * 2.5f);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation - 60);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation - 30);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation + 30);
                        draw.drawDoubleCrochet(tempX, y, stitchRotation + 60);
                        //draw.drawFiveDCShell(x, y, false);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                        x -= (widthOfStitchSymbols + stitchSpacing);
                    }
                    break;
                default:
                    throw new Exception("Unknown stitch symbol");

            }
        }
    }
}
