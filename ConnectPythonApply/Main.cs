using System;

namespace Yolov5
{
    public class CMain
    {
        CSocket m_cSocket = new CSocket();
        CPython m_cPython = new CPython();

        public int Init()
        {
            // python(サーバーモード)を起動する

            // ソケット通信(クライアントモード)を行う

            return 0;
        }

        public void End()
        {
            // 切断コマンドを送信

            // ソケットを切断

            //　pythonを停止させる
        }
    }
}
