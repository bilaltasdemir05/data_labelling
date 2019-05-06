using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizZet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string Response { get; set; }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            comboBox1.SelectedItem = null;
        }
        private void isaretBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.SelectedItem == comboBox1.Items[6])
            {
                MessageBox.Show("Lütfen farklı bir işaret türü yazınız", "Hata");
            }
            else if (comboBox1.SelectedItem == null)
                MessageBox.Show("Lütfen bir işaret seçiniz", "Hata");
            else
            {
                Response = comboBox1.SelectedItem.ToString();
                Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != comboBox1.Items[6])
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }
    }
}
