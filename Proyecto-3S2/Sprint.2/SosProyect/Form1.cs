using System;
using System.Drawing;
using System.Windows.Forms;

namespace SosProyect
{
    public partial class Form1 : Form
    {
        string lastTurn = "Blue";
        string letterBlue = "S";
        string letterRed = "S";

        
        //ASIGNAMOS UN VALOR DE SALIDA PARA CADA COLOR

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            radioButton5.Checked = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, System.EventArgs e)
        {
        }
        

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
     
        }

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                letterRed = "S";
            }
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton2.Checked)
            {
                letterRed = "O";
            }
        }
        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton4.Checked)
            {
                letterBlue = "S";
            }
        }

        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton3.Checked)
            {
                letterBlue = "O";
            }
        }


        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //VALIDACIÓN PARA PERMITER SOLO NÚMEROS
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void groupBox1_Enter(object sender, System.EventArgs e)
        {
           
        }
        private void groupBox2_Enter(object sender, System.EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, System.EventArgs e)
        {
            int cantidad;

            if (!int.TryParse(textBox10.Text, out cantidad))
            {
                return;
            }

            deleteTextBox();

            // CREAMOS LOS TEXTBOX Y LO AGRAGAMOS AL PANEL2
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    panel2.Controls.Add(createTextBox(i,j));
                }
            }
        }
        private void deleteTextBox()
        {
            for (int i = panel2.Controls.Count - 1; i >= 0; i--)
            {
                if (panel2.Controls[i] is TextBox)
                {
                    panel2.Controls.RemoveAt(i);
                }
            }
        }
        private TextBox createTextBox(int i, int j)
        {
            TextBox textBox = new TextBox();
            textBox.Margin = new Padding(0);
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.MaxLength = 1;
            textBox.Size = new Size(30, 30);
            textBox.Name = "textBox" + i.ToString() + "-" + j.ToString();
            textBox.Location = new Point((j * textBox.Width), (i * textBox.Height));

            textBox.Enter += new EventHandler(delegate (object sender2, System.EventArgs e2)
            {
                textBox.Text = getTurn() == "Red" ? letterRed : letterBlue;

                //CAMBIAR TURNO AUMTOMATICAMENTE AL SELECCIONAR SU CAMPO
                changeTurn();
            });

            return textBox;
        }
        public string getTurn()
        {
            return lastTurn;
        }   
        public void changeTurn()
        {
            lastTurn = getTurn() == "Red" ? "Blue" : "Red";
            button1.Text = $"it's the {lastTurn} player's turn";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "it's the Blue player's turn";
        }
    }
}
