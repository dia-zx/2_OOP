/*
    3. В классе банковский счет удалить методы заполнения полей.
Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию,
создать конструктор для заполнения поля баланс,
конструктор для заполнения поля тип банковского счета,
конструктор для заполнения баланса и типа банковского счета.
Каждый конструктор должен вызывать метод, генерирующий номер счета.
*/
BankAccount account1 = new BankAccount();
Console.WriteLine("1 Выводим информацию о счете (конструктор по умолчанию):");
Console.WriteLine(account1);

BankAccount account2 = new BankAccount(BankAccount.BankAccountType.Budget);
Console.WriteLine("\n2 Выводим информацию о счете (конструктор типа банковского счета):");
Console.WriteLine(account2);

BankAccount account3 = new BankAccount(777.77m);
Console.WriteLine("\n3 Выводим информацию о счете (конструктор для заполнения поля баланс):");
Console.WriteLine(account3);

BankAccount account4 = new BankAccount(111.22m, BankAccount.BankAccountType.Foreign_currency);
Console.WriteLine("\n4 Выводим информацию о счете (конструктор для заполнения поля баланс и типа банковского счета):");
Console.WriteLine(account4);

Console.WriteLine("\n\nНажмите любую клавишу для выхода.");
Console.ReadKey();