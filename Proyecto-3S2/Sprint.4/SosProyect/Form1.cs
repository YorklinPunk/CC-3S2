using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SosProyect
{
    public partial class Form1 : Form
    {
        string lastTurn = "Blue";
        string letterBlue = "S";
        string letterRed = "S";
        int totalMovs = 0;
        int totalEnd = 1;
        int contBlue = 0;
        int contRed = 0;
        int[][] validPointsToS = new int[8][];
        int[][] validPointsToO = new int[4][];

        int[][] auxValidPoints = new int[8][];

        bool blueComputer = false;
        bool redComputer = false;

        //ASIGNAMOS UN VALOR DE SALIDA PARA CADA COLOR

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            radioButton5.Checked = true;
            radioButton7.Checked = true;
            radioButton9.Checked = true;

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
        private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton3.Checked)
            {
                letterBlue = "O";
            }
        }
        private void radioButton4_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton4.Checked)
            {
                letterBlue = "S";
            }
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // EL JUEGO TERMINARÁ CUANDO SE ENCUENTRE LA PRIMERA PALABRA S-O-S
            if (radioButton5.Checked)
            {
                totalEnd = 1;
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
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
            //VALIDACION PARA EVITAR EL ESPACIO VACIO EN EL TEXTBOX
            if (!int.TryParse(textBox10.Text, out cantidad))
            {
                return;
            }
            if (cantidad < 3)
            {
                textBox10.Text = "";
                MessageBox.Show("Ingresó un número inválido de tablero, Intente otra vez");
                return;
            }

            deleteTextBox();
            totalMovs = 0;
            redComputer = radioButton10.Checked;
            blueComputer = radioButton8.Checked;
            // CREAMOS LOS TEXTBOX Y LO AGRAGAMOS AL PANEL2
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    panel2.Controls.Add(createTextBox(i,j));
                }
            }
            //INICIALIZAR EN CASO EL AZUL SEA COMPUTADORA
            if (getTurn() == "Blue" && blueComputer)
            {
                //EJECUTAR FUNCION PARA SELECCIONAR ALEATORIAMENTE
                findEmptyTextBox();
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
            textBox.Tag = i * int.Parse(textBox10.Text) + j + 1;
            textBox.Location = new Point((j * textBox.Width), (i * textBox.Height));
            EventHandler enterEventHandler = null;
            enterEventHandler = (sender, e) =>
            {
                textBox.Text = getTurn() == "Red" ? (redComputer ? getRandomLetter() : letterRed) : (blueComputer ? getRandomLetter() : letterBlue);
                searchSOSWithLetter(textBox.Text, i, j);
                //CAMBIAR TURNO AUMTOMATICAMENTE AL SELECCIONAR SU CAMPO
                //ANTES DE TERMINAR EL TURNO VALIDAR SI HAY GANADOR EN CASO DE JUEGO SIMPLE
                totalMovs += 1;
                //verifyEnd(); //DISABLEAR LOS TEXTBOX
                changeTurn();
                //QUITAMOS EL EVENTO ENTER PARA NO SOBREESCRIBIR LA NUEVA LETRA
                textBox.Enter -= enterEventHandler;
            };
            textBox.Enter += enterEventHandler;

            return textBox;
        }
        private string getRandomLetter()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);  // Genera un número aleatorio entre 0 y 1

            if (randomNumber == 0)
            {
                return "S";
            }
            else
            {
                return "O";
            }
        }
        public void verifyEnd()
        {
            int contTurno = getTurn() == "Red" ? contRed : contBlue;
            //EL JUEGO ES SIMPLE
            if(radioButton5.Checked)
            {
                if (contTurno == totalEnd)
                {
                    MessageBox.Show($"{getTurn()} player won..!!");
                    redComputer = false;
                    blueComputer = false;
                }
            }
            //EL JUEGO ES GENERAL
            else
            {
                if(totalMovs == int.Parse(textBox10.Text) * int.Parse(textBox10.Text))
                {
                    if(contRed > contBlue)
                    {
                        MessageBox.Show($"Red player won..!! Red: {contRed} Blue: {contBlue}");
                    }
                    else if (contBlue > contRed)
                    {
                        MessageBox.Show($"Blue player won..!! Red: {contBlue} Blue: {contRed}");
                    }
                    else
                    {
                        MessageBox.Show($"Draw..!! Red: {contBlue} Blue: {contRed}");
                    }
                }
            }
            
        }
        public string getTurn()
        {
            return lastTurn;
        }   
        public void changeTurn()
        {
            lastTurn = getTurn() == "Red" ? "Blue" : "Red";
            //VALIDAR CUANDO ES COMPUTER O HUMAN
            if(getTurn() == "Red" && redComputer)
            {
                //EJECUTAR FUNCION PARA SELECCIONAR ALEATORIAMENTE
                findEmptyTextBox();
            }
            else if(getTurn() == "Blue" && blueComputer)
            {
                 //EJECUTAR FUNCION PARA SELECCIONAR ALEATORIAMENTE
                 findEmptyTextBox();
            }

            button1.Text = $"it's the {lastTurn} player's turn";
        }
        public void findEmptyTextBox()
        {
            TextBox selectedTextBox;
            List<TextBox> emptyTextBoxes = panel2.Controls.OfType<TextBox>().Where(tb => string.IsNullOrEmpty(tb.Text)).ToList();
            if (emptyTextBoxes.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, emptyTextBoxes.Count);
                selectedTextBox = emptyTextBoxes[randomIndex];
                selectedTextBox.Focus();
            }
        }
        public void searchSOSWithLetter(string letter ,int i, int j)
        {
            if (letter == "S")
            {
                createValidPositionsS(i, j);
            }
            else
            {
                createValidPositionsO(i, j);
            }

            int limit = letter == "S" ? 8 : 4;
            auxValidPoints = new int[limit][];

            Array.Copy(letter == "S" ? validPointsToS : validPointsToO, auxValidPoints, limit);

            for (int k = 0; k < auxValidPoints.Length; k++)
            {
                //BUSCAMOS EL TEXTBOX EN EL PANEL Y LO INDENTIFICAMOS POR SU TAG QUE EN ESTE CASO
                //ES SU POSICIÓN EN LA TABLA DEL PANEL
                int a = auxValidPoints[k][0];
                int b = auxValidPoints[k][1];
                int c = auxValidPoints[k][2];
                if (a < 0 || b < 0 || c < 0)
                {
                    //SI ENCUENTRA UN POSICION NO VÁLIDA SIMPLEMENTE NO BUSCA SU CONTENIDO
                    continue;
                }

                TextBox textBoxS1 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == a);
                TextBox textBoxO = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == b);
                TextBox textBoxS2 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == c);


                if (textBoxS1.Text == "S" && textBoxO.Text == "O" && textBoxS2.Text == "S")
                {
                    changeColorTextBox(textBoxS1);
                    changeColorTextBox(textBoxO);
                    changeColorTextBox(textBoxS2);

                    MessageBox.Show("Formaste un SOS.");
                    if (getTurn() == "Red")
                    {
                        contRed += 1;
                    }
                    else
                    {
                        contBlue += 1;
                    }
                    verifyEnd();
                }
            }
            auxValidPoints = null;
        }
        /*
        public bool searchSOSWithLetterS(int i ,int j)
        {
            createValidPositionsS(i, j);
            for (int k = 0; k < validPointsToS.Length; k++)
            {
                //BUSCAMOS EL TEXTBOX EN EL PANEL Y LO INDENTIFICAMOS POR SU TAG QUE EN ESTE CASO
                //ES SU POSICIÓN EN LA TABLA DEL PANEL
                int a = validPointsToS[k][0];
                int b = validPointsToS[k][1];
                int c = validPointsToS[k][2];
                if (a < 0 || b < 0 || c < 0)
                {
                    //SI ENCUENTRA UN POSICION NO VÁLIDA SIMPLEMENTE NO BUSCA SU CONTENIDO
                    continue;
                }

                TextBox textBoxS1 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == a);
                TextBox textBoxO = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == b);
                TextBox textBoxS2 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == c);


                if (textBoxS1.Text == "S" && textBoxO.Text == "O" && textBoxS2.Text == "S")
                {
                    changeColorTextBox(textBoxS1);
                    changeColorTextBox(textBoxO);
                    changeColorTextBox(textBoxS2);

                    MessageBox.Show("Formaste un SOS.");
                    return true;
                }
            }
            return false;
        }
        public bool searchSOSWithLetterO(int i, int j)
        {
            createValidPositionsO(i, j);
            for (int k = 0; k < validPointsToO.Length; k++)
            {
                //BUSCAMOS EL TEXTBOX EN EL PANEL Y LO INDENTIFICAMOS POR SU TAG QUE EN ESTE CASO
                //ES SU POSICIÓN EN LA TABLA DEL PANEL
                int a = validPointsToO[k][0];
                int b = validPointsToO[k][1];
                int c = validPointsToO[k][2];
                if (a < 0 || b < 0 || c < 0)
                {
                    //SI ENCUENTRA UN POSICION NO VÁLIDA SIMPLEMENTE NO BUSCA SU CONTENIDO
                    continue;
                }

                TextBox textBoxS1 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == a);
                TextBox textBoxO = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == b);
                TextBox textBoxS2 = panel2.Controls.OfType<TextBox>().FirstOrDefault(textBox => textBox.Tag != null && (int)textBox.Tag == c);

                if (textBoxS1.Text == "S" && textBoxO.Text == "O" && textBoxS2.Text == "S")
                {
                    Font boldFont = new Font(textBoxS1.Font, FontStyle.Bold);

                    textBoxS1.Font = boldFont;
                    textBoxO.Font = boldFont;
                    textBoxS2.Font = boldFont;

                    textBoxS1.ForeColor = getTurn() == "Red" ? Color.Red : Color.Blue;
                    textBoxO.ForeColor = getTurn() == "Red" ? Color.Red : Color.Blue;
                    textBoxS2.ForeColor = getTurn() == "Red" ? Color.Red : Color.Blue;

                    MessageBox.Show("Formaste un SOS.");
                    return true;
                }
            }
            return false;

        }
        */
        public void createValidPositionsS(int i, int j)
        {
            //NECESITAMOS VALIRDAR CUANDO I Y J SON MENOIRES QUE 2
            validPointsToS[0] = new int[] { getTablePosition(i - 2 , j - 2), getTablePosition(i - 1 , j - 1), getTablePosition(i , j)};
            validPointsToS[1] = new int[] { getTablePosition(i - 2 , j), getTablePosition(i - 1 , j), getTablePosition(i , j)};
            validPointsToS[2] = new int[] { getTablePosition(i - 2 , j + 2), getTablePosition(i - 1 , j + 1), getTablePosition(i , j)};
            validPointsToS[3] = new int[] { getTablePosition(i , j - 2), getTablePosition(i , j - 1), getTablePosition(i, j)};
            validPointsToS[4] = new int[] { getTablePosition(i , j + 2), getTablePosition(i , j + 1), getTablePosition(i, j)};
            validPointsToS[5] = new int[] { getTablePosition(i + 2 , j - 2), getTablePosition(i + 1 , j - 1), getTablePosition(i , j)};
            validPointsToS[6] = new int[] { getTablePosition(i + 2 , j), getTablePosition(i + 1 , j), getTablePosition(i , j)};
            validPointsToS[7] = new int[] { getTablePosition(i + 2 , j + 2), getTablePosition(i + 1 , j - 1 ), getTablePosition(i , j)};
        }
        public void createValidPositionsO(int i, int j)
        {
            validPointsToO[0] = new int[] { getTablePosition(i - 1, j - 1), getTablePosition(i , j ), getTablePosition(i + 1, j + 1) };
            validPointsToO[1] = new int[] { getTablePosition(i - 1, j), getTablePosition(i, j), getTablePosition(i + 1, j) };
            validPointsToO[2] = new int[] { getTablePosition(i - 1, j + 1), getTablePosition(i, j), getTablePosition(i + 1, j - 1) };
            validPointsToO[3] = new int[] { getTablePosition(i, j - 1), getTablePosition(i, j), getTablePosition(i, j + 1) };
        }
        public int getTablePosition(int i, int j)
        {
            int n = int.Parse(textBox10.Text);
            //EXCLUIMOS LOS VALORES QUE SOBREPASAN LA TABLA Y LAS IDENTIFICAMOS CON -1
            if (i < 0 || j < 0 || i + 1 > n || j + 1 > n)
            {
                return -1;
            }
            int position = i * n + j + 1;
            return position;
        }
        public void changeColorTextBox(TextBox textBox)
        {
            Font boldFont = new Font(textBox.Font, FontStyle.Bold);
            textBox.Font = boldFont;

            Color textColor = textBox.ForeColor;

            if(textColor.Name == "Red" && getTurn() == "Red")
            {
                textBox.ForeColor = Color.Red;
            }
            else if (textColor.Name == "Blue" && getTurn() == "Blue")
            {
                textBox.ForeColor = Color.Blue;
            }
            else if((textColor.Name == "Blue" || textColor.Name == "Violet") && getTurn() == "Red" || (textColor.Name == "Red" || textColor.Name == "Violet") && getTurn() == "Blue")
            {
                textBox.ForeColor = Color.Violet;
            }
            else
            {
                textBox.ForeColor = getTurn() == "Red" ? Color.Red : Color.Blue;
            }
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

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                blueComputer = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                blueComputer = true;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                redComputer = false;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                redComputer = true;
            }
        }
    }
}
