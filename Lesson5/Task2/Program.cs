/*
 * 2. * На перегрузку операторов. Описать класс комплексных чисел.
 * Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел.
 * Переопределить метод ToString() для комплексного числа. Протестировать на простом примере.
 */

Complex z1 = new(5, 1);
Complex z2 = new(3, 2);

Console.WriteLine($"z1: {z1}\tz2: {z2}");
Console.WriteLine($"z1 + z2: {z1 + z2}");
Console.WriteLine($"z1 * z2: {z1 * z2}");
Console.WriteLine($"z1 - z2: {z1 - z2}");
Console.WriteLine($"-z1: {-z1}");

Console.WriteLine($"\nz1 != z2: {z1 != z2}");
Console.WriteLine($"\nz1 == (Complex)z1.Clone(): {z1 == (Complex)(z1.Clone())}");
Console.WriteLine("\nНажмите любую клавишу для выхода.");
Console.ReadKey();
