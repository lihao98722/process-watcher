using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ProcessWatcher
{
    class Decrypt
    {
        private static byte[] Key = Encoding.UTF8.GetBytes("ProcessW");
        private static byte[] Iv = Encoding.UTF8.GetBytes("ProcessW");

        private static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            string plaintext = "";

            using (DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider())
            {
                desProvider.Key = Key;
                desProvider.IV = IV;

                ICryptoTransform decryptor = desProvider.CreateDecryptor(desProvider.Key, desProvider.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public static string DoDecrypt(byte[] b)
        {
            return DecryptStringFromBytes_Aes(b, Key, Iv);
        }
    }
}
