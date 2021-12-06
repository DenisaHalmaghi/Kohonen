using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kohonen
{
    class PointsDrawer
    {
        CartesianToScreenCoordinates converter = new CartesianToScreenCoordinates();
        PaintEventArgs canvas;

        public PointsDrawer(PaintEventArgs control)
        {
            this.canvas = control;
        }

        public void clean()
        {
            canvas.Graphics.Clear(Color.White);
        }

        public void draw(List<(int X, int Y, Color color)> points)
        {
            canvas.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0, Constants.MAX * 2 + 1, Constants.MAX * 2 + 1);

            foreach (var point in points)
            {
                var brush = new SolidBrush(point.color);
                canvas.Graphics.FillRectangle(brush, converter.Ox(point.X), converter.Oy(point.Y), 2, 2);
            }
        }

        public void draw(Neuron[,] neurons)
        {
            /*var pointSize = large ? 8 : 2;
            canvas.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0, Constants.MAX * 2 + 1, Constants.MAX * 2 + 1);

            foreach (var point in points)
            {
                var brush = new SolidBrush(point.color);
                canvas.Graphics.FillRectangle(brush, converter.Ox(point.X), converter.Oy(point.Y), pointSize, pointSize);
            }*/
        }
    }
}