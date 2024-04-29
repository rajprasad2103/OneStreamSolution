using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Unicode;

namespace OneStreamEncryption
{
   
    public class AESEncryption
    {     
        private static string? SecretKey = ConfigurationProvider.Configuration["AppSettings:Key"];
        private static string? VectorKey = ConfigurationProvider.Configuration["AppSettings:IvKey"];

        static byte[] SecretKeyArray, VectorKeyArray;

        public static byte[] ConvertStringToAESKey(string customString, int length)
        {
            // Create an instance of SHA-256 hash algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the custom string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(customString));

                // Return the first 32 bytes (256 bits) of the hash as the AES key
                byte[] aesKey = new byte[length];
                Array.Copy(hashBytes, aesKey, length);

                return aesKey;
            }
        }


        public static string Encrypt(string plainText)
        {           

            SecretKeyArray = ConvertStringToAESKey(SecretKey,32);
            VectorKeyArray = ConvertStringToAESKey(VectorKey,16);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = SecretKeyArray;
                aesAlg.IV = VectorKeyArray;
                aesAlg.Padding = PaddingMode.PKCS7;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            try
            {
                SecretKeyArray = ConvertStringToAESKey(SecretKey, 32);
                VectorKeyArray = ConvertStringToAESKey(VectorKey, 16);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);                

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = SecretKeyArray;
                    aesAlg.IV = VectorKeyArray;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream and place them in a string.
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return string.Empty;
            }            

        }
    }


}
