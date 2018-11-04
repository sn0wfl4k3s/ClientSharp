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
    public partial class Form1 : Form
    {
        Client client;
        private string nickname;

        public Form1(string host, int port, string nickname) {

            this.nickname = nickname;

            InitializeComponent();
            try {
                client = new Client(host, port);
                new System.Threading.Thread(() => {
                    while(true) {
                        richTextBox1.Text += "\n  "+ client.Recv();
                        Rolar();
                    }
                }).Start();
            } catch (Exception e) {
                richTextBox1.Text = "\n  < Nenhuma Conexão >";
                client = null;
            }
        }

        ~Form1() {
            client.Send("sair");
        }
        private void button1_Click(object sender, EventArgs e) {
            Enviar();
        }
        private void Enviar () {
            if (client != null) {
                string message = textBox1.Text;
                client.Send(this.nickname +": "+ message);
                richTextBox1.Text += "\n  Eu: " + message;
            }
            textBox1.Text = "";
            FocusText();

            Rolar();
        }
        private void Rolar () {
            try
            {
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            } catch (Exception e) {}
        }
        private void FocusText() {
            textBox1.Focus();
        }
        private void label1_Click(object sender, EventArgs e) {}
        private void Form1_Load(object sender, EventArgs e) {FocusText();}
        private void groupBox1_Enter(object sender, EventArgs e){}
        private void label1_Click_1(object sender, EventArgs e){}
        private void textBox2_KeyDown(object sender, KeyEventArgs e) {}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                Enviar();
            }
        }

        private void richTextBox1_VScroll(object sender, EventArgs e) {}
        private void menuToolStripMenuItem_Click(object sender, EventArgs e){}
        private void desenvolvedorToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Desenvolvedor: Eduardo Júnior\nQualquer problema, entrar em contato com email: ed.afram@gmail.com");
        }

        private void conectToToolStripMenuItem_Click(object sender, EventArgs e) {
            new Conection().Show();
            this.Hide();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {}
        private void versionToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Versão Beta: 1.0.0\nThanks for using!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                client.Send("sair");
            }
            catch (Exception ex) { }
            this.Close();
        }
    }
}
