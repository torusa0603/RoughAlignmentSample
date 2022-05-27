using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Camera.Parameter;
using OpenCvSharp.Extensions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Camera
{
    class COpenCV : AbsCCameraBase
    {

        VideoCapture m_camera;
        CUSB m_cUSB = new CUSB();
        Mat m_mtImg = new Mat();
        /// <summary>
        /// カメラオープン
        /// </summary>
        /// <returns></returns>
        public override int Open(IParameter ncParameter)
        {
            m_cUSB = ((CUSB)ncParameter).ShallowCopy();

            m_camera.Open(m_cUSB.PortNumber);

            if (!m_camera.IsOpened())
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// カメラクローズ
        /// </summary>
        /// <returns></returns>
        public override int Close()
        {
            return 0;
        }

        /// <summary>
        /// 画像を表示する
        /// </summary>
        /// <returns></returns>
        public override int ShowImage(Panel nplDisplay)
        {
            VideoCapture(nplDisplay);

            return 0;
        }

        private async void VideoCapture(Panel nplDisplay)
        {
            await Task.Run(() =>
            {
                bool IsLoop = true;
                while (IsLoop)
                {
                    m_camera.Read(m_mtImg);

                    if (m_mtImg.Empty()) break;

                    nplDisplay.Invoke((MethodInvoker)(() => {
                        nplDisplay.BackgroundImage = BitmapConverter.ToBitmap(m_mtImg);
                    }));
                }
            });


        }

        public override int ConnectCameraAndDisplay()
        {
            return 0;
        }

        /// <summary>
        /// 画像保存する
        /// </summary>
        /// <returns></returns>
        public override int Save()
        {
            return 0;
        }

        /// <summary>
        /// パターンマッチング
        /// </summary>
        /// <returns></returns>
        public override int PatternMatching()
        {
            return 0;
        }
    }
}
