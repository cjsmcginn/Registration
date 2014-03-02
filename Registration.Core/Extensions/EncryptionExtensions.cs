using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Registration.Core.Extensions
{
 /// <summary>
 /// Provides common static helpers for encrypting and decrypting strings
 /// </summary>
    public static class EncryptionExtensions
    {
        static readonly RegistrationConfiguration RegistrationConfiguration = System.Configuration.ConfigurationManager.GetSection("registrationConfiguration") as RegistrationConfiguration;
        public static string EncryptText(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            var encryptionPrivateKey = RegistrationConfiguration.EncryptionKey;
            var tDeSalg = new TripleDESCryptoServiceProvider();
            tDeSalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDeSalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));
            byte[] encryptedBinary = EncryptTextToMemory(plainText, tDeSalg.Key, tDeSalg.IV);
            return Convert.ToBase64String(encryptedBinary);
        }
        public static string DecryptText(this string cipherText)
        {
            if (String.IsNullOrEmpty(cipherText))
                return cipherText;

            var encryptionPrivateKey = RegistrationConfiguration.EncryptionKey;

            var tDeSalg = new TripleDESCryptoServiceProvider();
            tDeSalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
            tDeSalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

            byte[] buffer = Convert.FromBase64String(cipherText);
            return DecryptTextFromMemory(buffer, tDeSalg.Key, tDeSalg.IV);
        }
        private static byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    var toEncrypt = new UnicodeEncoding().GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }
        private static string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    var sr = new StreamReader(cs, new UnicodeEncoding());
                    return sr.ReadLine();
                }
            }
        }
    }
}
