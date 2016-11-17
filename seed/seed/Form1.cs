using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seed
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer t;
        Seed[][] previous;
        Seed[][] current;

        SolidBrush mybrush;
        Graphics g;

        Bitmap flag;
        Graphics flagGraphics;

        int n;

        Random rnd;


        public class Seed
        {


            public int state;
            public int seed_number;
        }




        Seed is_alive(Seed a, Seed b, Seed c, Seed d, Seed e, Seed f, Seed g, Seed h)
        {

            Seed tmp = new Seed();
            tmp.state = 0;
            tmp.seed_number = -1;

            int[] tmp_tab = new int[10];

            int sum = a.state + b.state + c.state + d.state + e.state + f.state + g.state + h.state;

            if (sum != 0)
            {
                tmp.state = 1;

                if (a.state == 1)
                {
                    tmp_tab[a.seed_number]++;
                }
                if (b.state == 1)
                {
                    tmp_tab[b.seed_number]++;
                }
                if (c.state == 1)
                {
                    tmp_tab[c.seed_number]++;
                }
                if (d.state == 1)
                {
                    tmp_tab[d.seed_number]++;
                }
                if (e.state == 1)
                {
                    tmp_tab[e.seed_number]++;
                }
                if (f.state == 1)
                {
                    tmp_tab[f.seed_number]++;
                }
                if (g.state == 1)
                {
                    tmp_tab[g.seed_number]++;
                }
                if (h.state == 1)
                {
                    tmp_tab[h.seed_number]++;
                }


                int v = 0;
                int max = tmp_tab[0];

                for (int i = 1; i < 10; i++)
                {
                    if (tmp_tab[i] > max)
                    {
                        v = i;
                    }
                }

                tmp.seed_number = v;
            }


            return tmp;
        }

        void draw(object sender, EventArgs e)
        {

            //g.Clear(Color.White);
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {

                    Seed a = previous[(n + i + 1) % n][(n + j + 1) % n];
                    Seed b = previous[(n + i - 1) % n][(n + j + 1) % n];
                    Seed c = previous[(n + i - 1) % n][(n + j - 1) % n];
                    Seed d = previous[(n + i + 1) % n][(n + j - 1) % n];
                    Seed z = previous[i][(n + j - 1) % n];
                    Seed f = previous[i][(n + j + 1) % n];
                    Seed h = previous[(n + i + 1) % n][j];
                    Seed l = previous[(n + i - 1) % n][j];
                    if (current[i][j].state == 0)
                    {
                        current[i][j] = is_alive(a, b, c, d, z, f, h, l);
                    }


                }
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (current[j][i].state == 1)
                    {
                        if (current[j][i].seed_number == 0)
                        {
                            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 0)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 2)
                        {
                            g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 3)
                        {
                            g.FillRectangle(new SolidBrush(Color.OrangeRed), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 4)
                        {
                            g.FillRectangle(new SolidBrush(Color.Purple), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 5)
                        {
                            g.FillRectangle(new SolidBrush(Color.Brown), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 6)
                        {
                            g.FillRectangle(new SolidBrush(Color.Pink), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 7)
                        {
                            g.FillRectangle(new SolidBrush(Color.PapayaWhip), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 8)
                        {
                            g.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(j * 5, i * 5, 5, 5));
                        }
                        if (current[j][i].seed_number == 9)
                        {
                            g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(j * 5, i * 5, 5, 5));
                        }

                    }
                    previous[i][j] = current[i][j];
                }
            }

        }



        public Form1()
        {
            InitializeComponent();

            rnd = new Random();

            pictureBox1.Width = n * 5;
            pictureBox1.Height = n * 5;

            mybrush = new SolidBrush(Color.Black);
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            flag = new Bitmap(500, 500);
            flagGraphics = Graphics.FromImage(flag);

            n = 100;

            previous = new Seed[n][];
            for (int i = 0; i < n; i++)
            {
                previous[i] = new Seed[n];
            }

            current = new Seed[n][];
            for (int i = 0; i < n; i++)
            {
                current[i] = new Seed[n];
            }


            int it = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (previous[i][j] != null && current[i][j] != null)
                    {
                        previous[i][j].state = 0;
                        previous[i][j].seed_number = -1;

                        current[i][j].state = 0;
                        current[i][j].seed_number = -1;
                    }

                }
            }

            while (it < 10)
            {
                int x = rnd.Next(0, n-1);
                int y = rnd.Next(0, n-1);
                if (previous[x][y] != null && previous[x][y].state == 0)
                {
                    previous[x][y].state = 1;
                    previous[x][y].seed_number = it;
                    it++;
                }

            }

            t = new System.Timers.Timer();
            t.Interval = 500;
            t.Elapsed += new System.Timers.ElapsedEventHandler(draw);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

