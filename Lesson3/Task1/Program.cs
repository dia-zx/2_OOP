/*
    1. В класс банковский счет, созданный в упражнениях,
добавить метод, который переводит деньги с одного счета на другой.
У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги,
второй параметр – сумма.
*/
decimal MoneyTransfer;
BankAccount account1 = new BankAccount(654.12m);
Console.WriteLine("Выводим информацию о счете1:");
Console.WriteLine(account1);

BankAccount account2 = new BankAccount(1500.55m);
Console.WriteLine("Выводим информацию о счете2:");
Console.WriteLine(account2);

MoneyTransfer = 50m;
Console.WriteLine($"\n\nПереводим со счета1 на счет2 {MoneyTransfer}.");
Console.WriteLine("Результат оерации: {0}", account2.Transfer(account1, 50m));


Console.WriteLine("Выводим информацию о счете1:");
Console.WriteLine(account1);

Console.WriteLine("Выводим информацию о счете2:");
Console.WriteLine(account2);

MoneyTransfer = 1000m;
Console.WriteLine($"\n\nПереводим со счета1 на счет2 {MoneyTransfer}.");
Console.WriteLine("Результат оерации: {0}", account2.Transfer(account1, MoneyTransfer));


Console.WriteLine("Выводим информацию о счете1:");
Console.WriteLine(account1);

Console.WriteLine("Выводим информацию о счете2:");
Console.WriteLine(account2);

Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();