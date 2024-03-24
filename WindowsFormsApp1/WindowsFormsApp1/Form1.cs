using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.num1.ToString();
            textBox2.Text = Properties.Settings.Default.num2.ToString();
            textBox3.Text = Properties.Settings.Default.num3.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1, num2, num3;
            try
            {
                num1 = int.Parse(this.textBox1.Text);
                num2 = int.Parse(this.textBox2.Text);
                num3 = int.Parse(this.textBox3.Text);
            }
            catch (FormatException)
            {
                return;
            }

            Properties.Settings.Default.num1 = num1;
            Properties.Settings.Default.num2 = num2;
            Properties.Settings.Default.num3 = num3;           
            Properties.Settings.Default.Save();

            MessageBox.Show(Logic.FindMaxMin(num1, num2,num3), "Ответ");
        }
    }


    public class Logic
    {
        public static string FindMaxMin(int number1, int number2, int number3)
        {
            string outMessage = "";
            if (number1 >= number2)
            {
                if (number1 >= number3)
                {
                    if (number2 >= number3)
                    {
                        outMessage = "Самое большое число - " + number1 + "\nСреднее число - " + number2 + "\nСамое маленькое число - " + number3;
                    }
                    else outMessage = "Самое большое число - " + number1 + "\nСреднее число - " + number3 + "\nСамое маленькое число - " + number2;
                }
                else outMessage = "Самое большое число - " + number3 + "\nСреднее число - " + number1 + "\nСамое маленькое число - " + number2;
            }
            else if (number2 >= number3)
            {
                if (number1 >= number3)
                {
                    outMessage = "Самое большое число - " + number2 + "\nСреднее число - " + number1 + "\nСамое маленькое число - " + number3;
                }
                else outMessage = "Самое большое число - " + number2 + "\nСреднее число - " + number3 + "\nСамое маленькое число - " + number1;
            }
            else outMessage = "Самое большое число - " + number3 + "\nСреднее число - " + number2 + "\nСамое маленькое число - " + number1;
            return outMessage;
        }
    }
}


