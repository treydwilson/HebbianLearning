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
    public partial class frmMain : Form
    {
        public bool selectedInput = true;
        public int selectedCell = 0;
        public HebbRuleNeuralNetwork network = new HebbRuleNeuralNetwork(16);
        public frmMain()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = System.Drawing.Brushes.Black;
            Pen pen = new Pen(brush);
            Font font = new Font(FontFamily.GenericSerif, 10);
            e.Graphics.DrawString("Inputs", font, brush, new PointF(20,20));
            e.Graphics.DrawString("Outputs", font, brush, new PointF(350, 20));
            e.Graphics.DrawString("Weights", font, brush, new PointF(475, 20));
            Point p;
            if (selectedInput)
                p = new Point(45, 57 + (25 * selectedCell));
            else
                p = new Point(375, 57 + (25 * selectedCell));

            for (int i = 0; i < 16; i++)
            {
                e.Graphics.DrawRectangle(pen, 30, 50 + (25 * i), 15, 15);
                e.Graphics.DrawString(i.ToString(), font, brush, new PointF(5, 50 + (25 * i)));
                e.Graphics.DrawEllipse(pen, 375, 50 + (25 * i), 15, 15);
                e.Graphics.DrawString(i.ToString(), font, brush, new PointF(400, 50 + (25 * i)));
                

                //Draw the weights for each input or output
                if (selectedInput)
                {
                    //Input cells need to be written
                    e.Graphics.DrawString(network.getWeight(selectedCell, i).ToString(), font, brush, new PointF(490, 50 + (25 * i)));
                    e.Graphics.DrawLine(pen, p, new Point(375, 57 + (25 * i)));
                }
                else
                {
                    //Output cells need to be written
                    e.Graphics.DrawString(network.getWeight(i, selectedCell).ToString(), font, brush, new PointF(490, 50 + (25 * i)));
                    e.Graphics.DrawLine(pen, p, new Point(45, 57 + (25 * i)));
                }
            }
        }

        private void txtPatternTest_Click(object sender, EventArgs e)
        {
            TrainPattern trainPattern = new TrainPattern(network);
            trainPattern.Show();
            trainPattern.FormClosed += new FormClosedEventHandler(testHebb_FormClosed);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            TestHebb testHebb = new TestHebb(network);
            testHebb.Show();
            testHebb.FormClosed += new FormClosedEventHandler(testHebb_FormClosed);
        }

        void testHebb_FormClosed(object sender, FormClosedEventArgs e)
        {
            Refresh();   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedInput = (comboBox1.SelectedIndex == 0);
            Refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCell = comboBox2.SelectedIndex;
            Refresh();
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            frmData dataForm = new frmData(network);
            dataForm.Show();
        }
    }
}
