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

using Sopr.Forms.Pre;

namespace Sopr.Forms.Processor
{
    public class Processor
    {
        private MainMenu main;

        public List<Plank> PlanksList;
        public List<Node> NodesList;

        private double[,] N;
        private double[,] Sigma;
        private double[,] u;

        public Processor(MainMenu main, string file)
        {
            this.main = main;
            PlanksList = new List<Plank>();
            NodesList = new List<Node>();
            try
            {
                ReadFile(file);
            }
            catch (Exception ex)
            {
                main.Show();
                MessageBox.Show("Некорректный файл");
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

        public void calculate_save()
        {
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
                if (i == 0 )
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
            Sigma = new double[PlanksList.Count, 2];
            u = new double[PlanksList.Count, 2];
            for (int i = 0; i < PlanksList.Count; i++)
                for(int j = 0; j < 2; j++)
                {
                    N[i, j] = (PlanksList[i].E * PlanksList[i].A / PlanksList[i].L) * (delt[i + 1] - delt[i]) + (PlanksList[i].q * PlanksList[i].L / 2) * (1 - 2 * PlanksList[i].L * j / PlanksList[i].L);
                    Sigma[i, j] = N[i, j] / PlanksList[i].A;
                    u[i, j] = delt[i] + ((j * PlanksList[i].L) / PlanksList[i].L) * (delt[i + 1] - delt[i]) + (PlanksList[i].q * PlanksList[i].L * PlanksList[i].L * (PlanksList[i].L * j) / (2 * PlanksList[i].E * PlanksList[i].A * PlanksList[i].L)) * (1 - 2 * PlanksList[i].L * j / PlanksList[i].L);
                }

            save_in_file();
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

                serialize += "N ";
                for (int i = 0; i < N.GetUpperBound(0) + 1; i++)
                    for (int j = 0; j < N.GetUpperBound(1) + 1; j++)
                        serialize += (N[i, j].ToString() + " ");

                serialize += "Sigma ";
                for (int i = 0; i < Sigma.GetUpperBound(0) + 1; i++)
                    for (int j = 0; j < Sigma.GetUpperBound(1) + 1; j++)
                        serialize += (Sigma[i, j].ToString() + " ");

                serialize += "u ";
                for (int i = 0; i < u.GetUpperBound(0) + 1; i++)
                    for (int j = 0; j < u.GetUpperBound(1) + 1; j++)
                        serialize += (u[i, j].ToString() + " ");

                File.WriteAllText(name, serialize);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
