using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sopr.Forms.Pre
{
    public partial class Preprocessor : Form
    {
        private MainMenu main;
        private ChangeMenu menu;
        public Bitmap display;

        public List<Plank> PlanksList;
        public List<Node> NodesList;
        public Preprocessor(MainMenu main, string file = "")
        {
            InitializeComponent();
            menu = new ChangeMenu(this);
            this.main = main;

            PlanksList = new List<Plank>();
            NodesList = new List<Node>();

            display = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if (file != "")
            {
                try
                {
                    ReadFile(file);
                }
                catch (Exception ex)
                {
                    main.Show();
                    MessageBox.Show("Некорректный файл");
                    this.Dispose();
                }
            }
            else
            {
                NodesList.Add(new Node());
            }

            Draw();
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

        private void Planks_Click(object sender, EventArgs e)
        {
            menu.ChangeMode(0);
            menu.Show();
        }

        private void Forces_Click(object sender, EventArgs e)
        {
            menu.ChangeMode(1);
            menu.Show();
        }

        private void QForce_Click(object sender, EventArgs e)
        {
            menu.ChangeMode(2);
            menu.Show();
        }

        private void Supports_Click(object sender, EventArgs e)
        {
            menu.ChangeMode(3);
            menu.Show();
        }

        public void ChangePlank(Plank pl, int pos)
        {
            if (PlanksList.Count() >= pos)
            {
                PlanksList[pos - 1] += pl;
            }
            else if (PlanksList.Count() + 1 == pos)
            {
                PlanksList.Add(pl);
                NodesList.Add(new Node());
            }
            else
            {
                MessageBox.Show("Не корректные данные");
            }
        }

        public void ChangeNode(Node nod, int pos)
        {
            NodesList[pos - 1] += nod;
        }

        public void Draw()
        {
            Graphics g = Graphics.FromImage(display);
            g.Clear(Color.White);

            double total_L = 0;
            double max_A = 0;
            int tempX = 30;

            foreach(Plank pl in PlanksList)
            {
                total_L += pl.L;
                if (max_A < pl.A) max_A = pl.A;
            }

            int delta_x = (int)(800 / total_L);

            for(int i = 0; i < PlanksList.Count; i++)
            {
                List<Point> corners = new List<Point>();
                corners.Add(new Point(tempX, 222 - (int)(111 * PlanksList[i].A / max_A)));
                corners.Add(new Point(tempX, 222 + (int)(111 * PlanksList[i].A / max_A)));
                corners.Add(new Point(tempX + (int)(PlanksList[i].L * delta_x), 222 - (int)(111 * PlanksList[i].A / max_A)));
                corners.Add(new Point(tempX + (int)(PlanksList[i].L * delta_x), 222 + (int)(111 * PlanksList[i].A / max_A)));
                tempX += (int)(PlanksList[i].L * delta_x);

                DrawPlank(corners);

                for(int j = 0; j < 2; j++)
                {
                    Point start = new Point(corners[0].X + (corners[2].X - corners[0].X) * j, 222);

                    DrawForce(corners, start, i + j, i);
                    DrawSupport(start, i + j);

                }

                if (PlanksList[i].q > 0) DrawQ(corners, true);
                else if (PlanksList[i].q < 0) DrawQ(corners, false);
            }

            if (PlanksList.Count == 0)
            {
                g.Clear(Color.White);
                pictureBox1.Image = display;
            }
            
        }

        private void DrawPlank(List<Point> corners)
        {
            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Black, 3);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            g.DrawLine(p, corners[0], corners[1]);
            g.DrawLine(p, corners[0], corners[2]);
            g.DrawLine(p, corners[1], corners[3]);
            g.DrawLine(p, corners[2], corners[3]);

            pictureBox1.Image = display;
        }

        private void DrawForce(List<Point> corners, Point start, int node_pos, int plank_pos)
        {
            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Blue, 5);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            int len = (int)((corners[2].X - corners[0].X) / 5);
            Point end = new Point(0, 222);
            end.X = start.X;

            Node value = NodesList[node_pos];

            if ((value.F > 0) & ((node_pos == plank_pos) || (node_pos == 0) || (node_pos == NodesList.Count - 1)))
            {
                if ((node_pos == 0) || (node_pos == NodesList.Count - 1))
                {
                    len = 30;
                }
                end.X += len;
                g.DrawLine(p, start, end);
                g.DrawLine(p, end.X, end.Y, end.X - len / 2, end.Y + len / 2);
                g.DrawLine(p, end.X, end.Y, end.X - len / 2, end.Y - len / 2);
            }
            else if ((value.F < 0) & ((node_pos != plank_pos) || (node_pos == 0) || (node_pos == NodesList.Count - 1)))
            {
                if ((node_pos == 0) || (node_pos == NodesList.Count - 1))
                {
                    len = 30;
                }
                end.X -= len;
                g.DrawLine(p, end.X, end.Y, end.X + len / 2, end.Y + len / 2);
                g.DrawLine(p, end.X, end.Y, end.X + len / 2, end.Y - len / 2);
            }
            
            g.DrawLine(p, start, end);

            pictureBox1.Image = display;
        }

        private void DrawQ(List<Point> corners, bool value)
        {
            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Red, 2);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            if (value)
            {
                int temp_x = corners[0].X + 10;

                do
                {
                    g.DrawLine(p, temp_x, 222, temp_x + 10, 222);
                    g.DrawLine(p, temp_x + 10, 222, temp_x + 5, 217);
                    g.DrawLine(p, temp_x + 10, 222, temp_x + 5, 227);

                    temp_x += 20;
                }
                while (temp_x + 10 < corners[2].X);
            }
            else
            {
                int temp_x = corners[2].X - 10;

                do
                {
                    g.DrawLine(p, temp_x, 222, temp_x - 10, 222);
                    g.DrawLine(p, temp_x - 10, 222, temp_x - 5, 217);
                    g.DrawLine(p, temp_x - 10, 222, temp_x - 5, 227);

                    temp_x -= 20;
                }
                while (temp_x - 10 > corners[0].X);
            }

            pictureBox1.Image = display;
        }

        private void DrawSupport(Point start, int node_pos)
        {
            Graphics g = Graphics.FromImage(display);
            Pen p = new Pen(Color.Black, 8);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            if (NodesList[node_pos].Support)
                if (node_pos == 0)
                {
                    g.DrawLine(p, start.X, 0, start.X, pictureBox1.Height);

                    int temp = 70;
                    while (temp + 80 < pictureBox1.Height)
                    {
                        g.DrawLine(p, start.X, temp, 0, temp);
                        temp += 70;
                    }
                }
                else if (node_pos == NodesList.Count - 1)
                {
                    g.DrawLine(p, start.X, 0, start.X, pictureBox1.Height);

                    int temp = 70;
                    while (temp + 80 < pictureBox1.Height)
                    {
                        g.DrawLine(p, start.X, temp, pictureBox1.Width, temp);
                        temp += 70;
                    }
                }
                else
                {
                    g.DrawLine(p, start.X, 0, start.X, start.Y);
                }

            pictureBox1.Image = display;
        }

        private bool save_in_file()
        {
            SaveFileDialog saveFilePreprocesor = new SaveFileDialog();
            if (saveFilePreprocesor.ShowDialog() == DialogResult.OK)
            {
                string name = saveFilePreprocesor.FileName;
                string serialize = "Planks ";
                for (int i = 0; i < PlanksList.Count; i++)
                    serialize += (PlanksList[i].serialize() + " ");

                serialize += "Nodes ";
                for (int i = 0; i < NodesList.Count; i++)
                    serialize += (NodesList[i].serialize() + " ");

                File.WriteAllText(name, serialize);

                return true;
            }
            else
            {
                return false;
            }
        }

        private void save_pre_Click(object sender, EventArgs e)
        {
            save_in_file();
        }

        private void back_pre_Click(object sender, EventArgs e)
        {
            DialogResult dres = new DialogResult();
            dres = MessageBox.Show("Сохранить изменения?", "Title_here", MessageBoxButtons.YesNo);
            if (dres == DialogResult.Yes)
            {
                if (save_in_file())
                {
                    main.Show();
                    this.Dispose();
                }
            }
            else if (dres == DialogResult.No)
            {
                main.Show();
                this.Dispose();
            }
        }
    }
}
