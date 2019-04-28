using EvilDICOM.Core;
using EvilDICOM.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CTAnnotation
{
    class DicomLibrary
    {
        public static List<DICOMObject> readDicomFromPaths(string[] dicomPaths)
        {
            List<DICOMObject> dicoms = new List<DICOMObject>();
            foreach (string path in dicomPaths)
            {
                DICOMObject dcm = DICOMObject.Read(@path);
                dicoms.Add(dcm);
            }
            List<DICOMObject> sortedDicoms = dicoms.OrderBy(o => o.FindFirst(TagHelper.InstanceNumber).DData).ToList();
            return sortedDicoms;
        }

        public static Image loadImage(DICOMObject dcm)
        {
            string photo = dcm.FindFirst(TagHelper.PhotometricInterpretation).DData.ToString();
            ushort bitsAllocated = (ushort) dcm.FindFirst(TagHelper.BitsAllocated).DData;
            ushort highBit = (ushort) dcm.FindFirst(TagHelper.HighBit).DData;
            ushort bitsStored = (ushort) dcm.FindFirst(TagHelper.BitsStored).DData;
            double intercept = (double) dcm.FindFirst(TagHelper.RescaleIntercept).DData;
            double slope = (double) dcm.FindFirst(TagHelper.RescaleSlope).DData;
            ushort rows = (ushort) dcm.FindFirst(TagHelper.Rows).DData;
            ushort colums = (ushort) dcm.FindFirst(TagHelper.Columns).DData;
            ushort pixelRepresentation = (ushort) dcm.FindFirst(TagHelper.PixelRepresentation).DData;
            List<byte> pixelData = (List<byte>) dcm.FindFirst(TagHelper.PixelData).DData_;
            double window = (double) dcm.FindFirst(TagHelper.WindowWidth).DData;
            double level = (double) dcm.FindFirst(TagHelper.WindowCenter).DData;
            int minVal = 0;
            int maxVal = 255;

            if (!photo.Contains("MONOCHROME"))//just works for gray images
                throw new Exception("Dicom file should be gray.");

            int index = 0;
            byte[] outPixelData = new byte[rows * colums * 4];//rgba
            ushort mask = (ushort) (ushort.MaxValue >> (bitsAllocated - bitsStored));
            double maxval = Math.Pow(2, bitsStored);

            for (int i = 0; i < pixelData.Count; i += 2)
            {
                ushort gray = (ushort)((ushort)(pixelData[i]) + (ushort)(pixelData[i + 1] << 8));
                double valgray = gray & mask;//remove not used bits

                if (pixelRepresentation == 1)// the last bit is the sign, apply a2 complement
                {
                    if (valgray > (maxval / 2))
                        valgray = (valgray - maxval);
                }

                valgray = slope * valgray + intercept;//modality lut

                //This is  the window level algorithm
                double half = ((window - 1) / 2.0) - 0.5;

                if (valgray <= level - half)
                    valgray = 0;
                else if (valgray >= level + half)
                    valgray = 255;
                else
                    valgray = ((valgray - (level - 0.5)) / (window - 1) + 0.5) * 255;

                outPixelData[index] = (byte)valgray;
                outPixelData[index + 1] = (byte)valgray;
                outPixelData[index + 2] = (byte)valgray;
                outPixelData[index + 3] = 255;

                index += 4;
            }


            Image newImage = ImageFromRawBgraArray(outPixelData, colums, rows);
            return newImage;
        }

        public static Image ImageFromRawBgraArray(byte[] arr, int width, int height)
        {
            var output = new Bitmap(width, height);
            var rect = new Rectangle(0, 0, width, height);
            var bmpData = output.LockBits(rect, ImageLockMode.ReadWrite, output.PixelFormat);
            var ptr = bmpData.Scan0;
            Marshal.Copy(arr, 0, ptr, arr.Length);
            output.UnlockBits(bmpData);
            return output;
        }
    }
}
