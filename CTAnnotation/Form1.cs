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
        private DicomAnnotator dicomAnnotator;
        private int currentDicomFileIndex;
         
        private Graphics[] graphics;
        private SolidBrush brush = new SolidBrush(Color.Green);

        private ushort[ , , ] annotationData;

        private const int dcmHeight = 512;
        private const int dcmWidth = 512;

        public Form1()
        {
            InitializeComponent();
            dicomAnnotator = new DicomAnnotator(this);
        }

        private void openDicomFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string allowedExtension = "*.dcm";
                string[] dicomPaths = Directory.GetFiles(fbd.SelectedPath, allowedExtension, SearchOption.AllDirectories);
                int nSlices = dicomPaths.Length;

                if ( dicomPaths.Length == 0)
                {
                    MessageBox.Show("The folder you selected does not contain any dicom files", "No Dicom File Found", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dicomAnnotator.DicomPaths = dicomPaths;

                graphics = new Graphics[nSlices];
                annotationData = new ushort[nSlices, 512, 512];

                Image firstDCM = DicomLibrary.loadImage(dicomAnnotator.DicomObjs[0]);
                this.pictureBox1.Image = firstDCM;
                currentDicomFileIndex = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (dicomAnnotator.DicomObjs.Count == 0)
            {
                return;
            }

            if (e.KeyCode == Keys.Down)
            {
                currentDicomFileIndex++;
                if (currentDicomFileIndex >= dicomAnnotator.DicomObjs.Count)
                {
                    currentDicomFileIndex = 0;
                }
                Image dcm = DicomLibrary.loadImage(dicomAnnotator.DicomObjs[currentDicomFileIndex]);
                this.pictureBox1.Image = dcm;
                this.label2.Text = String.Format("Index: {0}", currentDicomFileIndex);
            }
            else if (e.KeyCode == Keys.Up)
            {
                currentDicomFileIndex--;
                if (currentDicomFileIndex < 0)
                {
                    currentDicomFileIndex = dicomAnnotator.DicomObjs.Count-1;
                }

                Image dcm = DicomLibrary.loadImage(dicomAnnotator.DicomObjs[currentDicomFileIndex]);
                this.pictureBox1.Image = dcm;
                this.label2.Text = String.Format("Index: {0}", currentDicomFileIndex);
            }

            if (graphics[currentDicomFileIndex] == null && this.pictureBox1.Image != null)
            {
                graphics[currentDicomFileIndex] = Graphics.FromImage(this.pictureBox1.Image);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int adjustedX = (int) ((double)e.X / this.pictureBox1.Size.Width * dcmWidth);
            int adjustedY = (int) ((double)e.Y / this.pictureBox1.Size.Height * dcmHeight);
            this.label1.Text = String.Format("X: {0} Y: {1}", adjustedX, adjustedY);
        }
    }
}
