using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTAnnotation
{
    public class SaveData
    {
        private ushort[,,] annotationData;
        private ushort[] ctDim;

        public SaveData(ushort[,,] annotationData, ushort[] ctDim)
        {
            this.annotationData = annotationData;
            this.ctDim = ctDim;
        }

        public ushort[,,] AnnotationData
        {
            get { return annotationData; }
            set { annotationData = value; }
        }

        public ushort[] CtDim
        {
            get { return ctDim; }
            set { ctDim = value; }
        }
    }
}
