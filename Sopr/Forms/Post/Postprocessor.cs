using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sopr.Forms.Pre;

namespace Sopr.Forms.Post
{
    public partial class Postprocessor : Form
    {
        private MainMenu main;
        public Bitmap display;

        public List<Plank> PlanksList;
        public List<Node> NodesList;

        private double[,] N;
        private double[,] Sigma;
        private double[,] u;
        private double len;
        public Postprocessor(string file)
        {
            InitializeComponent();

            display = new Bitmap(Graphic.Width, Graphic.Height);

            table_button.ContextMenuStrip = TableStrip;
            chart_button.ContextMenuStrip = ChartStrip;
            plot_button.ContextMenuStrip = PlotStrip;

            PlanksList = new List<Plank>();
            NodesList = new List<Node>();

            ReadFile(file);

            for (int i = 0; i < PlanksList.Count; i++)
            {
                len += PlanksList[i].L;
            }

        }

        private void ReadFile(string file)
        {
            string data = File.ReadAllText(file);
            string[] split = data.Split(' ');

            if (split[0] == "Planks")
            {
                int counter = 0;
                while (split[counter * 5 + 1] != "Nodes")
                {
                    PlanksList.Add(new Plank());
                    PlanksList[counter].L = int.Parse(split[counter * 5 + 1]);
                    PlanksList[counter].A = int.Parse(split[counter * 5 + 2]);
                    PlanksList[counter].E = int.Parse(split[counter * 5 + 3]);
                    PlanksList[counter].Res = int.Parse(split[counter * 5 + 4]);
                    PlanksList[counter].q = int.Parse(split[counter * 5 + 5]);
                    counter++;
                }

                string[] Node_split = new string[split.Length - (counter * 5 + 2)];

                int j = 0;
                for (int i = counter * 5 + 2; i < split.Length; i++)
                {
                    Node_split[j] = split[i];
                    j++;
                }

                counter = 0;
                for (int i = 0; i < PlanksList.Count + 1; i++)
                {
                    NodesList.Add(new Node());
                    NodesList[counter].F = int.Parse(Node_split[counter * 2]);
                    if (int.Parse(Node_split[counter * 2 + 1]) == 1) NodesList[counter].Support = true;
                    else NodesList[counter].Support = false;

                    counter++;
                }
            }
            else throw new Exception();
        }

        private void table_button_Click(object sender, EventArgs e)
        {
            table.Show();
            Graphic.Hide();
            table_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void chart_button_Click(object sender, EventArgs e)
        {
            table.Hide();
            Graphic.Show();
            chart_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void plot_button_Click(object sender, EventArgs e)
        {
            table.Hide();
            Graphic.Show();
            plot_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void TableNItem_Click(object sender, EventArgs e)
        {
            table.Show();
            Graphic.Hide();
        }

        private void TableUItem_Click(object sender, EventArgs e)
        {

        }

        private void TableSigItem_Click(object sender, EventArgs e)
        {

        }

        private void ChartNItem_Click(object sender, EventArgs e)
        {

        }

        private void ChartUItem_Click(object sender, EventArgs e)
        {

        }

        private void ChartSigItem_Click(object sender, EventArgs e)
        {

        }

        private void PlotNItem_Click(object sender, EventArgs e)
        {
            table.Hide();
            Graphic.Show();

            DrawPlot();

            double[][] A = new double[PlanksList.Count + 1][];
            for (int i = 0; i < PlanksList.Count + 1; i++)
            {
                A[i] = new double[PlanksList.Count + 1];
                for (int j = 0; j < PlanksList.Count + 1; j++)
                {
                    A[i][j] = 0;
                }
            }
            for (int i = 0; i < PlanksList.Count; i++)
            {
                if (i == 0)
                {
                    A[i][i] += PlanksList[i].E * PlanksList[i].A / PlanksList[i].L;
                    A[i][i + 1] += -(PlanksList[i].E * PlanksList[i].A / PlanksList[i].L);
                }

                if (i == PlanksList.Count - 1)
                {
                    A[i][i - 1] += -(PlanksList[i - 1].E * PlanksList[i - 1].A / PlanksList[i - 1].L);
                    A[i][i] += PlanksList[i - 1].E * PlanksList[i - 1].A / PlanksList[i - 1].L;
                    A[i][i] += PlanksList[i].E * PlanksList[i].A / PlanksList[i].L;
                    A[i][i + 1] += -(PlanksList[i].E * PlanksList[i].A / PlanksList[i].L);
                    A[i + 1][i] += -(PlanksList[i].E * PlanksList[i].A / PlanksList[i].L);
                    A[i + 1][i + 1] += PlanksList[i].E * PlanksList[i].A / PlanksList[i].L;
                }

                if (i != 0 & i != PlanksList.Count - 1)
                {
                    A[i][i - 1] += -(PlanksList[i - 1].E * PlanksList[i - 1].A / PlanksList[i - 1].L);
                    A[i][i] += PlanksList[i - 1].E * PlanksList[i - 1].A / PlanksList[i - 1].L;
                    A[i][i] += PlanksList[i].E * PlanksList[i].A / PlanksList[i].L;
                    A[i][i + 1] += -(PlanksList[i].E * PlanksList[i].A / PlanksList[i].L);
                }
            }

            for (int i = 0; i < NodesList.Count; i++)
            {
                if (NodesList[i].Support)
                {
                    A[i][i] = 1;
                    if (i == 0)
                    {
                        A[i + 1][i] = 0;
                        A[i][i + 1] = 0;
                    }
                    else if (i == NodesList.Count - 1)
                    {
                        A[i - 1][i] = 0;
                        A[i][i - 1] = 0;
                    }
                    else
                    {
                        A[i + 1][i] = 0;
                        A[i][i + 1] = 0;
                        A[i - 1][i] = 0;
                        A[i][i - 1] = 0;
                    }
                }
            }

            double[] b = new double[PlanksList.Count + 1];

            for (int i = 0; i < b.Length; i++)
            {
                if (i == 0)
                {
                    b[i] = (PlanksList[i].q * PlanksList[i].L / 2) + NodesList[i].F;
                    if (NodesList[i].Support) b[i] = 0;
                }
                else if (i == (b.Length - 1))
                {
                    b[i] = (PlanksList[i - 1].q * PlanksList[i - 1].L / 2) + NodesList[i].F;
                    if (NodesList[i].Support) b[i] = 0;
                }
                else
                {
                    b[i] = (PlanksList[i - 1].q * PlanksList[i - 1].L / 2) + (PlanksList[i].q * PlanksList[i].L / 2) + NodesList[i].F;
                    if (NodesList[i].Support) b[i] = 0;
                }
            }

            double[] delt = Gauss(A, b);

            N = new double[PlanksList.Count, 2];
            double max_n = 0;

            for (int i = 0; i < PlanksList.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    N[i, j] = (PlanksList[i].E * PlanksList[i].A / PlanksList[i].L) * (delt[i + 1] - delt[i]) + (PlanksList[i].q * PlanksList[i].L / 2) * (1 - 2 * PlanksList[i].L * j / PlanksList[i].L);
                    if (Math.Abs(N[i, j]) > )
                }
            }

        }

        private void PlotUItem_Click(object sender, EventArgs e)
        {
            table.Hide();
            Graphic.Show();

            int h = Graphic.Height;
            int w = Graphic.Width;

            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Black, 2);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            g.Clear(Color.White);
            g.DrawLine(p, 30, 0, 30, h);
            g.DrawLine(p, 30, 0, 20, 10);
            g.DrawLine(p, 30, 0, 40, 10);

            g.DrawLine(p, 30, h / 2, w - 20, h / 2);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 - 10);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 + 10);

