using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Encryption
{
    public class AES
    {
        const string _key = "1f7bd55616ed4e63bd25be234adbabc5";
        static readonly Encoding _encoding = Encoding.UTF8;
        public static string Encrypt(string plainText)
        {
            try
            {
                byte[] encrypted;
                byte[] IV;

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = _encoding.GetBytes(_key);

                    aesAlg.GenerateIV();
                    IV = aesAlg.IV;

                    aesAlg.Mode = CipherMode.CBC;

                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption. 
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                var combinedIvCt = new byte[IV.Length + encrypted.Length];
                Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
                Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

                return Convert.ToBase64String(combinedIvCt);
            }
            catch (Exception e)
            {
                throw new Exception("Error encrypting: " + e.Message);
            }
        }

        public static string Decrypt(string codes)
        {
            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;
            var codeCombine = Convert.FromBase64String(codes);

            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _encoding.GetBytes(_key);

                byte[] iv = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[codeCombine.Length - iv.Length];

                Array.Copy(codeCombine, iv, iv.Length);
                Array.Copy(codeCombine, iv.Length, cipherText, 0, cipherText.Length);

                aesAlg.IV = iv;

                aesAlg.Mode = CipherMode.CBC;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }
}
