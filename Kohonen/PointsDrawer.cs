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

        public void draw(List<Point> points)
        {
            canvas.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0, Constants.MAX * 2 + 1, Constants.MAX * 2 + 1);

            foreach (var point in points)
            {
                var brush = new SolidBrush(Color.Black);
                canvas.Graphics.FillRectangle(brush, converter.Ox(point.X), converter.Oy(point.Y), 2, 2);
            }
        }

        public void draw(Neuron[,] neurons)
        {
            var neighbourService = new NeighbourService(neurons);
            var pen = new Pen(Color.BlueViolet);
            pen.Width = 2.0F;
            Neuron neuron;

            var length = neurons.GetLength(0);

            for (int i = 0; i < neurons.GetLength(0); i++)
            {
                for (int j = 0; j < neurons.GetLength(0); j++)
                {
                    neuron = neurons[i, j];
                    var neighbours = neighbourService.upperAndRightNeighbours((i, j));

                    foreach (var neighbour in neighbours)
                    {
                        canvas.Graphics.DrawLine(
                            pen,
                            new Point(converter.Ox(neuron.X), converter.Oy(neuron.Y)),
                            new Point(converter.Ox(neighbour.X), converter.Oy(neighbour.Y))
                        );
                    }
                }
            }
        }
    }
}