            Graphic.Image = display;
        }

        private void PlotSigItem_Click(object sender, EventArgs e)
        {
            table.Hide();
            Graphic.Show();

            int h = Graphic.Height;
            int w = Graphic.Width;

            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Black, 2);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            g.Clear(Color.White);
            g.DrawLine(p, 30, 0, 30, h);
            g.DrawLine(p, 30, 0, 20, 10);
            g.DrawLine(p, 30, 0, 40, 10);

            g.DrawLine(p, 30, h / 2, w - 20, h / 2);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 - 10);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 + 10);

            Graphic.Image = display;
        }

        void DrawPlot()
        {
            int h = Graphic.Height;
            int w = Graphic.Width;

            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Black, 2);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            g.Clear(Color.White);
            g.DrawLine(p, 30, 0, 30, h);
            g.DrawLine(p, 30, 0, 20, 10);
            g.DrawLine(p, 30, 0, 40, 10);

            g.DrawLine(p, 30, h / 2, w - 20, h / 2);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 - 10);
            g.DrawLine(p, w - 20, h / 2, w - 30, h / 2 + 10);

            int temp = 30;
            double resol = (w - 50) - 30;

            for (int i = 0; i < PlanksList.Count; i++)
            {
                g.DrawLine(p, temp + (int)(resol / len * PlanksList[i].L), h / 2 - 10, temp + (int)(resol / len * PlanksList[i].L), h / 2 + 10);
                temp += (int)(resol / len * PlanksList[i].L);
            }

            Graphic.Image = display;
        }

        double[] Gauss(double[][] A, double[] B)
        {
            double[][] mat = new double[B.Length][];
            double[] res = new double[B.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = B[i];
                mat[i] = new double[res.Length];
                for (int j = 0; j < res.Length; j++)
                    mat[i][j] = A[i][j];
            }

            for (int i = 0; i < res.Length; i++)
            {
                double temp = mat[i][i];
                for (int j = 0; j < res.Length; j++)
                {
                    mat[i][j] /= temp;
                }
                res[i] /= temp;

                for (int z = i + 1; z < res.Length; z++)
                {
                    temp = mat[z][i];
                    for (int j = 0; j < res.Length; j++)
                    {
                        mat[z][j] -= mat[i][j] * temp;
                    }
                    res[z] -= res[i] * temp;
                }
            }
            for (int j = res.Length - 1; j >= 0; j--)
                for (int z = j - 1; z >= 0; z--)
                {
                    res[z] -= res[j] * mat[z][j];
                    mat[z][j] = 0;
                }

            return res;
        }

    }
}
