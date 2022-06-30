/*
 *      1.Создать класс счет в банке с закрытыми полями: номер счета, баланс,
 * тип банковского счета (использовать перечислимый тип).
 * Предусмотреть методы для доступа к данным – заполнения и чтения.
 * Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
*/
BankAccount account = new BankAccount();
account.SetBalance(100.56m);
account.SetType(BankAccount.BankAccountType.Savings);
account.SetNumber(1008995005);

Console.WriteLine("Выводим информацию о счете:\n");
Console.WriteLine(account);
Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();
