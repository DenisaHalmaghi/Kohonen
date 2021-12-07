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
        public List<Neuron> neighbours((int row, int column) matrixIndexes, int radius)
        {
            radius--;

            var neighbours = new List<Neuron>();

            var startRow = Math.Max(0, matrixIndexes.row - radius);
            var endRow = Math.Min(neurons.GetLength(0) - 1, matrixIndexes.row + radius);

            var startColumn = Math.Max(0, matrixIndexes.column - radius);
            var endColumn = Math.Min(neurons.GetLength(0) - 1, matrixIndexes.column + radius);


            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startColumn; j <= endColumn; j++)
                {
                    neighbours.Add(neurons[i, j]);
                }
            }

            return neighbours;
        }

        public List<Neuron> upperAndRightNeighbours((int row, int column) matrixIndexes)
        {
            var neighbours = new List<Neuron>();

            var startRow = Math.Max(0, matrixIndexes.row - 1);
            var endColumn = Math.Min(neurons.GetLength(0) - 1, matrixIndexes.column + 1);

            //upper neighbour
            neighbours.Add(neurons[startRow, matrixIndexes.column]);
            //right neighbour
            neighbours.Add(neurons[matrixIndexes.row, endColumn]);

            return neighbours;
        }
    }
}
