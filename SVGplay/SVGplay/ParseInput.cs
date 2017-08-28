using System;
using System.Collections.Generic;
using System.Linq;
using SVGplay.Stitches;

namespace SVGplay
{
    class ParseInput
    {
        private string input;
        private List<Stitch> listOfStitchesinPattern = new List<Stitch>();
        private List<int> numOfStitches = new List<int>();

        public string Input
        {
            get => input;
            set
            {
                input = value;
                GenerateStitchAndCountLists();
            }
        }
        public List<Stitch> ListOfStitchesinPattern { get => listOfStitchesinPattern; set => listOfStitchesinPattern = value; }
        public List<int> NumOfStitches { get => numOfStitches; set => numOfStitches = value; }

        public ParseInput(string stringToParse)
        {
            Input = stringToParse;
        }      
        
        public void GenerateStitchAndCountLists()
        {
            var symbolList = SeperateInputIntoTwoLists();

            symbolList = ConvertChainsToVerticalChains(symbolList);

            ConvertListToStitches(symbolList);
        }

        public List<string> SeperateInputIntoTwoLists()
        {
            string[] separators = { ",", " " };

            var stitchSymbols = Input.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var symbolList = new List<string>();
            foreach (var entry in stitchSymbols)
            {
                if (int.TryParse(entry, out var num))
                {
                    NumOfStitches.Add(num);
                }
                else if (entry == "line" || entry == "skip" || entry == "turn" || entry == "end")
                {
                    NumOfStitches.Add(1);
                    symbolList.Add(entry);
                }
                else
                {
                    symbolList.Add(entry);
                }
            }
            if (symbolList[symbolList.Count-1] != "line" || symbolList[symbolList.Count-1] != "turn" || symbolList[symbolList.Count-1] != "end")
            {
                symbolList.Add("line");
            }
            return symbolList;                      
        }

        private void ConvertListToStitches(List<string> symbolList)
        {
            List<Stitch.StitchSymbol> convertedStitchSymbols = symbolList.ConvertAll(delegate (string x)
            {
                return (Stitch.StitchSymbol)Enum.Parse(typeof(Stitch.StitchSymbol), x);
            });

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
                    case Stitch.StitchSymbol.flsc:
                        stitch = new FrontLoopSingleCrochet();
                        break;
                    case Stitch.StitchSymbol.blsc:
                        stitch = new BackLoopSingleCrochet();
                        break;
                    case Stitch.StitchSymbol.fldc:
                        stitch = new FrontLoopDoubleCrochet();
                        break;
                    default:
                        throw new Exception("unexpected stitch symbol");
                }
                ListOfStitchesinPattern.Add(stitch);
            }
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
    }
}
