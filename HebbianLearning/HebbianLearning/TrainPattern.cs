using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HebbianLearning
{
    public partial class TrainPattern : Form
    {
        public bool[] clicked;
        private HebbRuleNeuralNetwork network;
        public TrainPattern(HebbRuleNeuralNetwork n)
        {
            InitializeComponent();
            clicked = new bool[16];
            for (int i = 0; i < 16; i++)
                clicked[i] = false;
            network = n;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = System.Drawing.Brushes.Gray;
            Pen pen = new Pen(System.Drawing.Color.Black);
            Font font = new Font(FontFamily.GenericSerif, 10);
            e.Graphics.DrawLine(pen, new Point(0,0), new Point(0,74));
            e.Graphics.DrawLine(pen, new Point(0,74), new Point(74,74));
            e.Graphics.DrawLine(pen, new Point(74,74), new Point (74,0));
            e.Graphics.DrawLine(pen, new Point(74, 0), new Point(0, 0));
            int number = int.Parse(((PictureBox)sender).Name.Substring(10));
            if (clicked[number - 1])
                e.Graphics.FillRectangle(brush, 1, 1, 73, 73);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int number = int.Parse(((PictureBox)sender).Name.Substring(10));
            clicked[number - 1] = !clicked[number - 1];
            this.Refresh();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            int[] list = new int[16];
            for(int i = 0; i <16; i++)
                list[i] = clicked[i] ? -1 : 1;
            network.definePattern(list);
            network.adjustWeights();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
                clicked[i] = false;
            Refresh();
        }
    }
}
