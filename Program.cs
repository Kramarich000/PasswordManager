static void DisplayPasswords()
{
    Console.WriteLine("Список сохраненных паролей:");
    foreach (var entry in passwordStore)
    {
        Console.WriteLine($"Имя: {entry.Key}, Пароль: {entry.Value}");
    }
}
