using System;
using System.Collections.Generic;
using System.Linq;
using SVGplay.Stitches;

namespace SVGplay
{
    class ParseInput
    {
        string input;
        public ParseInput(string stringToParse)
        {
            input = stringToParse;
        }

        List<int> numOfStitches = new List<int>();

        public List<Stitch> ReadInputIntoList()
        {
            string[] separators = { ",", " " };
            //char[] stitchSeparators = { ' ', ',' };

            var stitchSymbols = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var listStitchSymbols = new List<string>();
            foreach (var entry in stitchSymbols)
            {
                if (int.TryParse(entry, out var num))
                {
                    numOfStitches.Add(num);
                }
                else if (entry == "line" || entry == "skip" || entry == "turn" || entry == "end")
                {
                    numOfStitches.Add(1);
                    listStitchSymbols.Add(entry);
                }
                else
                {
                    listStitchSymbols.Add(entry);
                }
            }

            listStitchSymbols = ConvertChainsToVerticalChains(listStitchSymbols);

            List<Stitch.StitchSymbol> convertedStitchSymbols = listStitchSymbols.ConvertAll(delegate (string x)
            {
                return (Stitch.StitchSymbol)Enum.Parse(typeof(Stitch.StitchSymbol), x);
            });

            List<Stitch> ListOfStitchesinPattern = new List<Stitch>(); 

            foreach (var symbol in convertedStitchSymbols)
            {
                Stitch stitch;
                switch (symbol)
                {
                    case Stitch.StitchSymbol.sc:
                        stitch = new SingleCrochet();
                        break;
                    case Stitch.StitchSymbol.dc:
                        stitch = new DoubleCrochet();
                        break;
                    case Stitch.StitchSymbol.hdc:
                        stitch = new HalfDoubleCrochet();
                        break;
                    case Stitch.StitchSymbol.tr:
                        stitch = new TrebleCrochet();
                        break;
                    case Stitch.StitchSymbol.ch:
                        stitch = new HorizontalChainStitch();
                        break;
                    case Stitch.StitchSymbol.vch:
                        stitch = new VerticalChainStitch();
                        break;
                    case Stitch.StitchSymbol.line:
                    case Stitch.StitchSymbol.turn:
                        stitch = new LineCrochetStitch();
                        break;
                    default:
                        throw new Exception("unexpected stitch symbol");
                }
                ListOfStitchesinPattern.Add(stitch);

            }
            return ListOfStitchesinPattern;
            //return numofStitches.Zip(convertedStitchSymbols, (n, s) => new Stitch(s, n)).ToList();
        }

        private List<string> ConvertChainsToVerticalChains(List<string> pListStitchSymbols)
        {
            var listStitchSymbols = pListStitchSymbols;

            for (var i = 2; i < listStitchSymbols.Count; i++)
            {
                if (listStitchSymbols[i] != "ch")
                {
                    continue;
                }
                // chs immediate before or after a turn are vch
                if (listStitchSymbols[i - 1] == "turn")
                {
                    listStitchSymbols[i] = "vch";
                }
                else if (listStitchSymbols[i + 1] == "turn")
                {
                    listStitchSymbols[i] = "vch";
                }
            }

            return listStitchSymbols;
        }

        public List<int> GetListofStitchCounts()
        {
            return numOfStitches;
        }
    }
}
