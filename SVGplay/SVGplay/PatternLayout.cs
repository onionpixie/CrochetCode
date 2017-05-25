using System;
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
        List<float> rowHeigths = new List<float>();
        private float lineHeight = 0;
        
        public PatternLayout(List<Stitch> pattern)
        {
            var parameters = DrawingParameters.GetInstance();
            minRowHeight = parameters.singleUnitHeight;
        }

        public float CalculateStartingYCoordinate(List<Stitch> stitchPattern)
        {
            float startingY = 0;
            foreach (var entry in stitchPattern)
            {
                if (entry.symbol == Stitch.StitchSymbol.line || entry.symbol == Stitch.StitchSymbol.turn)
                {
                    startingY = startingY + 100.0f;
                }
            }
            return startingY;
            
        }
        public List<float> GetRowHeightList()
        {
            return rowHeigths;
        }
        public void CalculateRowHeigths(List<Stitch> stitchPattern)
        {

            foreach (var stitch in stitchPattern)
            {
                switch (stitch.symbol)
                {
                    case Stitch.StitchSymbol.ch:
                        if (lineHeight < (minRowHeight / 2))
                        {
                            lineHeight = (minRowHeight / 2);
                        }
                        break;
                    case Stitch.StitchSymbol.sc:
                        if (lineHeight < minRowHeight)
                        {
                            lineHeight = minRowHeight;
                        }
                        break;
                    case Stitch.StitchSymbol.dc:
                        if (lineHeight < minRowHeight * 3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.puff:
                    case Stitch.StitchSymbol.hdc:
                        if (lineHeight < minRowHeight * 2)
                        {
                            lineHeight = minRowHeight * 2;
                        }
                        break;
                    case Stitch.StitchSymbol.tr:
                        if (lineHeight < minRowHeight * 4)
                        {
                            lineHeight = minRowHeight * 4;
                        }
                        break;
                    case Stitch.StitchSymbol.line:
                    case Stitch.StitchSymbol.turn:
                    case Stitch.StitchSymbol.end:
                        rowHeigths.Add(lineHeight);
                        lineHeight = 0;
                        break;
                    case Stitch.StitchSymbol.skip:
                        break;
                    case Stitch.StitchSymbol.vch:
                        if (lineHeight < minRowHeight)
                        {
                            lineHeight = minRowHeight;
                        }
                        break;
                    case Stitch.StitchSymbol.dc2tog:
                        if (lineHeight < minRowHeight * 3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.fpdc:
                        if (lineHeight < minRowHeight * 3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.dc3tog:
                        if (lineHeight < minRowHeight * 3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.dc5shell:
                        if (lineHeight < minRowHeight * 3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.dcinc:
                        if (lineHeight < minRowHeight *3)
                        {
                            lineHeight = minRowHeight * 3;
                        }
                        break;
                    case Stitch.StitchSymbol.hdcinc:
                        if (lineHeight < minRowHeight * 2)
                        {
                            lineHeight = minRowHeight * 2;
                        }
                        break;
                    default:
                        throw new Exception("Unknown stitch symbol");
                }
            }
        }
    }
}
