/*
 * 1. Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
 * Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode().
 * Переопределить методToString() для печати информации о счете.
 * Протестировать функционирование переопределенных методов и операторов на простом примере.
 */


BankAccount account1 = new BankAccount(654.12m);
Console.WriteLine("Выводим информацию о счете1:");
Console.WriteLine(account1);

BankAccount account2 = new BankAccount(1500.55m);
Console.WriteLine("Выводим информацию о счете2:");
Console.WriteLine(account2);

BankAccount account3 = new BankAccount(1500.55m);
Console.WriteLine("Выводим информацию о счете3:");
Console.WriteLine(account3);

Console.WriteLine();
Console.WriteLine($"сравниваем счет1 со счетом2 (==): {account1 == account2}");
Console.WriteLine($"сравниваем счет2 со счетом3 (==): {account2 == account3}");
Console.WriteLine($"сравниваем счет1 со счетом2 (==): {account1 == account2}");
Console.WriteLine($"сравниваем счет1 со счетом2 (!=): {account1 != account2}");

Console.WriteLine();
Console.WriteLine($"счет1 HashCode: {account1.GetHashCode()}");
Console.WriteLine($"счет2 HashCode: {account2.GetHashCode()}");
Console.WriteLine($"счет3 HashCode: {account3.GetHashCode()}");

Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();
