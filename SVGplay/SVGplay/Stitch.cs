using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGplay
{
    public abstract class Stitch
    {

        public StitchSymbol symbol;        
        public float heightMultiplier;
        public float widthMultiplier;

        public Stitch(StitchSymbol pSymbol,
                      float pHeightMultiplier,
                      float pWidthMultiplier)
        {
            symbol = pSymbol;
            heightMultiplier = pHeightMultiplier;
            widthMultiplier = pWidthMultiplier;
        }

        public abstract void Draw(float x, float y, double pAngle);

        //public int number;
        //public PointF startingCoordinate;
        //public double angle;
        //public Stitch(StitchSymbol pSymbol, 
        //              int pNumber, 
        //              PointF pStartingCoordinate, 
        //              double pAngle,
        //              float pHeightMultiplier,
        //              float pWidthMultiplier)
        //{
        //    symbol = pSymbol;
        //    number = pNumber;
        //    startingCoordinate = pStartingCoordinate;
        //    angle = pAngle;
        //    heightMultiplier = pHeightMultiplier;
        //    widthMultiplier = pWidthMultiplier;
        //}

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
