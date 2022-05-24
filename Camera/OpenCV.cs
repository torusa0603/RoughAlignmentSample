using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using RoughAlignmentSample.Camera.Parameter;
using Newtonsoft.Json;

namespace Camera
{
    class COpenCV : AbsCCameraBase
    {
        public override int Open()
        {
            return 0;
        }
        public override int Close()
        {
            return 0;
        }
        public override int ShowImage()
        {
            return 0;
        }
        public override int ConnectCameraAndDisplay()
        {
            return 0;
        }
        public override int Save()
        {
            return 0;
        }
        public override int PatternMatching()
        {
            return 0;
        }
    }
}
