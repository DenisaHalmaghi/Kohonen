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
        List<(int X, int Y, Color color)> points;
        Neuron[,] neurons;
        int currentEpoch = 0;
        const int NR_NEURONS = 11;
        const int TOTAL_EPOCHS = 10;
        const double ALPHA_THRESHOLD = 0.001;
        double alpha;
        double V;

        private void updateAlpha()
        {
            double power = (double)currentEpoch / TOTAL_EPOCHS;
            alpha = 0.7 * Math.Pow(Math.E, -power);
        }

        private void updateV()
        {
            double power = (double)currentEpoch / TOTAL_EPOCHS;
            alpha = 6.1 * Math.Pow(Math.E, -power);
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

                this.Refresh();
                await Task.Delay(1000);
                this.Text = "Epoca " + currentEpoch;

                currentEpoch++;

            } while (alpha > ALPHA_THRESHOLD);
        }

        private void moveNeurons()
        {
            throw new NotImplementedException();
        }
    }
}
