using System.Windows.Forms;
using SosPruebaNUnit;

namespace SosProyect
{
    public partial class Form1 : Form
    {
        string resultado = "";
        string valorInput = "";
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Juego SOS";
            button1.Text = "Iniciar Juego";
            label2.Text = "Turno Jugador 3";
            label3.Text = "Turno Jugador 2";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox1.Text;
            resultado = Class1.insertLetter(textBox1.Text);
            if (resultado == "Letra inválida")
            {
                textBox1.Text = "";
                MessageBox.Show(resultado);
                textBox1.Focus();
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox2.Text;
            resultado = Class1.insertLetter(textBox2.Text);
            if (resultado == "Letra inválida")
            {
                textBox2.Text = "";
                MessageBox.Show(resultado);
                textBox1.Focus();
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox3.Text;
            resultado = Class1.insertLetter(textBox3.Text);
            if (resultado == "Letra inválida")
            {
                textBox3.Text = "";
                MessageBox.Show(resultado);
                textBox3.Focus();
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox4.Text;
            resultado = Class1.insertLetter(textBox4.Text);
            if (resultado == "Letra inválida")
            {
                textBox4.Text = "";
                MessageBox.Show(resultado);
                textBox4.Focus();
            }
            else
            {
                textBox4.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox5.Text;
            resultado = Class1.insertLetter(textBox5.Text);
            if (resultado == "Letra inválida")
            {
                textBox5.Text = "";
                MessageBox.Show(resultado);
                textBox5.Focus();
            }
            else
            {
                textBox5.Enabled = false;
            }
        }

        private void textBox6_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox6.Text;
            resultado = Class1.insertLetter(textBox6.Text);
            if (resultado == "Letra inválida")
            {
                textBox6.Text = "";
                MessageBox.Show(resultado);
                textBox6.Focus();
            }
            else
            {
                textBox6.Enabled = false;
            }
        }

        private void textBox7_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox7.Text;
            resultado = Class1.insertLetter(textBox7.Text);
            if (resultado == "Letra inválida")
            {
                textBox7.Text = "";
                MessageBox.Show(resultado);
                textBox7.Focus();
            }
            else
            {
                textBox7.Enabled = false;
            }
        }

        private void textBox8_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox8.Text;
            resultado = Class1.insertLetter(textBox8.Text);
            if (resultado == "Letra inválida")
            {
                textBox8.Text = "";
                MessageBox.Show(resultado);
                textBox8.Focus();
            }
            else
            {
                textBox8.Enabled = false;
            }
        }

        private void textBox9_TextChanged(object sender, System.EventArgs e)
        {
            valorInput = textBox9.Text;
            resultado = Class1.insertLetter(textBox9.Text);
            if (resultado == "Letra inválida")
            {
                textBox9.Text = "";
                MessageBox.Show(resultado);
                textBox9.Focus();
            }
            else
            {
                textBox9.Enabled = false;
            }
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
        }
        private void label1_Click(object sender, System.EventArgs e)
        {
        }

        private void label2_Click(object sender, System.EventArgs e)
        {
        }
        private void label3_Click(object sender, System.EventArgs e)
        {
        }
    }
}
