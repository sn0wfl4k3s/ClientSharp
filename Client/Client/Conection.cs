using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Conection : Form
    {
        public Conection()
        {
            InitializeComponent();
        }
        private void Enviar () {
            try
            {
                string
                    nickname = textBox3.Text,
                    host = textBox1.Text;
                int port = int.Parse(textBox2.Text);
                new Form1(host.Equals("localhost")?"127.0.0.1":host, 
                    port, nickname).Show();
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            Enviar();
        }
    }
}
