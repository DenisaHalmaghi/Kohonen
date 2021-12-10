using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Kohonen
{
    class SimilarityCalculator
    {
        public double calculate(Point point, Neuron centroid)
        {
            var value = Math.Sqrt(Math.Pow(point.X - centroid.X, 2) + Math.Pow(point.Y - centroid.Y, 2));
            return value;
        }
    }
}
