using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using MatroxCS.Parameter;

namespace Camera
{

    public class CJsonIO
    {
        const string m_strCommentCode = "###";    // コメントコード
        const string m_strNewLineCode = "\r\n";   // 改行コード

        /// <summary>
        /// Json形式ファイルからパラメータ値を抜き出し、インスタンスに代入する
        /// </summary>
        /// <param name="nstrFilePath">読み込むファイルのパス</param>
        /// <param name="ncParameter">読み込まれたパラメータを代入するインスタンス</param>
        /// <returns>0:正常終了、-1:ファイルからの読み込み失敗、-2:json構文エラー、-3:異常値が代入された</returns>
        public static int Load<T>(string nstrFilePath, ref T ncParameter)
        {
            string str_jsonfile_sentence;
            try
            {
                // ファイルから文字列を丸ごと抜き出す
                str_jsonfile_sentence = File.ReadAllText(nstrFilePath);
            }
            catch
            {
                // ファイルからの読み込み失敗
                return -1;
            }
            // 文章内のコメントコード～改行コード間にある文とコメントコードを削除する
            string str_jsonfile_sentence_commentout = RemoveComment(str_jsonfile_sentence);
            try
            {
                // コメントアウトの箇所を削除した文字列をデシリアライズする
                ncParameter = JsonConvert.DeserializeObject<T>(str_jsonfile_sentence_commentout);
            }
            catch
            {
                // json構文エラー
                return -2;
            }
            return 0;
        }

        /// <summary>
        /// インスタンスをシリアライズし、Json形式ファイル書き出す
        /// </summary>
        /// <param name="nstrFilePath">書き出すファイルのパス</param>
        /// <param name="ncParameter">書き出すパラメータを保有するインスタンス</param>
        /// <returns>0:正常終了、-1:ファイル作成・書き込みエラー</returns>
        public static int Save<T>(string nstrFilePath, T ncParameter)
        {
            Encoding encd_encoding = Encoding.GetEncoding("utf-8");
            // パラメータをシリアライズする
            string str_json_contents = JsonConvert.SerializeObject(ncParameter, Formatting.Indented);
            //// パラメータ文字列にコメントを追加する(現在、未実装)
            //AddDescriptionOfParameter(ref str_json_contents);

            try
            {
                // jsonファイルを作成する
                using (FileStream fs = File.Create(nstrFilePath)) { }
                // jsonファイルにパラメータ文字列を書き込む
                using (StreamWriter writer = new StreamWriter(nstrFilePath, false, encd_encoding))
                {
                    writer.WriteLine(str_json_contents);
                }
                return 0;
            }
            catch
            {
                // ファイル作成・書き込みエラー
                return -1;
            }
        }

        /// <summary>
        /// "###"ー"改行コード(\r\n)"間の文字を排除する
        /// </summary>
        /// <param name="n_strJsonfileContents">Jsonファイルから読み込んだstring型データ</param>
        /// <returns>コメント削除結果</returns>
        private static string RemoveComment(string nstrJsonfileContents)
        {
            string str_result = "";                     // 返答用のstring型データ
            string str_contents = nstrJsonfileContents; // 主となるstring型データ
            string str_front = "";                      // コメントコードより前の文章を格納するstring型データ
            string str_back = "";                       // コメントコードより後の文章を格納するstring型データ
            int i_num_comment_code;                     // コメントコードの位置を示すint型データ
            int i_num_newline_code;                     // 改行コードの位置を示すint型データ

            while (true)
            {
                // コメントコードの位置を探す
                i_num_comment_code = str_contents.IndexOf(m_strCommentCode);
                // コメントコードがこれ以上なければ終了
                if (i_num_comment_code == -1)
                {
                    break;
                }
                // コメントコードよりも前の文章を抽出
                str_front = str_contents.Substring(0, i_num_comment_code - 1);
                // コメントコードよりも後の文章を抽出
                str_back = str_contents.Substring(i_num_comment_code, str_contents.Length - i_num_comment_code);
                // コメントコード直後の改行コードを探す
                i_num_newline_code = str_back.IndexOf(m_strNewLineCode);
                // コメントコード直後の改行コードより後ろの文を抽出
                str_contents = str_back.Substring(i_num_newline_code, str_back.Length - i_num_newline_code);
                // コメントコードよりも前の文を返答用データに追加
                str_result += str_front;
            }
            // コメントコードを含まない後半データを返答用データに追加
            str_result += str_contents;
            // 返答する
            return str_result;
        }

    }
}

