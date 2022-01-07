
namespace Sopr
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Preprocessor_button = new System.Windows.Forms.Button();
            this.Processor_button = new System.Windows.Forms.Button();
            this.Postprocessor_button = new System.Windows.Forms.Button();
            this.Preprocessor_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.новыйПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Processor_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Postprocessor_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Preprocessor_contextMenu.SuspendLayout();
            this.Processor_contextMenu.SuspendLayout();
            this.Postprocessor_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Preprocessor_button
            // 
            this.Preprocessor_button.Location = new System.Drawing.Point(100, 200);
            this.Preprocessor_button.Name = "Preprocessor_button";
            this.Preprocessor_button.Size = new System.Drawing.Size(150, 100);
            this.Preprocessor_button.TabIndex = 0;
            this.Preprocessor_button.Text = "Препроцессор";
            this.Preprocessor_button.UseVisualStyleBackColor = true;
            this.Preprocessor_button.Click += new System.EventHandler(this.Preprocessor_button_Click);
            // 
            // Processor_button
            // 
            this.Processor_button.Location = new System.Drawing.Point(375, 200);
            this.Processor_button.Name = "Processor_button";
            this.Processor_button.Size = new System.Drawing.Size(150, 100);
            this.Processor_button.TabIndex = 1;
            this.Processor_button.Text = "Процессор";
            this.Processor_button.UseVisualStyleBackColor = true;
            this.Processor_button.Click += new System.EventHandler(this.Processor_button_Click);
            // 
            // Postprocessor_button
            // 
            this.Postprocessor_button.Location = new System.Drawing.Point(650, 200);
            this.Postprocessor_button.Name = "Postprocessor_button";
            this.Postprocessor_button.Size = new System.Drawing.Size(150, 100);
            this.Postprocessor_button.TabIndex = 2;
            this.Postprocessor_button.Text = "Постпроцессор";
            this.Postprocessor_button.UseVisualStyleBackColor = true;
            this.Postprocessor_button.Click += new System.EventHandler(this.Postprocessor_button_Click);
            // 
            // Preprocessor_contextMenu
            // 
            this.Preprocessor_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПроектToolStripMenuItem,
            this.выбратьФайлToolStripMenuItem});
            this.Preprocessor_contextMenu.Name = "contextMenuStrip1";
            this.Preprocessor_contextMenu.Size = new System.Drawing.Size(154, 48);
            // 
            // новыйПроектToolStripMenuItem
            // 
            this.новыйПроектToolStripMenuItem.Name = "новыйПроектToolStripMenuItem";
            this.новыйПроектToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.новыйПроектToolStripMenuItem.Text = "Новый файл";
            this.новыйПроектToolStripMenuItem.Click += new System.EventHandler(this.new_preprocesor);
            // 
            // выбратьФайлToolStripMenuItem
            // 
            this.выбратьФайлToolStripMenuItem.Name = "выбратьФайлToolStripMenuItem";
            this.выбратьФайлToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выбратьФайлToolStripMenuItem.Text = "Выбрать файл";
            this.выбратьФайлToolStripMenuItem.Click += new System.EventHandler(this.choose_preprocesor);
            // 
            // Processor_contextMenu
            // 
            this.Processor_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьToolStripMenuItem});
            this.Processor_contextMenu.Name = "contextMenuStrip1";
            this.Processor_contextMenu.Size = new System.Drawing.Size(154, 26);
            // 
            // выбратьToolStripMenuItem
            // 
            this.выбратьToolStripMenuItem.Name = "выбратьToolStripMenuItem";
            this.выбратьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выбратьToolStripMenuItem.Text = "Выбрать файл";
            this.выбратьToolStripMenuItem.Click += new System.EventHandler(this.choose_procesor);
            // 
            // Postprocessor_contextMenu
            // 
            this.Postprocessor_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьФайлToolStripMenuItem1});
            this.Postprocessor_contextMenu.Name = "Postprocesor_contextMenu";
            this.Postprocessor_contextMenu.Size = new System.Drawing.Size(154, 26);
            // 
            // выбратьФайлToolStripMenuItem1
            // 
            this.выбратьФайлToolStripMenuItem1.Name = "выбратьФайлToolStripMenuItem1";
            this.выбратьФайлToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.выбратьФайлToolStripMenuItem1.Text = "Выбрать файл";
            this.выбратьФайлToolStripMenuItem1.Click += new System.EventHandler(this.choose_postprocesor);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.Postprocessor_button);
            this.Controls.Add(this.Processor_button);
            this.Controls.Add(this.Preprocessor_button);
            this.Name = "MainMenu";
            this.Text = "SOPR";
            this.Preprocessor_contextMenu.ResumeLayout(false);
            this.Processor_contextMenu.ResumeLayout(false);
            this.Postprocessor_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Preprocessor_button;
        private System.Windows.Forms.Button Processor_button;
        private System.Windows.Forms.Button Postprocessor_button;
        private System.Windows.Forms.ContextMenuStrip Preprocessor_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem новыйПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьФайлToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Processor_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem выбратьToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip Postprocessor_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem выбратьФайлToolStripMenuItem1;
    }
}

