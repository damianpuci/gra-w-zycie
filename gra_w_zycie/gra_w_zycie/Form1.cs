using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;







namespace gra_w_zycie
{

    



    public partial class Form1 : Form
    {
        int method(int a, int b, int c, int n)
        {

            int r;
            int[] arr = new int[64];
            int temp = n;

            for (int i = 0; i < 64; i++)
            {
                arr[i] = 0;
            }
            int j = 0;
            while (temp != 0)
            {
                r = temp % 2;
                arr[j++] = r;
                temp /= 2;
            }



            if (a == 1 && b == 1 && c == 1)
            {
                return arr[7];
            }
            if (a == 1 && b == 1 && c == 0)
            {
                return arr[6];
            }
            if (a == 1 && b == 0 && c == 1)
            {
                return arr[5];
            }
            if (a == 1 && b == 0 && c == 0)
            {
                return arr[4];
            }
            if (a == 0 && b == 1 && c == 1)
            {
                return arr[3];
            }
            if (a == 0 && b == 1 && c == 0)
            {
                return arr[2];
            }
            if (a == 0 && b == 0 && c == 1)
            {
                return arr[1];
            }
            if (a == 0 && b == 0 && c == 0)
            {
                return arr[0];
            }

            return 0;
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            int method_number = (int)numericUpDown1.Value;

            SolidBrush mybrush = new SolidBrush(Color.Black);
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);
            const int n = 70;

            int[] current = new int[n];
            int[] previous = new int[n];



            for (int i = 0; i < n; i++)
            {
                current[i] = 0;
                previous[i] = 0;
            }

            previous[n / 2] = 1;
            previous[0] = 1;
            previous[n - 1] = 1;



            for (int i = 0; i < n; i++)
            {
                if(previous[i]==1)
                {
                    g.FillRectangle(mybrush, new Rectangle(i + 1, 0, 1, 1));
                }
            }





            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        current[j] = method(previous[n - 1], previous[j], previous[j + 1], method_number);
                    }
                    else if (j == (n - 1))
                    {
                        current[j] = method(previous[j - 1], previous[j], previous[0], method_number);
                    }
                    else
                    {
                        current[j] = method(previous[j - 1], previous[j], previous[j + 1], method_number);
                    }

                    if (current[j] == 1)
                    {
                        g.FillRectangle(mybrush, new Rectangle(j + 1, i + 1, 1, 1));
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    previous[j] = current[j];
                    previous[0] = 1;
                    previous[n - 1] = 1;

                }


            }


           
                


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
