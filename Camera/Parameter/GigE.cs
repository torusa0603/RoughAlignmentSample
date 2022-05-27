﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera.Parameter
{
    public class CGigE: IParameter
    {
        /// <summary>
        /// 識別ネーム
        /// </summary>
        public string IdentifyName { get; set; }

        /// <summary>
        /// 現在未使用
        /// </summary>
        public int CameraType { get; set; }

        /// <summary>
        /// DCFファイルパス
        /// </summary>
        public string CameraFile { get; set; }

        /// <summary>
        /// 取得画像幅
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 取得画像高さ
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 現在未使用
        /// </summary>
        public int Color { get; set; }

        /// <summary>
        /// 現在未使用
        /// </summary>
        public int ImagePose { get; set; }

        /// <summary>
        /// 現在未使用
        /// </summary>
        public int UseSerialComm { get; set; }

        /// <summary>
        /// 現在未使用
        /// </summary>
        public int COMNo { get; set; }

        /// <summary>
        /// gigeカメラのIPアドレス
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// gigeカメラの製造メーカー
        /// </summary>
        public int Manufacturer { get; set; }

        /// <summary>
        /// パラメータの有効性を検査
        /// </summary>
        /// <returns>0:異常なし、-1:取得画像幅異常、-2:取得画像高さ異常</returns>
        public int CheckVariableValidity()
        {
            return 0;
        }

        public void Dispose()
        {
            
        }

        public CGigE ShallowCopy() => (CGigE)MemberwiseClone();
    }
}
