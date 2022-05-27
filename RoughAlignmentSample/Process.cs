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
        public CCameraMain m_cCamera = new CCameraMain();

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
            // exeファイルのいるフォルダーパスを取得
            string m_strExeFolderPath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            // 設定ファイルパスを作成
            string str_setting_file_path = $@"{m_strExeFolderPath}\setting.json";
            // カメラインスタンスの作成
            m_cCamera.Init(CCameraMain.enCameraType.GigE, str_setting_file_path);

            return 0;
        }

    }
}
