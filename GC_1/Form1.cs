namespace GC_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             Ex1(e);
            //Ex2(e);
           // Ex3(e);
        }

        private void Ex3(PaintEventArgs e)
        {
            /* 3. Se dau n puncte in plan. Pentru un punct dat Q sa se determine cercul cu
             * centrul in Q si de raza maxima care sa nu contina nici un punct din multimea data.*/

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Random rnd = new Random();

            int n = rnd.Next(50, 200);
            int m = rnd.Next(50, 200);
            int x, y;
            double d, d_min = int.MaxValue;

            Point[] points = new Point[n];


            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i] = new Point(x, y);
                g.DrawEllipse(p, x, y, 2, 2);
            }

            x = rnd.Next(10, this.ClientSize.Width - 10);
            y = rnd.Next(10, this.ClientSize.Height - 10);
            Point q = new Point(x, y);
            p.Color = Color.Red;
            g.DrawEllipse(p, x, y, 2, 2);

            for (int i = 0; i < n; i++)
            {
                d = Math.Sqrt(Math.Pow(x - points[i].X, 2) + Math.Pow(y - points[i].Y, 2));
                if (d < d_min)
                {
                    d_min = d;
                }
            }

            d_min -= 1;
            g.DrawEllipse(p, (float)(q.X - d_min), (float)(q.Y - d_min), (float)(2 * d_min), (float)(2 * d_min));
        }
        private void Ex2(PaintEventArgs e)
        {
            /*2. Se dau doua multimi de puncte in plan. Pentru fiecare punct din prima multime 
             * sa se gaseasca cel mai apropiat punct din a doua multime.*/

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 2);
            Random rnd = new Random();

            int n = rnd.Next(50, 200);
            int m = rnd.Next(50, 200);
            int x, y;
            double d, d_min;
            int j_min = 0;

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(this.ClientSize.Width - 10);
                y = rnd.Next(this.ClientSize.Height - 10);

                points[i] = new Point(x, y);
                g.DrawEllipse(p, x, y, 2, 2);
            }
            p.Color = Color.Green;
            for (int i = 0; i < m; i++)
            {
                x = rnd.Next(this.ClientSize.Width - 10);
                y = rnd.Next(this.ClientSize.Height - 10);
                g.DrawEllipse(p, x, y, 2, 2);
                d_min = int.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    d = Math.Sqrt(Math.Pow(x - points[j].X, 2) + Math.Pow(y - points[j].Y, 2));
                    if (d < d_min)
                    {
                        d_min = d;
                        j_min = j;
                    }
                }
                p.Color = Color.Blue;
                g.DrawLine(p, x, y, points[j_min].X, points[j_min].Y);
            }
        }

        private void Ex1(PaintEventArgs e)
        {
            /* 1. Se da o multime de puncte in plan. Sa se determine dreptunghiul de arie minima 
             * care sa contina toate punctele in interior. */

            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 2);
            Random rnd = new Random();

            int n = rnd.Next(50, 200);
            int x_min = this.ClientSize.Width;
            int y_min = this.ClientSize.Height;
            int x_max = 0;
            int y_max = 0;
            int x, y;

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);

                g.DrawEllipse(p, x, y, 1, 1);

                if (x < x_min)
                    x_min = x;
                else if (x > x_max)
                    x_max = x;

                if (y < y_min)
                    y_min = y;
                else if (y > y_max)
                    y_max = y;
            }
            g.DrawRectangle(p, x_min - 1, y_min - 1, x_max - x_min + 1, y_max - y_min + 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}