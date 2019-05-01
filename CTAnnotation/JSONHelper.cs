﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CTAnnotation
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1024000000;
            return serializer.Serialize(obj);
        }
        
        public static object FromJSON(string filename)
        {
            string text = File.ReadAllText(filename);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 1024000000;
            DicomAnnotator loadedDicomAnnotator = serializer.Deserialize<DicomAnnotator>(text);
            return loadedDicomAnnotator;
        }
    }
}
