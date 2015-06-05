using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProcessWatcher
{
    class FileOperation
    {
        public static string filePath = Program.pwFilePath;

        public static string ReadFromFile()
        {
            FileStream fs = new FileStream(filePath,FileMode.Open,FileAccess.Read);
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, bt.Length);
            fs.Close();

            string content = "";
            try
            {
                content = Decrypt.DoDecrypt(bt);
            }
            catch (Exception e)
            {
                return "";
            }
            return content;
        }

        public static bool SaveToFile(String content)
        {
            if (!File.Exists(filePath))
                return false;

            try
            {
                byte[] bt=Encrypt.DoEnc(content);
                FileStream fs = new FileStream(filePath,FileMode.Open,FileAccess.Write);
                fs.Write(bt, 0, bt.Length);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
