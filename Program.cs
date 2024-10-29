using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager
{
    class Program
    {
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить пароль");
                Console.WriteLine("2. Удалить пароль");
                Console.WriteLine("3. Показать пароли");
                Console.WriteLine("4. Выйти");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя для хранения пароля: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();
                        AddPassword(name, password);
                        break;
                    case "2":
                        Console.Write("Введите имя для удаления пароля: ");
                        string nameToRemove = Console.ReadLine();
                        RemovePassword(nameToRemove);
                        break;
                    case "3":
                        DisplayPasswords();
                        break;
                    case "4":
                        return; // Выход из программы
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                        break;
                }
            }
        }
        static Dictionary<string, string> passwordStore = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            ShowMenu();
        }

        static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (var aes = Aes.Create())
            {
                aes.Key = new byte[32];
                aes.IV = new byte[16];
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

        static void AddPassword(string name, string password)
        {
            string encryptedPassword = Encrypt(password);
            passwordStore[name] = encryptedPassword;
            Console.WriteLine($"Пароль для {name} добавлен.");
        }

        static void RemovePassword(string name)
        {
            if (passwordStore.Remove(name))
            {
                Console.WriteLine($"Пароль для {name} удален.");
            }
            else
            {
                Console.WriteLine($"Пароль для {name} не найден.");

            }
        }
        static void DisplayPasswords()
        {
            Console.WriteLine("Список сохраненных паролей:");
            foreach (var entry in passwordStore)
            {
                Console.WriteLine($"Имя: {entry.Key}, Пароль: {entry.Value}");
            }
        }
    }


}