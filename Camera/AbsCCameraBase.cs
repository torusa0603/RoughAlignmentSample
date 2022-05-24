using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    /// <summary>
    /// カメラクラスの抽象クラス
    /// </summary>
    abstract class AbsCCameraBase
    {
        public abstract int Open();
        public abstract int Close();
        public abstract int ShowImage();
        public abstract int ConnectCameraAndDisplay();
        public abstract int Save();
        public abstract int PatternMatching();
    }
}
