using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bs
{
    public partial class Customizer : Form
    {
        public Customizer()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BSODcolor.BackColor = colorDialog1.Color;
            BSODcolor.ForeColor = colorDialog1.Color;
            BSODcolor.Refresh();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                int result = Int32.Parse(textBox7.Text);
                
            }
            catch (FormatException)
            {
                Application.Exit();
            }
            BsodForm form = new BsodForm(colorDialog1.Color, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text,Int32.Parse(textBox7.Text));
            
        }
    }
}
