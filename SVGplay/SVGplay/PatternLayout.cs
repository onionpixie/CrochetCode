﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static SVGplay.Form1;

namespace SVGplay
{
    class PatternLayout
    {
        private float minRowHeight;
        private List<float> rowHeigths = new List<float>();
        private float lineHeight = 0;
        private float startingY = 50;

        public List<float> RowHeigths { get => rowHeigths; set => rowHeigths = value; }
        public float StartingY { get => startingY; set => startingY = value; }

        public PatternLayout()
        {
            var parameters = DrawingParameters.GetInstance();
            minRowHeight = parameters.SingleUnitHeight;
        }

        public void CalculateStartingYCoordinate(List<Stitch> stitchPattern)
        {
            foreach (var rowHeigth in RowHeigths)
            {
                StartingY += rowHeigth;
            }          
        }

        public void CalculateRowHeigths(List<Stitch> stitchPattern)
        {
            foreach (var stitch in stitchPattern)
            {
                if (stitch.Symbol == Stitch.StitchSymbol.line || stitch.Symbol == Stitch.StitchSymbol.end || stitch.Symbol == Stitch.StitchSymbol.turn)
                {
                    RowHeigths.Add(lineHeight);
                    lineHeight = 0;
                }

                if (lineHeight < stitch.HeightMultiplier * minRowHeight)
                {
                    lineHeight = stitch.HeightMultiplier * minRowHeight;
                }                
            }
        }
    }
}

//switch (stitch.symbol)
//{
//    case Stitch.StitchSymbol.ch:
//        if (lineHeight < (minRowHeight / 2))
//        {
//            lineHeight = (minRowHeight / 2);
//        }
//        break;
//    case Stitch.StitchSymbol.vch:
//    case Stitch.StitchSymbol.sc:
//        if (lineHeight < minRowHeight)
//        {
//            lineHeight = minRowHeight;
//        }
//        break;                
//    case Stitch.StitchSymbol.puff:
//    case Stitch.StitchSymbol.hdc:
//    case Stitch.StitchSymbol.hdcinc:
//        if (lineHeight < minRowHeight * 2)
//        {
//            lineHeight = minRowHeight * 2;
//        }
//        break;
//    case Stitch.StitchSymbol.dc:
//    case Stitch.StitchSymbol.dc2tog:
//    case Stitch.StitchSymbol.fpdc:
//    case Stitch.StitchSymbol.dc3tog:
//    case Stitch.StitchSymbol.dc5shell:
//    case Stitch.StitchSymbol.dcinc:
//        if (lineHeight < minRowHeight * 3)
//        {
//            lineHeight = minRowHeight * 3;
//        }
//        break;
//    case Stitch.StitchSymbol.tr:
//        if (lineHeight < minRowHeight * 4)
//        {
//            lineHeight = minRowHeight * 4;
//        }
//        break;
//    case Stitch.StitchSymbol.line:
//    case Stitch.StitchSymbol.turn:
//    case Stitch.StitchSymbol.end:
//        rowHeigths.Add(lineHeight);
//        lineHeight = 0;
//        break;
//    case Stitch.StitchSymbol.skip:
//        break;
//    default:
//        throw new Exception("Unknown stitch symbol");
//}

