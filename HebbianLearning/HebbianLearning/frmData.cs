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
    public partial class frmData : Form
    {
        public HebbRuleNeuralNetwork network;
        public frmData(HebbRuleNeuralNetwork n)
        {
            InitializeComponent();
            network = n;
            drawLabel();
        }

        public void drawLabel()
        {
            lblData.Text = network.printWeights();
        }
    }
}
