using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camera.Parameter;
using System.Windows.Forms;

namespace Camera
{
    /// <summary>
    /// カメラクラスの抽象クラス
    /// </summary>
    abstract class AbsCCameraBase
    {
        public abstract int Open(IParameter ncParameter);
        public abstract int Close();
        public abstract int ShowImage(Panel nplDisplay);
        public abstract int ConnectCameraAndDisplay();
        public abstract int Save();
        public abstract int PatternMatching();
    }
}
