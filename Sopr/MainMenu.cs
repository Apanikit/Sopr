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
using Sopr.Forms.Processor;
using Sopr.Forms.Post;

namespace Sopr
{
    public partial class MainMenu : Form
    {
        public string Preprocessor_file_path;
        public string Processor_file_path;
        public string Postprocessor_file_path;

        public MainMenu()
        {
            InitializeComponent();

            Preprocessor_button.ContextMenuStrip = Preprocessor_contextMenu;
            Processor_button.ContextMenuStrip = Processor_contextMenu;
            Postprocessor_button.ContextMenuStrip = Postprocessor_contextMenu;
        }

        private void Preprocessor_button_Click(object sender, EventArgs e)
        {
            Preprocessor_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Processor_button_Click(object sender, EventArgs e)
        {
            Processor_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Postprocessor_button_Click(object sender, EventArgs e)
        {
            Postprocessor_button.ContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void new_preprocesor(object sender, EventArgs e)
        {
            Preprocessor pre = new Preprocessor(this);
            this.Hide();
            pre.Show();
        }

        private void choose_preprocesor(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                Preprocessor_file_path = openFileDialog.FileName;
                this.Hide();
                Preprocessor pre = new Preprocessor(this, Preprocessor_file_path);
                try
                {
                    pre.Show();
                }
                catch (Exception ex) { };
            }
        }

        private void choose_procesor(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                Processor_file_path = openFileDialog.FileName;
                try
                {
                    Processor proc = new Processor(this, Processor_file_path);
                    proc.calculate_save();
                }
                catch (Exception ex) { MessageBox.Show("Ошибка"); };
            }
        }

        private void choose_postprocesor(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                Postprocessor_file_path = openFileDialog.FileName;

            }
            Postprocessor post = new Postprocessor(Postprocessor_file_path);
            post.Show();
            this.Hide();
        }

    }
}
