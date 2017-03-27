using System;
using System.Security.Cryptography;
using System.Text;

namespace Business_Layer.Utils
{
    public class BDecrypt
    {
        private AesCryptoServiceProvider aesCSProvider;

        private const string AESIV256 = @"!QAZ2WSX#EDC4RFV"; //16
        private const string AESKEY256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<"; //31

        public string TextToDecrypt { get; set; }
        public string TextDecrypted { get; set; }

        public BDecrypt()
        {
            aesCSProvider = new AesCryptoServiceProvider();
            aesCSProvider.KeySize = 256;
            aesCSProvider.IV = Encoding.UTF8.GetBytes(AESIV256);
            aesCSProvider.Key = Encoding.UTF8.GetBytes(AESKEY256);
            aesCSProvider.Mode = CipherMode.CBC;
            aesCSProvider.Padding = PaddingMode.PKCS7;
        }

        public void Decrypt256()
        {
            byte[] src = Convert.FromBase64String(TextToDecrypt);
            using (ICryptoTransform decrypt = aesCSProvider.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                TextDecrypted = Encoding.Unicode.GetString(dest);
            }
        }
    }
}