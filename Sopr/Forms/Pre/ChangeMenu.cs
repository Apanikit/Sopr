using System;
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
    public partial class ChangeMenu : Form
    {
        Preprocessor preprocessor;
        List<TextBox> textBoxes;
        int current_mode;
        public ChangeMenu(Preprocessor prepr)
        {
            InitializeComponent();
            preprocessor = prepr;
            textBoxes = new List<TextBox>() {input1, input2, input3, input4, input5 };
        }

        public void ChangeMode(int mode)
        {
            if (mode == 0)
            {
                label2.Show();
                label2.Text = "L";
                label3.Show();
                label3.Text = "A";
                label4.Show();
                label4.Text = "E";
                label5.Show();
                label5.Text = "[σ]";

                for (int i = 0; i < 5; i++)
                {
                    textBoxes[i].Text = "";
                    textBoxes[i].Show();
                }
                current_mode = 0;
            }
            else if(mode == 1)
            {
                label2.Show();
                label2.Text = "F";
                label3.Hide();
                label4.Hide();
                label5.Hide();

                for (int i = 0; i < 2; i++)
                {
                    textBoxes[i].Text = "";
                    textBoxes[i].Show();
                }
                for (int i = 2; i < 5; i++)
                {
                    textBoxes[i].Text = "";
                    textBoxes[i].Hide();
                }
                current_mode = 1;
            }
            else if(mode == 2)
            {
                label2.Show();
                label2.Text = "q";
                label3.Hide();
                label4.Hide();
                label5.Hide();

                input1.Text = "";
                input2.Text = "";
                input2.Show();
                for (int i = 2; i < 5; i++)
                {
                    textBoxes[i].Text = "";
                    textBoxes[i].Hide();
                }
                current_mode = 2;
            }
            else if (mode == 3)
            {
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();

                input1.Text = "";
                for (int i = 1; i < 5; i++)
                {
                    textBoxes[i].Text = "";
                    textBoxes[i].Hide();
                }
                current_mode = 3;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            int temp = 0;
            switch (current_mode) 
            {
                case 0:
                    temp = 5;
                    break;
                case 1:
                    temp = 2;
                    break;
                case 2:
                    temp = 2;
                    break;
                case 3:
                    temp = 1;
                    break;
            }

            try
            {
                double[] val = new double[temp];
                for (int i = 0; i < temp; i++)
                {
                    val[i] = Convert.ToDouble(textBoxes[i].Text);
                }

                if (current_mode == 0)
                {
                    Plank pl = new Plank();
                    pl.L = val[1];
                    pl.A = val[2];
                    pl.E = val[3];
                    pl.Res = val[4];
                    preprocessor.ChangePlank(pl, (int)val[0]);
                }
                if (current_mode == 1)
                {
                    Node nod = new Node();
                    nod.F = val[1];
                    preprocessor.ChangeNode(nod, (int)val[0]);
                }
                if (current_mode == 2)
                {
                    Plank pl = new Plank();
                    pl.q = val[1];
                    preprocessor.ChangePlank(pl, (int)val[0]);
                }
                if (current_mode == 3)
                {
                    Node nod = new Node();
                    nod.Support = true;
                    preprocessor.ChangeNode(nod, (int)val[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не корректные данные");
            }

            preprocessor.Draw();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            preprocessor.Draw();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (current_mode == 0)
            {
                preprocessor.PlanksList.Clear();
                preprocessor.NodesList.Clear();
                preprocessor.NodesList.Add(new Node());

                preprocessor.Draw();
            }
            if (current_mode == 1)
            {
                foreach(Node nd in preprocessor.NodesList)
                {
                    nd.F = 0;
                }

                preprocessor.Draw();
            }
            if (current_mode == 2)
            {
                foreach (Plank pl in preprocessor.PlanksList)
                {
                    pl.q = 0;
                }

                preprocessor.Draw();
            }
            if (current_mode == 3)
            {
                foreach (Node nd in preprocessor.NodesList)
                {
                    nd.Support = false;
                }

                preprocessor.Draw();
            }
        }

        Point lastPoint;
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }

        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
