using System;
using System.Security.Cryptography;
using System.Text;

namespace Business_Layer.Utils
{
    public class BEncrypt
    {
        private AesCryptoServiceProvider aesCSProvider;

        private const string AESIV256 = @"!QAZ2WSX#EDC4RFV"; //16
        private const string AESKEY256 = @"5TGB&YHN7UJM(IK<5TGB&YHN7UJM(IK<"; //31

        public string TextToEncrypt { get; set; }
        public string TextEncrypted { get; set; }

        public BEncrypt()
        {
            aesCSProvider = new AesCryptoServiceProvider();
            aesCSProvider.KeySize = 256;
            aesCSProvider.IV = Encoding.UTF8.GetBytes(AESIV256);
            aesCSProvider.Key = Encoding.UTF8.GetBytes(AESKEY256);
            aesCSProvider.Mode = CipherMode.CBC;
            aesCSProvider.Padding = PaddingMode.PKCS7;
        }

        public void Encrypt256()
        {
            byte[] src = Encoding.Unicode.GetBytes(TextToEncrypt);
            using (ICryptoTransform encrypt = aesCSProvider.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                TextEncrypted = Convert.ToBase64String(dest);
            }
        }
    }
}