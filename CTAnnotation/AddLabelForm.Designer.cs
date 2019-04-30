namespace CTAnnotation
{
    partial class AddLabelForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelColorComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addLabelButton = new System.Windows.Forms.Button();
            this.labelNameCombobox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNameCombobox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelColorComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 107);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 5;
            // 
            // labelColorComboBox
            // 
            this.labelColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.labelColorComboBox.FormattingEnabled = true;
            this.labelColorComboBox.Location = new System.Drawing.Point(85, 53);
            this.labelColorComboBox.Name = "labelColorComboBox";
            this.labelColorComboBox.Size = new System.Drawing.Size(121, 21);
            this.labelColorComboBox.TabIndex = 3;
            this.labelColorComboBox.SelectedIndexChanged += new System.EventHandler(this.labelColorComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Label Name:";
            // 
            // addLabelButton
            // 
            this.addLabelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addLabelButton.Location = new System.Drawing.Point(0, 108);
            this.addLabelButton.Name = "addLabelButton";
            this.addLabelButton.Size = new System.Drawing.Size(334, 28);
            this.addLabelButton.TabIndex = 1;
            this.addLabelButton.Text = "Add Label";
            this.addLabelButton.UseVisualStyleBackColor = true;
            this.addLabelButton.Click += new System.EventHandler(this.addLabelButton_Click);
            // 
            // labelNameCombobox
            // 
            this.labelNameCombobox.FormattingEnabled = true;
            this.labelNameCombobox.Location = new System.Drawing.Point(86, 13);
            this.labelNameCombobox.Name = "labelNameCombobox";
            this.labelNameCombobox.Size = new System.Drawing.Size(121, 21);
            this.labelNameCombobox.TabIndex = 6;
            this.labelNameCombobox.SelectedIndexChanged += new System.EventHandler(this.labelNameCombobox_SelectedIndexChanged);
            // 
            // AddLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 136);
            this.Controls.Add(this.addLabelButton);
            this.Controls.Add(this.panel1);
            this.Name = "AddLabelForm";
            this.Text = "Add Label";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox labelColorComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addLabelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox labelNameCombobox;
    }
}