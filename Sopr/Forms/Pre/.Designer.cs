
namespace Sopr.Forms.Pre
{
    partial class Preprocessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Planks = new System.Windows.Forms.Button();
            this.Forces = new System.Windows.Forms.Button();
            this.QForce = new System.Windows.Forms.Button();
            this.save_pre = new System.Windows.Forms.Button();
            this.back_pre = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Supports = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Planks
            // 
            this.Planks.Location = new System.Drawing.Point(12, 37);
            this.Planks.Name = "Planks";
            this.Planks.Size = new System.Drawing.Size(125, 50);
            this.Planks.TabIndex = 1;
            this.Planks.Text = "Изменение стержней";
            this.Planks.UseVisualStyleBackColor = true;
            this.Planks.Click += new System.EventHandler(this.Planks_Click);
            // 
            // Forces
            // 
            this.Forces.Location = new System.Drawing.Point(143, 37);
            this.Forces.Name = "Forces";
            this.Forces.Size = new System.Drawing.Size(125, 50);
            this.Forces.TabIndex = 2;
            this.Forces.Text = "Изменение сил";
            this.Forces.UseVisualStyleBackColor = true;
            this.Forces.Click += new System.EventHandler(this.Forces_Click);
            // 
            // QForce
            // 
            this.QForce.Location = new System.Drawing.Point(274, 37);
            this.QForce.Name = "QForce";
            this.QForce.Size = new System.Drawing.Size(125, 50);
            this.QForce.TabIndex = 3;
            this.QForce.Text = "Изменение погонных сил";
            this.QForce.UseVisualStyleBackColor = true;
            this.QForce.Click += new System.EventHandler(this.QForce_Click);
            // 
            // save_pre
            // 
            this.save_pre.Location = new System.Drawing.Point(554, 12);
            this.save_pre.Name = "save_pre";
            this.save_pre.Size = new System.Drawing.Size(150, 75);
            this.save_pre.TabIndex = 4;
            this.save_pre.Text = "Сохранить";
            this.save_pre.UseVisualStyleBackColor = true;
            this.save_pre.Click += new System.EventHandler(this.save_pre_Click);
            // 
            // back_pre
            // 
            this.back_pre.Location = new System.Drawing.Point(710, 12);
            this.back_pre.Name = "back_pre";
            this.back_pre.Size = new System.Drawing.Size(150, 75);
            this.back_pre.TabIndex = 5;
            this.back_pre.Text = "Назад";
            this.back_pre.UseVisualStyleBackColor = true;
            this.back_pre.Click += new System.EventHandler(this.back_pre_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(860, 444);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Supports
            // 
            this.Supports.Location = new System.Drawing.Point(405, 37);
            this.Supports.Name = "Supports";
            this.Supports.Size = new System.Drawing.Size(125, 50);
            this.Supports.TabIndex = 7;
            this.Supports.Text = "Изменение опор";
            this.Supports.UseVisualStyleBackColor = true;
            this.Supports.Click += new System.EventHandler(this.Supports_Click);
            // 
            // Preprocessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Supports);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.back_pre);
            this.Controls.Add(this.save_pre);
            this.Controls.Add(this.QForce);
            this.Controls.Add(this.Forces);
            this.Controls.Add(this.Planks);
            this.Name = "Preprocessor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Planks;
        private System.Windows.Forms.Button Forces;
        private System.Windows.Forms.Button QForce;
        private System.Windows.Forms.Button save_pre;
        private System.Windows.Forms.Button back_pre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Supports;
    }
}