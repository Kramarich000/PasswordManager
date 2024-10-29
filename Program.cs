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
