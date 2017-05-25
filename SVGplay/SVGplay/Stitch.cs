using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    class Stitch
    {
        public StitchSymbol symbol;                                    
        public int number;

        public Stitch(StitchSymbol _symbol, int pNumber)
        {
            symbol = _symbol;
            number = pNumber;
        }

        public enum StitchSymbol
        {
            sc,
            hdc,
            dc,
            tr,
            dtr,
            ch,
            sl_st,
            sc2tog,
            sc3tog,
            dc2tog,
            dc3tog,
            fpdc,
            bpdc,
            puff,
            line,
            skip,
            turn,
            end,
            vch, // my name for use when chain stitches are vertical
            dc5shell,
            dcinc,
            hdcinc
        }
        public enum StitchName
        {
            Single,
            Double,
            HalfDouble,
            Treble,
            DoubleTreble,
            Chain,
            SlipStitch,
            SingleCrochet2Together,
            SingleCrochet3Together,
            DoubleCrochet2Together,
            DoubleCrochet3Together,
            FrontPostDoubleCrochet,
            BackPostDoubleCrochet,

        }
    }
}
