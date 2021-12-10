using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kohonen
{
    public partial class Form1 : Form
    {
        List<Point> points;
        Neuron[,] neurons;
        int currentEpoch = 0;
        const int NR_NEURONS = 11;
        const int TOTAL_EPOCHS = 10;
        const double ALPHA_THRESHOLD = 0.001;
        double alpha;
        int V;

        private void updateAlpha()
        {
            double power = (double)currentEpoch / TOTAL_EPOCHS;
            alpha = 0.7 * Math.Pow(Math.E, -power);
        }

        private void updateV()
        {
            double power = (double)currentEpoch / TOTAL_EPOCHS;
            V = (int)(6.1 * Math.Pow(Math.E, -power));
        }

        public Form1()
        {
            InitializeComponent();
            points = (new PointsReader("puncte.txt")).readPoints();
            neurons = (new NeuronGenerator(NR_NEURONS)).generate();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var drawer = new PointsDrawer(e);
            drawer.draw(points);
            drawer.draw(neurons);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            do
            {
                updateAlpha();
                updateV();

                moveNeurons();

                Refresh();
                await Task.Delay(50);

                Text = "Epoca " + currentEpoch + ", alpha =" + alpha;
                currentEpoch++;

            } while (alpha > ALPHA_THRESHOLD);
        }

        private (int row, int column) getMostSimilarNeuronIndexes(Point point)
        {
            var similarityCalculator = new SimilarityCalculator();
            double bestSimilarity = Double.MaxValue;

            (int row, int col) mostSimilarNeuron = (0, 0);

            for (int i = 0; i < neurons.GetLength(0); i++)
            {
                for (int j = 0; j < neurons.GetLength(0); j++)
                {
                    var neuron = neurons[i, j];
                    var calculatedSimilarity = similarityCalculator.calculate(point, neuron);

                    if (calculatedSimilarity < bestSimilarity)
                    {
                        bestSimilarity = calculatedSimilarity;
                        mostSimilarNeuron = (i, j);
                    }
                }
            }

            return mostSimilarNeuron;
        }
        private void moveNeurons()
        {
            foreach (var point in points)
            {
                var mostSimilarNeuronIndexes = getMostSimilarNeuronIndexes(point);

                var neighbours = (new NeighbourService(neurons)).neighbours(mostSimilarNeuronIndexes, V);

                //update the position of all neighbour neurons INCLUDING the neuron itself
                foreach (var neighbour in neighbours)
                {
                    neighbour.moveTowards(point, alpha);
                }
            }
        }
    }
}
