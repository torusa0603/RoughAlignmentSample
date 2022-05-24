using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoughAlignmentSample.Camera.Parameter;
using Newtonsoft.Json;
using MatroxCS;

namespace Camera
{
    class CMIL : AbsCCameraBase
    {
        /// <summary>
        /// カメラオープン
        /// </summary>
        /// <returns></returns>
        public override int Open()
        {
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
        public override int ShowImage()
        {
            return 0;
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
