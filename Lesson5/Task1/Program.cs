/*
 * 1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель.
 * Предусмотреть конструктор.
 * Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --.
 * Переопределить метод ToString() для вывода дроби.
 * Определить операторы преобразования типов между типом дробь,float, int.
 * Определить операторы *, /, %.
 */


var n1 = new RationalNumber(4, 7);
var n2 = new RationalNumber(5, 3);


Console.WriteLine($"n1: {n1},\tn2:{n2}");
Console.WriteLine($"n1= {n1.ToDouble()},\tn2={n2.ToDouble()}");
Console.WriteLine($"n1 + n2: {n1 + n2}");
Console.WriteLine($"n1 - n2: {n1 - n2}");
Console.WriteLine($"n1 * n2: {n1 * n2}");
Console.WriteLine($"n1 / n2: {n1 / n2}");
Console.WriteLine($"n1 % n2: {n1 % n2}");

Console.WriteLine($"\nn1 == n2: {n1 == n2}");
Console.WriteLine($"n1 > n2: {n1 > n2}");
Console.WriteLine($"n1 < n2: {n1 < n2}");
Console.WriteLine($"n1 >= n2: {n1 >= n2}");
Console.WriteLine($"n1 <= n2: {n1 <= n2}");


n1 = 5;
Console.WriteLine($"n1: {n1},\tn2:{n2}");

Console.WriteLine("\nНажмите любую клавишу для выхода.");
Console.ReadKey();

