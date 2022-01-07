
namespace Sopr.Forms.Post
{
    partial class Postprocessor
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
            this.components = new System.ComponentModel.Container();
            this.table_button = new System.Windows.Forms.Button();
            this.chart_button = new System.Windows.Forms.Button();
            this.plot_button = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.TextBox();
            this.Graphic = new System.Windows.Forms.PictureBox();
            this.TableStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TableNItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableUItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableSigItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChartNItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartUItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChartSigItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlotStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PlotNItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlotUItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlotSigItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).BeginInit();
            this.TableStrip.SuspendLayout();
            this.ChartStrip.SuspendLayout();
            this.PlotStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_button
            // 
            this.table_button.Location = new System.Drawing.Point(12, 12);
            this.table_button.Name = "table_button";
            this.table_button.Size = new System.Drawing.Size(150, 50);
            this.table_button.TabIndex = 0;
            this.table_button.Text = "Таблицы";
            this.table_button.UseVisualStyleBackColor = true;
            this.table_button.Click += new System.EventHandler(this.table_button_Click);
            // 
            // chart_button
            // 
            this.chart_button.Location = new System.Drawing.Point(168, 12);
            this.chart_button.Name = "chart_button";
            this.chart_button.Size = new System.Drawing.Size(150, 50);
            this.chart_button.TabIndex = 1;
            this.chart_button.Text = "Графики";
            this.chart_button.UseVisualStyleBackColor = true;
            this.chart_button.Click += new System.EventHandler(this.chart_button_Click);
            // 
            // plot_button
            // 
            this.plot_button.Location = new System.Drawing.Point(324, 12);
            this.plot_button.Name = "plot_button";
            this.plot_button.Size = new System.Drawing.Size(150, 50);
            this.plot_button.TabIndex = 2;
            this.plot_button.Text = "Эпюры";
            this.plot_button.UseVisualStyleBackColor = true;
            this.plot_button.Click += new System.EventHandler(this.plot_button_Click);
            // 
            // table
            // 
            this.table.BackColor = System.Drawing.SystemColors.Control;
            this.table.Location = new System.Drawing.Point(12, 68);
            this.table.Multiline = true;
            this.table.Name = "table";
            this.table.Size = new System.Drawing.Size(1072, 475);
            this.table.TabIndex = 3;
            // 
            // Graphic
            // 
            this.Graphic.Location = new System.Drawing.Point(12, 68);
            this.Graphic.Name = "Graphic";
            this.Graphic.Size = new System.Drawing.Size(1072, 475);
            this.Graphic.TabIndex = 4;
            this.Graphic.TabStop = false;
            // 
            // TableStrip
            // 
            this.TableStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TableNItem,
            this.TableUItem,
            this.TableSigItem});
            this.TableStrip.Name = "TableStrip";
            this.TableStrip.Size = new System.Drawing.Size(84, 70);
            // 
            // TableNItem
            // 
            this.TableNItem.Name = "TableNItem";
            this.TableNItem.Size = new System.Drawing.Size(83, 22);
            this.TableNItem.Text = "N";
            this.TableNItem.Click += new System.EventHandler(this.TableNItem_Click);
            // 
            // TableUItem
            // 
            this.TableUItem.Name = "TableUItem";
            this.TableUItem.Size = new System.Drawing.Size(83, 22);
            this.TableUItem.Text = "U";
            this.TableUItem.Click += new System.EventHandler(this.TableUItem_Click);
            // 
            // TableSigItem
            // 
            this.TableSigItem.Name = "TableSigItem";
            this.TableSigItem.Size = new System.Drawing.Size(83, 22);
            this.TableSigItem.Text = "σ";
            this.TableSigItem.Click += new System.EventHandler(this.TableSigItem_Click);
            // 
            // ChartStrip
            // 
            this.ChartStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChartNItem,
            this.ChartUItem,
            this.ChartSigItem});
            this.ChartStrip.Name = "ChartStrip";
            this.ChartStrip.Size = new System.Drawing.Size(84, 70);
            // 
            // ChartNItem
            // 
            this.ChartNItem.Name = "ChartNItem";
            this.ChartNItem.Size = new System.Drawing.Size(83, 22);
            this.ChartNItem.Text = "N";
            this.ChartNItem.Click += new System.EventHandler(this.ChartNItem_Click);
            // 
            // ChartUItem
            // 
            this.ChartUItem.Name = "ChartUItem";
            this.ChartUItem.Size = new System.Drawing.Size(83, 22);
            this.ChartUItem.Text = "U";
            this.ChartUItem.Click += new System.EventHandler(this.ChartUItem_Click);
            // 
            // ChartSigItem
            // 
            this.ChartSigItem.Name = "ChartSigItem";
            this.ChartSigItem.Size = new System.Drawing.Size(83, 22);
            this.ChartSigItem.Text = "σ";
            this.ChartSigItem.Click += new System.EventHandler(this.ChartSigItem_Click);
            // 
            // PlotStrip
            // 
            this.PlotStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlotNItem,
            this.PlotUItem,
            this.PlotSigItem});
            this.PlotStrip.Name = "contextMenuStrip2";
            this.PlotStrip.Size = new System.Drawing.Size(84, 70);
            // 
            // PlotNItem
            // 
            this.PlotNItem.Name = "PlotNItem";
            this.PlotNItem.Size = new System.Drawing.Size(83, 22);
            this.PlotNItem.Text = "N";
            this.PlotNItem.Click += new System.EventHandler(this.PlotNItem_Click);
            // 
            // PlotUItem
            // 
            this.PlotUItem.Name = "PlotUItem";
            this.PlotUItem.Size = new System.Drawing.Size(83, 22);
            this.PlotUItem.Text = "U";
            this.PlotUItem.Click += new System.EventHandler(this.PlotUItem_Click);
            // 
            // PlotSigItem
            // 
            this.PlotSigItem.Name = "PlotSigItem";
            this.PlotSigItem.Size = new System.Drawing.Size(83, 22);
            this.PlotSigItem.Text = "σ";
            this.PlotSigItem.Click += new System.EventHandler(this.PlotSigItem_Click);
            // 
            // Postprocessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 555);
            this.Controls.Add(this.Graphic);
            this.Controls.Add(this.table);
            this.Controls.Add(this.plot_button);
            this.Controls.Add(this.chart_button);
            this.Controls.Add(this.table_button);
            this.Name = "Postprocessor";
            this.Text = "Postprocessor";
            ((System.ComponentModel.ISupportInitialize)(this.Graphic)).EndInit();
            this.TableStrip.ResumeLayout(false);
            this.ChartStrip.ResumeLayout(false);
            this.PlotStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button table_button;
        private System.Windows.Forms.Button chart_button;
        private System.Windows.Forms.Button plot_button;
        private System.Windows.Forms.TextBox table;
        private System.Windows.Forms.PictureBox Graphic;
        private System.Windows.Forms.ContextMenuStrip TableStrip;
        private System.Windows.Forms.ToolStripMenuItem TableNItem;
        private System.Windows.Forms.ToolStripMenuItem TableUItem;
        private System.Windows.Forms.ToolStripMenuItem TableSigItem;
        private System.Windows.Forms.ContextMenuStrip ChartStrip;
        private System.Windows.Forms.ToolStripMenuItem ChartNItem;
        private System.Windows.Forms.ToolStripMenuItem ChartUItem;
        private System.Windows.Forms.ToolStripMenuItem ChartSigItem;
        private System.Windows.Forms.ContextMenuStrip PlotStrip;
        private System.Windows.Forms.ToolStripMenuItem PlotNItem;
        private System.Windows.Forms.ToolStripMenuItem PlotUItem;
        private System.Windows.Forms.ToolStripMenuItem PlotSigItem;
    }
}