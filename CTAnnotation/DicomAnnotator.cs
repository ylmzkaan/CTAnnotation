using EvilDICOM.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CTAnnotation
{
    public class DicomAnnotator
    {
        private string[] dicomPaths;

        private Bitmap[] annotationGraphics;
        private ushort[,,] annotationData;
        private ushort[] metaData;

        private List<Label> labels;
        private ushort currentLabelIndex;

        private string saveData;

        public DicomAnnotator()
        {
            currentLabelIndex = 1;
            labels = new List<Label>();
        }

        public void updateSaveData()
        {
            saveData = JSONHelper.ToJSON(this);
        }

        public string[] DicomPaths
        {
            get { return dicomPaths; }
            set
            {
                dicomPaths = value;
                ushort nSlices = (ushort)dicomPaths.Length;
                metaData = new ushort[3] { nSlices, 512, 512};
                annotationData = new ushort[nSlices, 512, 512];
            }
        }

        public Bitmap[] AnnotationGraphics
        {
            get { return annotationGraphics; }
            set { annotationGraphics = value; }
        }

        public ushort[,,] AnnotationData
        {
            get { return annotationData; }
            set { annotationData = value; }
        }

        public ushort[] MetaData
        {
            get { return metaData; }
            set { metaData = value; }
        }

        public List<Label> Labels
        {
            get { return labels; }
            set { labels = value; }
        }

        public ushort CurrentLabelIndex
        {
            get { return currentLabelIndex; }
            set { currentLabelIndex = value; }
        }

        [ScriptIgnore]
        public string SaveData
        {
            get { this.updateSaveData();  return saveData; }
            set { saveData = value; }
        }
    }
}
