using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Barcode barcode = new Barcode();
            Color foreColor = Color.Black;
            Color backcolor = Color.Transparent;
            Image img = barcode.Encode(TYPE.UPCA, textBox1.Text, foreColor, backcolor, (int)(pictureBox1.Width*0.4), (int)(pictureBox1.Height*0.4));
            pictureBox1.Image = img;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                    MessageBox.Show("BARCODE SAVED SUCCESSFULLY", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
