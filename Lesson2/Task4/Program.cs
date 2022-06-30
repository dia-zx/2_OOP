/*
    4. В классе все методы для заполнения и получения
значений полей заменить на свойства. Написать тестовый пример.
*/
BankAccount account = new BankAccount();
Console.WriteLine("Выводим информацию о счете (конструктор по умолчанию) до изменения свойств:");
Console.WriteLine(account);

account.Balance = 654.12m;
account.Type = BankAccount.BankAccountType.Current;

Console.WriteLine("\nВыводим информацию о счете после изменения свойств:");
Console.WriteLine(account);

Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();