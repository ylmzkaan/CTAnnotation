using EvilDICOM.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CTAnnotation
{
    public partial class Form1 : Form
    {
        private string saveDir;
        private string autoSaveFileName;

        private DicomAnnotator dicomAnnotator;
        private int currentDicomFileIndex;
        private List<DICOMObject> dicomObjs;
         
        private Bitmap[] annotationGraphics;
        private Pen pen;
        private Pen erasePen;
        private Color DEFAULT_PEN_COLOR = Color.Green;

        private List<NonFocusButton> labelButtons;

        private Label currentLabel = null;
        private int annotationOpacity;
        private const int DEFAULT_OPACITY = 255;

        private int nSlices;
        private const int dcmHeight = 512;
        private const int dcmWidth = 512;

        private int adjustedWidth;
        private int adjustedHeight;

        private Point currentAdditionalLabelButtonPosition;
        private const int labelCheckboxOffset_X = 5;

        private const int MAX_PEN_SIZE = 10;
        private const int MIN_PEN_SIZE = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void openDicomFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string allowedExtension = "*.dcm";
                string[] dicomPaths = Directory.GetFiles(fbd.SelectedPath, allowedExtension, SearchOption.AllDirectories);                

                if ( dicomPaths.Length == 0)
                {
                    MessageBox.Show("The folder you selected does not contain any dicom files", "No Dicom File Found", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dicomAnnotator.DicomPaths = dicomPaths;
                initializeAnnotationDataFromCurrentDicomAnnotator();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int adjustedX = (int) ((double)e.X / this.pictureBox1.Size.Width * dcmWidth);
            int adjustedY = (int) ((double)e.Y / this.pictureBox1.Size.Height * dcmHeight);
            this.label1.Text = String.Format("X: {0} Y: {1}", adjustedX, adjustedY);

            if (pictureBox1.Image == null) { return; }
            if (currentLabel == null) { return; }
            
            if (e.Button == MouseButtons.Left)
            {
                if (dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] == 0)
                {
                    Image bmp = pictureBox1.Image;
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangle(pen, e.Location.X, e.Location.Y, adjustedWidth, adjustedHeight);
                        dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] = currentLabel.index;
                    }
                    pictureBox1.Image = bmp;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] != 0)
                {
                    deleteAnnotation(adjustedX, adjustedY, e);
                }
            }
        } // end pictureBox1_MouseMove

        private void deleteAnnotation(int adjustedX, int adjustedY, MouseEventArgs e)
        {
            Image bmp = pictureBox1.Image;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle areaToDelete = new Rectangle(e.Location.X, e.Location.Y, adjustedWidth, adjustedHeight);

                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.DrawRectangle(erasePen, areaToDelete);
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] = 0;
            }
            pictureBox1.Image = bmp;
        }
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null) { return; }
            if (currentLabel == null) { return; }

            int adjustedX = (int)((double)e.X / this.pictureBox1.Size.Width * dcmWidth);
            int adjustedY = (int)((double)e.Y / this.pictureBox1.Size.Height * dcmHeight);

            if (e.Button == MouseButtons.Left)
            {
                if (dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] == 0)
                {
                    Image bmp = pictureBox1.Image;
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawRectangle(pen, e.Location.X, e.Location.Y, adjustedWidth, adjustedHeight);
                        dicomAnnotator.AnnotationData[currentDicomFileIndex, adjustedY, adjustedX] = currentLabel.index;
                    }
                    pictureBox1.Image = bmp;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                deleteAnnotation(adjustedX, adjustedY, e);
            }
        } // end pictureBox1_MouseClick

        private void initAnnotationGraphics()
        {
            annotationGraphics = new Bitmap[nSlices];
            for (int i = 0; i < nSlices; ++i)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(Brushes.Transparent, new Rectangle(Point.Empty, bmp.Size));
                }
                annotationGraphics[i] = bmp;
            }
        }

        private void addLabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLabelForm addLabelForm = new AddLabelForm(this);
            addLabelForm.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (annotationGraphics == null) { return; }

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                button1.Text = "Show Annotation";
            }
            else
            {
                pictureBox1.Image = annotationGraphics[currentDicomFileIndex];
                button1.Text = "Hide Annotation";
            }
        }

        public void addLabelToPanel1(Label label)
        {
            NonFocusButton btn = new NonFocusButton();
            btn.Text = label.name;
            btn.Location = currentAdditionalLabelButtonPosition;
            btn.Size = button1.Size;
            btn.UseVisualStyleBackColor = false;
            btn.BackColor = label.color;
            btn.Click += labelSelectorButton_Clicked;

            panel1.Controls.Add(btn);
            labelButtons.Add(btn);

            currentAdditionalLabelButtonPosition.X += btn.Size.Width;

            btn.PerformClick();
        }

        private void labelSelectorButton_Clicked(object sender, EventArgs e)
        {
            NonFocusButton btn = (NonFocusButton)sender;
            currentLabel = this.DicomAnnotator.Labels.First(m => m.name == btn.Text);

            if (pen != null) { pen.Dispose(); }
            
            pen = new Pen(Color.FromArgb(annotationOpacity, currentLabel.color));

            NonFocusButton prevLabelBtn = labelButtons.Find(m => m.Enabled == false);
            if (prevLabelBtn != null)
            {
                prevLabelBtn.Enabled = true;
            }
            btn.Enabled = false;

            //penSizeNumericUpDown.Enabled = true;
        }

        public DicomAnnotator DicomAnnotator
        {
            get { return dicomAnnotator; }
            set { dicomAnnotator = value; }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dicomObjs.Count == 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                currentDicomFileIndex++;
                if (currentDicomFileIndex >= dicomObjs.Count)
                {
                    currentDicomFileIndex = 0;
                }
                Image dcm = DicomLibrary.loadImage(dicomObjs[currentDicomFileIndex]);
                this.pictureBox1.BackgroundImage = dcm;
                this.pictureBox1.Image = annotationGraphics[currentDicomFileIndex];
                this.label2.Text = String.Format("Index: {0}", currentDicomFileIndex);
            }
            else if (e.KeyCode == Keys.Up)
            {
                currentDicomFileIndex--;
                if (currentDicomFileIndex < 0)
                {
                    currentDicomFileIndex = dicomObjs.Count - 1;
                }

                Image dcm = DicomLibrary.loadImage(dicomObjs[currentDicomFileIndex]);
                this.pictureBox1.BackgroundImage = dcm;
                this.pictureBox1.Image = annotationGraphics[currentDicomFileIndex];
                this.label2.Text = String.Format("Index: {0}", currentDicomFileIndex);
            }
            else if (e.KeyCode == Keys.Tab)
            {
                button1_Click(button1, EventArgs.Empty); 
            }
        } // end Form1_KeyDown

        private void saveAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Browse to save annotation";
            sfd.Filter = "Json files (*.json)|*.json";
            sfd.CheckPathExists = true;

            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
            {
                dicomAnnotator.AnnotationGraphics = annotationGraphics;
                string json = JSONHelper.ToJSON(dicomAnnotator);
                File.WriteAllText(sfd.FileName, json);

                MessageBox.Show("Your data is succesfully saved.", "Save Succesful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Could not save the annotation data.", "Error while saving",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        private void loadAnnotationMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Filter = "Json files (*.json)|*.json";
            DialogResult result = fdlg.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = fdlg.FileName;
                DicomAnnotator loadedDicomAnnotator = JSONHelper.FromJSON<DicomAnnotator>(file);
                dicomAnnotator = loadedDicomAnnotator;
                annotationGraphics = dicomAnnotator.AnnotationGraphics;

                initializeAnnotationDataFromCurrentDicomAnnotator();
            }
        }

        private void initializeAnnotationDataFromCurrentDicomAnnotator()
        {
            if (dicomAnnotator.DicomPaths == null)
            {
                MessageBox.Show("Could not load the annotation data.", "Initialization Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dicomObjs = DicomLibrary.readDicomFromPaths(dicomAnnotator.DicomPaths);

            nSlices = dicomAnnotator.DicomPaths.Length;
            ushort[] ctDim = new ushort[3] { (ushort)nSlices, 512, 512 };
            dicomAnnotator.CtDim = ctDim;

            initAnnotationGraphics();

            currentDicomFileIndex = 0;
            label2.Text = String.Format("Index: {0}", currentDicomFileIndex);
            Image firstDCM = DicomLibrary.loadImage(dicomObjs[currentDicomFileIndex]);
            pictureBox1.BackgroundImage = firstDCM;
            pictureBox1.Image = annotationGraphics[currentDicomFileIndex];
            
            // Reset label button position
            currentAdditionalLabelButtonPosition = penSizeNumericUpDown.Location;
            currentAdditionalLabelButtonPosition.Y = button1.Location.Y;
            currentAdditionalLabelButtonPosition.X += penSizeNumericUpDown.Size.Width;
            currentAdditionalLabelButtonPosition.X += labelCheckboxOffset_X;

            if (dicomAnnotator.Labels != null)
            {
                if (labelButtons != null)
                {
                    foreach(Button btn in labelButtons) { panel1.Controls.Remove(btn); }
                }
                foreach(Label label in dicomAnnotator.Labels) { addLabelToPanel1(label); }
            }

            button1.Enabled = true;
            saveAnnotationToolStripMenuItem.Enabled = true;
            exportAnnotationMenuItem1.Enabled = true;
        }

        private void penSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (currentLabel == null) { return; }

            float penSize = (float)penSizeNumericUpDown.Value;
            if (penSize > MAX_PEN_SIZE)
            {
                penSize = MAX_PEN_SIZE;
                penSizeNumericUpDown.Value = (Decimal)penSize;
            }
            else if (penSize < MIN_PEN_SIZE)
            {
                penSize = MIN_PEN_SIZE;
                penSizeNumericUpDown.Value = (Decimal)penSize;
            }

            if (pen != null) { pen.Dispose(); }
            pen = new Pen(Color.FromArgb(annotationOpacity, currentLabel.color), penSize);

            penSizeLabel.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetStyle(
                            ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.DoubleBuffer,
                            true);

            dicomAnnotator = new DicomAnnotator();
            dicomObjs = new List<DICOMObject>();
            annotationOpacity = DEFAULT_OPACITY;

            erasePen = new Pen(Color.Transparent);

            labelButtons = new List<NonFocusButton>();

            adjustedWidth = (int)(this.pictureBox1.Size.Width / dcmWidth);
            adjustedHeight = (int)(this.pictureBox1.Size.Height / dcmHeight);

            currentAdditionalLabelButtonPosition = penSizeNumericUpDown.Location;
            currentAdditionalLabelButtonPosition.Y = button1.Location.Y;
            currentAdditionalLabelButtonPosition.X += penSizeNumericUpDown.Size.Width;
            currentAdditionalLabelButtonPosition.X += labelCheckboxOffset_X;

            saveDir = Application.StartupPath;
            autoSaveFileName = "CTAnnotation-AutoSave.json";

            ToolTip TP = new ToolTip();
            TP.ShowAlways = true;
            TP.SetToolTip(button1, "Show or hide annotation (Tab)");
        }

        private void exportAnnotationMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Browse to export annotation data";
            sfd.Filter = "Json Files (*.json)|*.json";
            sfd.DefaultExt = "json";
            sfd.CheckPathExists = true;

            DialogResult result = sfd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(sfd.FileName))
            {
                SaveData saveData = new SaveData(dicomAnnotator.AnnotationData, dicomAnnotator.CtDim);
                string saveDataString = JSONHelper.ToJSON(saveData);

                File.WriteAllText(sfd.FileName, saveDataString);

                MessageBox.Show("Data is succesfully exported.", "Save Succesful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Could not export the data.", "Error while saving",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    } // end Form1
} // end namespace CTAnnotation
