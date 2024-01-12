using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private double currentValue = 0;
        private string currentOperator = "";
        private bool isNewValue = true;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Value_Click(object sender, EventArgs e)
        {
            
            if (isNewValue)
            {
                tb_Numbers.Text = "";
                isNewValue = false;
            }

            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            tb_Numbers.Text += button.Text;
            tb_Calculations.Text += button.Text;
        }
       

        private void btn_Operation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button OpBtn = (System.Windows.Forms.Button)sender;
            string NewOperation = OpBtn.Text;
            currentValue = double.Parse(tb_Numbers.Text);
            currentOperator = NewOperation;
            isNewValue = true;
            
            tb_Numbers.Text += OpBtn.Text;
            tb_Calculations.Text += OpBtn.Text;

        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
           Calculate();
           isNewValue = true;
           currentOperator = "";
        }

            private void clearButton_Click(object sender, EventArgs e)
            {
               tb_Numbers.Text = "0";
               currentValue = 0;
               currentOperator = "";
               isNewValue = true;
               tb_Calculations.Text="";
            }

            private void Calculate()
            {
               double newValue = double.Parse(tb_Numbers.Text);

               switch (currentOperator)
               {
                   case "+":
                       currentValue += newValue;
                       break;
                   case "-":
                       currentValue -= newValue;
                       break;
                   case "x":
                       currentValue *= newValue;
                       break;
                   case "/":
                       if (newValue != 0)
                       {
                           currentValue /= newValue;
                       }
                       else
                       {
                           MessageBox.Show("Cannot divide by zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                       break;
                    
            }
            tb_Calculations.Text += '=' + currentValue.ToString();
                tb_Numbers.Text = currentValue.ToString();
                }
                }
    
}
