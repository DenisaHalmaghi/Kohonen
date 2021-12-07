using System;
using System.Collections.Generic;
using System.Drawing;

namespace Kohonen
{
    class NeuronGenerator
    {
        int numberOfNeurons;

        public NeuronGenerator(int numberOfNeurons)
        {
            this.numberOfNeurons = numberOfNeurons;
        }

        public Neuron[,] generate()
        {
            var neurons = new Neuron[numberOfNeurons, numberOfNeurons];

            var step = 2 * Constants.MAX / (numberOfNeurons - 1);

            for (int i = 0; i < numberOfNeurons; i++)
            {
                for (int j = 0; j < numberOfNeurons; j++)
                {
                    var neuron = new Neuron(Constants.MIN + step * i, Constants.MIN + step * j);
                    neurons[i, j] = neuron;
                }
            }

            return neurons;
        }
    }
}
