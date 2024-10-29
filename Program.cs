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
