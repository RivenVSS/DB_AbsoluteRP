using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNS30
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = BigDateAbsolute.Properties.Settings.Default.Log;
            textBox2.Text = BigDateAbsolute.Properties.Settings.Default.BNS;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigDateAbsolute.Properties.Settings.Default.Log = textBox1.Text;
            BigDateAbsolute.Properties.Settings.Default.BNS = textBox2.Text;
            BigDateAbsolute.Properties.Settings.Default.Save();
        }
    }
}
