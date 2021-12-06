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

        public void move((int X, int Y) point, int alpha)
        {
            X += alpha * point.X - X;
            Y += alpha * point.Y - Y;
        }

    }
}
