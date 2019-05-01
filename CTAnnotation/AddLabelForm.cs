using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTAnnotation
{
    public partial class AddLabelForm : Form
    {
        Form1 mainForm;

        private List<String> availableNames = new List<String> { "Normal", "Ground-Glass", "Reticular", "Honeycombing", "Low-Attenuation", "Consolidation",
                                                                 "Vessel", "Airway", "Nodule", "Cyst", "Bronchiectasis" };
        private List<Color> availableColors = new List<Color> { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Magenta, Color.Brown, Color.Orange,
                                                                Color.Pink, Color.Purple, Color.RoyalBlue, Color.Turquoise, Color.Cyan};
        
        public AddLabelForm(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            foreach (string name in availableNames) { labelNameCombobox.Items.Add(name); }
            foreach (Color color in availableColors) { labelColorComboBox.Items.Add(color.Name); }

            addLabelButton.Enabled = false;
        }

        private void addLabelButton_Click(object sender, EventArgs e)
        {
            if (labelNameCombobox.SelectedIndex == -1)
            {
                label4.Text = "Label name cannot be empty.";
                return;
            }

            if (labelColorComboBox.SelectedIndex == -1)
            {
                label4.Text = "Label color cannot be empty.";
                return;
            }

            Color color = Color.FromName(labelColorComboBox.SelectedItem.ToString());
            if (color == null)
            {
                label4.Text = "Wrong label color.";
                return;
            }

            Label labelWithSameColor = mainForm.DicomAnnotator.Labels.Find(m => m.color == color);
            if (labelWithSameColor != null)
            {
                label4.Text = "Label color already used.";
                return;
            }

            ushort currentLabelIndex = mainForm.DicomAnnotator.CurrentLabelIndex++;

            string labelName = labelColorComboBox.SelectedItem.ToString();
            Label newLabel = new Label(labelName, currentLabelIndex, color);
            mainForm.DicomAnnotator.Labels.Add(newLabel);

            mainForm.addLabelToPanel1(newLabel);

            availableNames.Remove(labelName);
            availableColors.Remove(color);

            this.Close();
        }

        private void labelColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelNameCombobox.SelectedIndex > -1 && labelColorComboBox.SelectedIndex > -1)
            {
                addLabelButton.Enabled = true;
            }
        }

        private void labelNameCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelNameCombobox.SelectedIndex > -1 && labelColorComboBox.SelectedIndex > -1)
            {
                addLabelButton.Enabled = true;
            }
        }
    }
}
