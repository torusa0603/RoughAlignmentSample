using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camera;

namespace RoughAlignmentSample
{
    class CProcess
    {
        //　唯一のインスタンス
        private static CProcess m_instance;
        
        

        //　インスタンスのプロパティ。読み込み専用
        public static CProcess Instance
        {
            get
            {
                if (CProcess.m_instance == null)
                {
                    CProcess.m_instance = new CProcess();
                }
                return m_instance;
            }
        }

        public int InitProcess()
        {
            return 0;
        }

    }
}
