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
        //private Form1 form;
        private string[] dicomPaths;
        private List<DICOMObject> dicomObjs;

        private ushort[,,] annotationData;

        private List<Label> labels;
        private int currentLabelIndex;

        private string saveData;

        public DicomAnnotator()
        {
            //this.form = form;

            dicomObjs = new List<DICOMObject>();
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
                dicomObjs = DicomLibrary.readDicomFromPaths(dicomPaths);
                int nSlices = dicomPaths.Length;
                annotationData = new ushort[nSlices, 512, 512];
            }
        }

        [ScriptIgnore]
        public List<DICOMObject> DicomObjs
        {
            get { return dicomObjs; }
            set { dicomObjs = value; }
        }

        public ushort[,,] AnnotationData
        {
            get { return annotationData; }
            set { annotationData = value; }
        }

        public List<Label> Labels
        {
            get { return labels; }
            set { labels = value; }
        }

        public int CurrentLabelIndex
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
