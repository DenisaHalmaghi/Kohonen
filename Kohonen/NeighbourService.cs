using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kohonen
{
    class NeighbourService
    {
        private Neuron[,] neurons;

        public NeighbourService(Neuron[,] _neurons)
        {
            neurons = _neurons;
        }
        public void neighbours(Neuron neuron, int radius)
        {
            var neighbours = from x in Enumerable.Range(neuron.X - 1, radius)
                             from y in Enumerable.Range(neuron.Y - 1, radius)
                             where x >= 0 && y >= 0 && x < neurons.GetLength(0) && y < neurons.GetLength(1)
                             select new { x, y };
        }
    }
}
