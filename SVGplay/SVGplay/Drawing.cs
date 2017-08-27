using System.Drawing;

namespace SVGplay
{
    class Drawing
    {
        Graphics g;
        Pen p;

        public Drawing()
        {
            var parameters = DrawingParameters.GetInstance();
            g = parameters.Graphics;
            p = parameters.Pen;

        }
        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            g.DrawLine(p, new PointF(x1, y1), new PointF(x2, y2));
        }

        public void DrawLine(PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
            
        }
    }
}
