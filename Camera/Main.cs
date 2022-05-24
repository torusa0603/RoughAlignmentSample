using System;

namespace Camera
{
    public class CCameraMain
    {
        AbsCCameraBase m_cCamera;
        public enum enCameraType
        {
            GigE,
            USB
        }

        public int Init(enCameraType nenCameraType)
        {
            int i_ret;
            switch (nenCameraType)
            {
                case enCameraType.GigE:
                    m_cCamera = new CMIL();
                    break;
                case enCameraType.USB:
                    m_cCamera = new COpenCV();
                    break;
            }

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

            return 0;
        }

    }
}
