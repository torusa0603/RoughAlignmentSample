using System;

namespace Camera
{
    public class CCameraMain
    {
        AbsCCameraBase m_cCamera;
        public bool m_bOpened { get; private set; } = false;
        public enum enCameraType
        {
            GigE,
            USB
        }

        /// <summary>
        /// 開始処理
        /// </summary>
        /// <param name="nenCameraType"></param>
        /// <returns></returns>
        public int Init(enCameraType nenCameraType)
        {
            int i_ret;
            // カメラの種類を選択
            switch (nenCameraType)
            {
                case enCameraType.GigE:
                    m_cCamera = new CMIL();
                    break;
                case enCameraType.USB:
                    m_cCamera = new COpenCV();
                    break;
            }

            //　カメラオープン
            i_ret = m_cCamera.Open();

            switch (i_ret)
            {
                case 0:
                    break;
                case -1:
                    return -1;
                default:
                    return -2;
            }

            m_bOpened = true;

            return 0;
        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void End()
        {
            if (m_bOpened)
            {
                m_cCamera.Close();
            }
        }

        /// <summary>
        /// 画像を一枚表示する
        /// </summary>
        /// <returns></returns>
        public int ShowImage()
        {
            return 0;
        }

        /// <summary>
        /// ディスプレイにカメラ画像を連続で表示する
        /// </summary>
        /// <returns></returns>
        public int ConnectCameraAndDisplay()
        {
            return 0;
        }

        /// <summary>
        /// ディスプレイの画像を保存する
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return 0;
        }

        /// <summary>
        /// パターンマッチングを行う
        /// </summary>
        /// <returns></returns>
        public int PatternMatching()
        {
            return 0;
        }

    }
}
