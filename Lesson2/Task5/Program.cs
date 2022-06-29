/*
    5. * Добавить в класс счет в банке два метода:
снять со счета и положить на счет.
Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму,
и в случае положительного результата изменяет баланс.
*/
BankAccount account = new BankAccount(654.12m);
Console.WriteLine("Выводим информацию о счете:");
Console.WriteLine(account);

account.PutMoney(100m);
Console.WriteLine("\nПоложили 100:");
Console.WriteLine(account);

account.GetMoney(10m);
Console.WriteLine("\nСняли 10:");
Console.WriteLine(account);

Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();