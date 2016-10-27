using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace _27._10
{
    public partial class Form1 : Form
    {

        private static System.Timers.Timer t;
        int[][] previous;
        int[][] current;
        
        SolidBrush mybrush;
        Graphics g;

        int n;



        int is_alive(int current, int a, int b, int c, int d, int e, int f, int g, int h)
        {
            int sum = a + b + c + d + e + f + g + h;
            if (current==0 && sum == 3)
            {
                return 1;
            }
            if(current == 1 && (sum==2 || sum == 3))
            {
                return 1;
            }

            return 0;
        }

        void draw(object sender, EventArgs e)
        {
            
                g.Clear(Color.White);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n ; j++)
                    {

                    int a = previous[(pictureBox1.Width/5 + i + 1)% (pictureBox1.Width / 5)][(pictureBox1.Height / 5 + j + 1) % (pictureBox1.Width / 5)];
                    int b = previous[(pictureBox1.Width / 5 + i - 1) % (pictureBox1.Width / 5)][(pictureBox1.Height / 5 + j + 1) % (pictureBox1.Width / 5)] ;
                    int c = previous[(pictureBox1.Width / 5 + i - 1) % (pictureBox1.Width / 5)][(pictureBox1.Height / 5 + j - 1) % (pictureBox1.Width / 5)];
                    int d = previous[(pictureBox1.Width / 5 + i + 1) % (pictureBox1.Width / 5)][(pictureBox1.Height / 5 + j - 1) % (pictureBox1.Width / 5)];
                    int z = previous[i][(pictureBox1.Height / 5 + j - 1) % (pictureBox1.Width / 5)];
                    int f = previous[i][(pictureBox1.Height / 5 + j + 1) % (pictureBox1.Width / 5)];
                    int h = previous[(pictureBox1.Width / 5 + i + 1) % (pictureBox1.Width / 5)][j];
                    int l = previous[((pictureBox1.Width / 5) - i + 1) % (pictureBox1.Width / 5)][j];

                    current[i][j] = is_alive(previous[i][j], a, b, c, d, z, f, h, l);

                        //current[i][j] = is_alive(previous[i][j], previous[i - 1][j - 1], previous[i - 1][j], previous[i][j - 1], previous[i + 1][j], previous[i][j + 1], previous[i + 1][j + 1], previous[i - 1][j + 1], previous[i + 1][j - 1]);
                }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (current[i][j] == 1)
                        {
                            g.FillRectangle(mybrush, new Rectangle(i*5, j*5, 5, 5));
                        }
                        previous[i][j] = current[i][j];
                    }
                }
            
        }



        public Form1()
        {
            InitializeComponent();

            pictureBox1.Width = 500;
            pictureBox1.Height = 500;

            mybrush = new SolidBrush(Color.Black);
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);


            n = 100;
            previous = new int[n][];
            for (int i = 0; i < n; i++)
            {
                previous[i] = new int[n];
            }

            current = new int[n][];
            for (int i = 0; i < n; i++)
            {
                current[i] = new int[n];
            }

            t = new System.Timers.Timer();
            t.Interval = 500;
            t.Elapsed += new System.Timers.ElapsedEventHandler(draw);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            var mouseEventArgs = e as MouseEventArgs;
            int xCoordinate = mouseEventArgs.X;
            int yCoordinate = mouseEventArgs.Y;

            Bitmap flag = new Bitmap(500, 500);
            Graphics flagGraphics = Graphics.FromImage(flag);

            if (previous[yCoordinate / 5][xCoordinate / 5] == 1)
            {
                previous[yCoordinate / 5][xCoordinate / 5] = 0;
            }
            else
            {
                previous[yCoordinate / 5][xCoordinate / 5] = 1;
            }



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (previous[i][j] == 1)
                    {
                        flagGraphics.FillRectangle(Brushes.Black, j * 5, i * 5, 5, 5);
                    }
                    else
                    {
                        flagGraphics.FillRectangle(Brushes.White, j * 5, i * 5, 5, 5);
                    }
                }

                pictureBox1.Image = flag;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
        }
    }
}
