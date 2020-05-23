using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        
        double numOne = 0;
        double numTwo = 0;
        string operation;
        string secondOperation;
        string expression;
        bool scifiMode = false;
        bool operationInserted = false;
        int lengthOfNumOne = 0;
        const int widthSmall = 407;
        const int widthLarge = 580;
        const int loc1 = 370;
        const int loc2 = 455;
        const int loc3 = 456;
        const int loc4 = 541;

        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            this.BackColor = Color.Silver;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;


            Display.Font = new Font("Digital-7", 22f);
            Display.ForeColor = Color.LimeGreen;
            Display.BackColor = Color.Black;
            buttonSign.Font = new Font("Digital-7", 22f);
            buttonDecimal.Font = new Font("Digital-7", 22f);
            buttonScfi.Font = new Font("Digital-7", 22f);
            buttonAdd.Font = new Font("Digital-7", 22f);
            buttonMultiply.Font = new Font("Digital-7", 22f);
            buttonDivide.Font = new Font("Digital-7", 22f);
            buttonResult.Font = new Font("Digital-7", 22f);
            buttonClear.Font = new Font("Digital-7", 22f);
            buttonBackspace.Font = new Font("Digital-7", 22f);
            buttonSubstract.Font = new Font("Digital-7", 22f);
            buttonPower.Font = new Font("Digital-7", 22f);
            buttonPow2.Font = new Font("Digital-7", 22f);
            buttonPow3.Font = new Font("Digital-7", 22f);
            buttonSin.Font = new Font("Digital-7", 22f);
            buttonCos.Font = new Font("Digital-7", 22f);
            buttonTg.Font = new Font("Digital-7", 22f);
            buttonSqrt.Font = new Font("Digital-7", 22f);
            labelSc.Font = new Font("Digital-7", 22f);

            Display.Text = "0";
            Display.TabStop = false;

            string buttonName = null;
            Button button = null;
            for(int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[ buttonName];
                button.Text = i.ToString();
                button.BackColor = Color.DarkSlateGray;
                button.Font = new Font("Digital-7", 22f);
                button.ForeColor = Color.White;
            }
           
        }

        private void Button_Ckick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
           

        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(",");

            if (!Display.Text.Contains(","))
            {
               if(Display.Text == string.Empty)
                {
                    Display.Text += "0,";
                }

                else 
                {
                    Display.Text += ",";
                }
            }
         
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);

            }
            else
            {
                s = "0";
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try 
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = number.ToString();
            }
            catch
            {

            }
           
        }

        

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!operationInserted)
            {
                lengthOfNumOne = Display.Text.Length;
                numOne = Convert.ToDouble(Display.Text);
                if (button.Text == "Sqrt")
                {
                    Display.Text = Math.Sqrt(numOne).ToString();
                    return;
                }
                if (button.Text == "x^2")
                {
                    Display.Text = Math.Pow(numOne, 2).ToString();
                    return;
                }
                if (button.Text == "x^3")
                {
                    Display.Text = Math.Pow(numOne, 3).ToString();
                    return;
                }
                if (button.Text == "sin")
                {
                    Display.Text = Math.Sin((numOne * (Math.PI)) / 180).ToString();
                    return;
                }
                if (button.Text == "cos")
                {
                    Display.Text = Math.Cos((numOne * (Math.PI)) / 180).ToString();
                    return;
                }ž
                if (button.Text == "tg")
                {
                    Display.Text = Math.Tan((numOne * (Math.PI)) / 180).ToString();
                    return;
                }
                operation = button.Text;
                Display.Text += operation;
                operationInserted = true;
            }
            else
            {
                secondOperation = button.Text;
                expression = Display.Text.Substring(lengthOfNumOne + 1, Display.Text.Length - lengthOfNumOne - 1);
                numTwo = Convert.ToDouble(expression);

                if (operation == "+")
                {
                    numOne = numOne + numTwo;
                }
                else if (operation == "-")
                {
                    numOne = numOne - numTwo;
                }
                else if (operation == "x")
                {
                    numOne = numOne * numTwo;
                }
                else if (operation == "/")
                {
                    numOne = numOne / numTwo;
                }
                else if (operation == "^")
                {
                    numOne = Math.Pow(numOne, numTwo);
                }
                /* else if (firstOperation == "Sqrt" )
                 {
                     numOne = Math.Sqrt(numOne);
                     return;
                 }*/

                Display.Text = numOne.ToString();
                lengthOfNumOne = Display.Text.Length;
                Display.Text += secondOperation;
                operation = secondOperation;
            }

        }
        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0;
            expression = Display.Text.Substring(lengthOfNumOne + 1, Display.Text.Length - lengthOfNumOne - 1);
            numTwo = Convert.ToDouble(expression);
            if (operation == "+")
            {
                result = numOne + numTwo;
            }
            else if (operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "x")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^")
            {
                result = Math.Pow(numOne, numTwo);
            }
            Display.Text = result.ToString();
            operationInserted = false;
        }

        private void buttonScfi_Click(object sender, EventArgs e)
        {
            if(scifiMode)
            {
                this.Width = widthSmall;
                buttonPower.Location = new Point(loc2, buttonPower.Location.Y);
                buttonPow3.Location = new Point(loc2, buttonPow3.Location.Y);
                buttonSin.Location = new Point(loc2, buttonSin.Location.Y);
                buttonCos.Location = new Point(loc2, buttonCos.Location.Y);
                buttonTg.Location = new Point(loc2, buttonTg.Location.Y);
                buttonPow2.Location = new Point(loc4, buttonPow2.Location.Y);
                buttonSqrt.Location = new Point(loc4, buttonSqrt.Location.Y);
            }
            else
            {
                this.Width = widthLarge;
                buttonPower.Location = new Point(loc1, buttonPower.Location.Y);
                buttonPow3.Location = new Point(loc1, buttonPow3.Location.Y);
                buttonSin.Location = new Point(loc1, buttonSin.Location.Y);
                buttonCos.Location = new Point(loc1, buttonCos.Location.Y);
                buttonTg.Location = new Point(loc1, buttonTg.Location.Y);
                buttonPow2.Location = new Point(loc3, buttonPow2.Location.Y);
                buttonSqrt.Location = new Point(loc3, buttonSqrt.Location.Y);

            }
            scifiMode = !scifiMode;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            numOne = 0;
            numTwo = 0;
        }
    }
}
