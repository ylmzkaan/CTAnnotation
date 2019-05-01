namespace CTAnnotation
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicomFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAnnotationMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnnotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.penSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.penSizeLabel = new System.Windows.Forms.Label();
            this.button1 = new CTAnnotation.NonFocusButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exportAnnotationMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumericUpDown)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.labelsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDicomFolderToolStripMenuItem,
            this.loadAnnotationMenuItem1,
            this.saveAnnotationToolStripMenuItem,
            this.exportAnnotationMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDicomFolderToolStripMenuItem
            // 
            this.openDicomFolderToolStripMenuItem.Name = "openDicomFolderToolStripMenuItem";
            this.openDicomFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDicomFolderToolStripMenuItem.Text = "Open Dicom Folder";
            this.openDicomFolderToolStripMenuItem.Click += new System.EventHandler(this.openDicomFolderToolStripMenuItem_Click);
            // 
            // loadAnnotationMenuItem1
            // 
            this.loadAnnotationMenuItem1.Name = "loadAnnotationMenuItem1";
            this.loadAnnotationMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loadAnnotationMenuItem1.Text = "Load Annotation";
            this.loadAnnotationMenuItem1.Click += new System.EventHandler(this.loadAnnotationMenuItem1_Click);
            // 
            // saveAnnotationToolStripMenuItem
            // 
            this.saveAnnotationToolStripMenuItem.Enabled = false;
            this.saveAnnotationToolStripMenuItem.Name = "saveAnnotationToolStripMenuItem";
            this.saveAnnotationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAnnotationToolStripMenuItem.Text = "Save Annotation";
            this.saveAnnotationToolStripMenuItem.Click += new System.EventHandler(this.saveAnnotationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // labelsToolStripMenuItem
            // 
            this.labelsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLabelToolStripMenuItem});
            this.labelsToolStripMenuItem.Name = "labelsToolStripMenuItem";
            this.labelsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.labelsToolStripMenuItem.Text = "Labels";
            // 
            // addLabelToolStripMenuItem
            // 
            this.addLabelToolStripMenuItem.Name = "addLabelToolStripMenuItem";
            this.addLabelToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addLabelToolStripMenuItem.Text = "Add Label";
            this.addLabelToolStripMenuItem.Click += new System.EventHandler(this.addLabelToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.penSizeNumericUpDown);
            this.panel1.Controls.Add(this.penSizeLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 37);
            this.panel1.TabIndex = 1;
            // 
            // penSizeNumericUpDown
            // 
            this.penSizeNumericUpDown.Enabled = false;
            this.penSizeNumericUpDown.Location = new System.Drawing.Point(185, 10);
            this.penSizeNumericUpDown.Name = "penSizeNumericUpDown";
            this.penSizeNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.penSizeNumericUpDown.TabIndex = 2;
            this.penSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.penSizeNumericUpDown.ValueChanged += new System.EventHandler(this.penSizeNumericUpDown_ValueChanged);
            // 
            // penSizeLabel
            // 
            this.penSizeLabel.AutoSize = true;
            this.penSizeLabel.Location = new System.Drawing.Point(136, 12);
            this.penSizeLabel.Name = "penSizeLabel";
            this.penSizeLabel.Size = new System.Drawing.Size(52, 13);
            this.penSizeLabel.TabIndex = 1;
            this.penSizeLabel.Text = "Pen Size:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hide Annotation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 658);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 16);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(744, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Index: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(789, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X: 0 Y: 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 597);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(835, 595);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // exportAnnotationMenuItem1
            // 
            this.exportAnnotationMenuItem1.Enabled = false;
            this.exportAnnotationMenuItem1.Name = "exportAnnotationMenuItem1";
            this.exportAnnotationMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exportAnnotationMenuItem1.Text = "Export Annotation";
            this.exportAnnotationMenuItem1.Click += new System.EventHandler(this.exportAnnotationMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 674);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CT Annotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penSizeNumericUpDown)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDicomFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnnotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem labelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabelToolStripMenuItem;
        private NonFocusButton button1;
        private System.Windows.Forms.ToolStripMenuItem loadAnnotationMenuItem1;
        private System.Windows.Forms.NumericUpDown penSizeNumericUpDown;
        private System.Windows.Forms.Label penSizeLabel;
        private System.Windows.Forms.ToolStripMenuItem exportAnnotationMenuItem1;
    }
}

