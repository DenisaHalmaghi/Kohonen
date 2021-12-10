using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Kohonen
{
    class Neuron
    {
        public int X, Y;

        public Neuron(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void moveTowards(Point point, double alpha)
        {
            X = (int)(X + alpha * (point.X - X));
            Y = (int)(Y + alpha * (point.Y - Y));
        }

    }
}
