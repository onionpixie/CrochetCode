using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SVGplay
{
    

    public partial class Form1 : Form
    {
        private DrawStitchesInPattern patternDraw;
        private ParseInput parseInput;
        float startingY;
        public float widthOfStitchSymbols = 10.0f;
        public float minHeigthOfStitchSymbols = 16.0f;
        public float lineHeigth;
        List<float> rowHeigths = new List<float>();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            parseInput = new SVGplay.ParseInput("21 ch, turn, 1 ch, 10 sc, 10 dc, turn, 2 ch, 10 hdc, 10 tr");
            //parseInput = new SVGplay.ParseInput("17 ch, turn, 1 ch, 16 sc, turn, 2 ch, 16 hdc, turn, 3 ch, 16 dc, turn, 4 ch, 16 tr, turn ");
            //parseInput = new SVGplay.ParseInput("17 ch, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 3 dc, 1 dc5shell, 2 dc, 1 dc3tog, 1 ch, 2 dc, turn, 1 ch, 1 sc, 1 ch,  11 sc, 1 ch, 2 sc, turn, 3 ch, 1 tr, 1 ch, 11 tr, 1 ch, 2 tr, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 1 dc, 1 ch, 11 dc, 1 ch, 2 dc, end");
            //parseInput = new SVGplay.ParseInput(" 10 dc, turn, 10 dc, turn, 10 dc, end");
            //parseInput = new SVGplay.ParseInput(" 12 hdc, line, 12 dcinc, line, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, line, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc");
            //parseInput = new SVGplay.ParseInput(" 12 hdc, line, 12 hdcinc, line, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, line, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc");
            var stitchPattern = parseInput.ReadInputIntoList();
            var stitchCounts = parseInput.GetListofStitchCounts();        
            var patternLayout = new PatternLayout();
            patternLayout.CalculateRowHeigths(stitchPattern);
            startingY = patternLayout.CalculateStartingYCoordinate(stitchPattern);
            rowHeigths = patternLayout.GetRowHeightList();
            patternDraw = new DrawStitchesInPattern(rowHeigths, startingY);
            patternDraw.ChartGo(stitchPattern, stitchCounts);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var parameters = DrawingParameters.GetInstance();
            parameters.Graphics = CreateGraphics();
            parameters.Pen = new Pen(Brushes.Black, 1);
        }       
    }
}
