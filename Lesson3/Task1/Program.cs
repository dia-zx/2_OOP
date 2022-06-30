/*
    1. В класс банковский счет, созданный в упражнениях,
добавить метод, который переводит деньги с одного счета на другой.
У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги,
второй параметр – сумма.
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