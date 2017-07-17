using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class ParseInput
    {
        string input;
        public ParseInput(string stringToParse)
        {
            input = stringToParse;
        }

        List<int> numofStitches = new List<int>();

        public List<Stitch> ReadInputIntoList()
        {
            string[] separators = { ",", " " };
            char[] stitchSeparators = { ' ', ',' };

            List<string> stitchSymbols = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();


            List<string> onlyStitchSymbols = new List<string>();
            //List<int> numofStitches = new List<int>();
            foreach (var entry in stitchSymbols)
            {
                int num;
                if (Int32.TryParse(entry, out num))
                {
                    numofStitches.Add(num);
                }
                else if (entry == "line" || entry == "skip" || entry == "turn" || entry == "end")
                {
                    numofStitches.Add(1);
                    onlyStitchSymbols.Add(entry);
                }
                else
                    onlyStitchSymbols.Add(entry);
            }

            bool startingChain = true;
            for (int i = 0; i < onlyStitchSymbols.Count; i++)
            {
                if (i == 0) { } // skip first stitch

                else if (onlyStitchSymbols[i] == "ch" && onlyStitchSymbols[i - 1] == "turn" && startingChain == false) // chs immediate before or after a turn are vch
                    onlyStitchSymbols[i] = "vch";

                else if (onlyStitchSymbols[i] == "ch" && onlyStitchSymbols[i + 1] == "turn" && startingChain == false)
                    onlyStitchSymbols[i] = "vch";

                else if (onlyStitchSymbols[i] == "turn" && startingChain == true) // after first turn we can start looking for vch
                    startingChain = false;
            }

            List<Stitch.StitchSymbol> convertedStitchSymbols = onlyStitchSymbols.ConvertAll(delegate (string x)
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
                    case Stitch.StitchSymbol.line:
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

        public List<int> GetListofStitchCounts()
        {
            return numofStitches;
        }
    }
}
