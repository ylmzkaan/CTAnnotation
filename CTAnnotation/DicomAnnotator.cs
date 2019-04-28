using EvilDICOM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTAnnotation
{
    class DicomAnnotator
    {
        private Form form;
        private string[] dicomPaths;
        private List<DICOMObject> dicomObjs = new List<DICOMObject>();

        public DicomAnnotator(Form form)
        {
            this.form = form;
        }

        public string[] DicomPaths
        {
            get { return dicomPaths; }
            set
            {
                dicomPaths = value;
                dicomObjs = DicomLibrary.readDicomFromPaths(dicomPaths);
            }
        }

        public List<DICOMObject> DicomObjs
        {
            get { return dicomObjs; }
            set { dicomObjs = value; }
        }
    }
}
