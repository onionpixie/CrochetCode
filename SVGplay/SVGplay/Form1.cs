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
        //private DrawingComponents dc2;
        private DrawingComponents draw;
        private DrawStitches drawStitches;
        private DrawStitchesInPattern patternDraw;
        private ParseInput parseInput;
        Graphics g;
        Pen p;
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
            parseInput = new SVGplay.ParseInput("17 ch, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 3 dc, 1 dc5shell, 3 dc, 1 dc2tog, 1 ch, 2 dc, turn, 1 ch, 1 sc, 1 ch,  11 sc, 1 ch, 2 sc, turn, 3 ch, 1 dc, 1 ch, 11 dc, 1 ch, 2 dc, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 1 dc, 1 ch, 11 dc, 1 ch, 2 dc, end");
            //parseInput = new SVGplay.ParseInput(" 10 dc, turn, 10 dc, turn, 10 dc, end");
            var stitchPattern = parseInput.ReadInputIntoList();          
            var patternLayout = new PatternLayout(stitchPattern);
            patternLayout.CalculateRowHeigths(stitchPattern);
            startingY = patternLayout.CalculateStartingYCoordinate(stitchPattern);
            rowHeigths = patternLayout.GetRowHeightList();
            patternDraw = new DrawStitchesInPattern(rowHeigths, g, p, startingY);
            patternDraw.ChartGo(stitchPattern);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            p = new Pen(Brushes.Black, 1);
            var parameters = DrawingParameters.GetInstance();
            float widthOfStitch = parameters.stitchWidth;
            draw = new DrawingComponents(g, p);
            drawStitches = new DrawStitches(g, p);
            //DrawingComponents.SetWidthOfStitchSymbols(16);
            //dc2 = new DrawingComponents(g, p2);
        }       
    }
}
