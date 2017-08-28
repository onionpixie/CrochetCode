using System;
using System.Drawing;
using System.Windows.Forms;

namespace SVGplay
{
    public partial class Form1 : Form
    {
        private DrawingParameters parameters;

        public DrawingParameters Parameters { get => parameters; set => parameters = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parameters.Graphics.Clear(Color.AliceBlue);

            var parseInput = new ParseInput(patternToChart.Text);   
            
            var patternLayout = new PatternLayout();

            patternLayout.CalculateRowHeigths(parseInput.ListOfStitchesinPattern);

            patternLayout.CalculateStartingYCoordinate(parseInput.ListOfStitchesinPattern);

            var patternDraw = new DrawStitchesInPattern(patternLayout.RowHeigths, patternLayout.StartingY);

            patternDraw.DrawChart(parseInput.ListOfStitchesinPattern, parseInput.NumOfStitches);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Parameters = DrawingParameters.GetInstance();
            Parameters.Graphics = CreateGraphics();
            Parameters.Pen = new Pen(Brushes.Black, 1);
        }       
    }
}

//example patterns
// 21 ch, turn, 1 ch, 10 sc, 10 dc, turn, 2 ch, 10 hdc, 10 tr
//17 ch, turn, 1 ch, 16 sc, turn, 2 ch, 16 hdc, turn, 3 ch, 16 dc, turn, 4 ch, 16 tr, turn
//17 ch, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 3 dc, 1 dc5shell, 2 dc, 1 dc3tog, 1 ch, 2 dc, turn, 1 ch, 1 sc, 1 ch,  11 sc, 1 ch, 2 sc, turn, 3 ch, 1 tr, 1 ch, 11 tr, 1 ch, 2 tr, turn, 1 ch, 1 sc, 1 ch, 11 sc, 1 ch, 2 sc, turn, 3 ch, 1 dc, 1 ch, 11 dc, 1 ch, 2 dc, end
//10 dc, turn, 10 dc, turn, 10 dc, turn
//12 hdc, line, 12 dcinc, line, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, 1 dc, 1 dcinc, line, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc, 2 dc, 1 dcinc
//12 hdc, line, 12 hdcinc, line, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, 1 hdc, 1 hdcinc, line, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc, 2 hdc, 1 hdcinc
