using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculatorProject
{
    public partial class Calculator : Form
    {
        Double resultValue =  0;
        String operationPerFormed = "";
        bool isOperationPerFormed = false;
        bool mode = false;
        public Calculator()
        {
            InitializeComponent();
          
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
             
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if((richTextBox1.Text == "0") || (isOperationPerFormed))
                richTextBox1.Clear();
            
            isOperationPerFormed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!richTextBox1.Text.Contains("."))
                    richTextBox1.Text = richTextBox1.Text + button.Text;
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + button.Text;
            }
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                buttonEqual.PerformClick();
                operationPerFormed = button.Text;
                resultValue = Double.Parse(richTextBox1.Text);
                lableCurrentOperation.Text = resultValue + " " + operationPerFormed;
                isOperationPerFormed = true;
            }else
            {
                operationPerFormed = button.Text;
                resultValue = Double.Parse(richTextBox1.Text);
                lableCurrentOperation.Text = resultValue + " " + operationPerFormed;
                isOperationPerFormed = true;

            }

           
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {

            if (richTextBox1.Text.Length > 1)
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
            }
            else
            {
                richTextBox1.Text = "0";
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "0";
            resultValue =  0;
            operationPerFormed = "";
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerFormed)
            {
                case "+":
                    richTextBox1.Text = (resultValue + Double.Parse(richTextBox1.Text)).ToString();
                    break;

                case "-":
                    richTextBox1.Text = (resultValue - Double.Parse(richTextBox1.Text)).ToString();
                    break;

                case "x":
                    richTextBox1.Text = (resultValue * Double.Parse(richTextBox1.Text)).ToString();
                    break;

                case ":":
                    richTextBox1.Text = (resultValue / Double.Parse(richTextBox1.Text)).ToString();
                    break;

                default:
                    break;
            }
            resultValue = Double.Parse(richTextBox1.Text);
            lableCurrentOperation.Text = "";
        }

        private void buttonDarkMode_Click(object sender, EventArgs e)
        {
         
            if(mode == false)
            {
                mode = true;
                BackColor = Color.Black;
               buttonDarkMode.Text = "Light Mode";

            }
            else
            {
                mode = false;
                BackColor = Color.White;
                buttonDarkMode.Text = "Dark Mode";
            }

        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.M)
            {
                if (mode == false)
                {
                    mode = true;
                    BackColor = Color.Black;
                    buttonDarkMode.Text = "Light Mode";

                }
                else
                {
                    mode = false;
                    BackColor = Color.White;
                    buttonDarkMode.Text = "Dark Mode";
                }
            }
        }

        private void buttonDarkMode_MouseHover(object sender, EventArgs e)
        {

        }       
    }
}
