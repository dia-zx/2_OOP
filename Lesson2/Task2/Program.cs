/*
    2. Изменить класс счет в банке из упражнения таким образом,
чтобы номер счета генерировался сам и был уникальным.
Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
*/
BankAccount account = new BankAccount();
account.SetBalance(100.56m);
account.SetType(BankAccount.BankAccountType.Savings);
account.SetNumber();

Console.WriteLine("Выводим информацию о счете:\n");
Console.WriteLine(account);

BankAccount account2 = new BankAccount();
account2.SetBalance(265.95m);
account2.SetType(BankAccount.BankAccountType.Insured);
account2.SetNumber();

Console.WriteLine("Выводим информацию о счете:\n");
Console.WriteLine(account2);
Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();