using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager
{
    class Program
    {
        static Dictionary<string, string> passwordStore = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            // Вызов метода меню
        }

        static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (var aes = Aes.Create())
            {
                aes.Key = new byte[32]; // Секретный ключ (для примера)
                aes.IV = new byte[16]; // Вектор инициализации (для примера)
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new System.IO.MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
