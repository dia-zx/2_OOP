/*
 * 1. Определить интерфейс IСoder, который полагает методы поддержки шифрования строк.
 * В интерфейсе объявляются два метода Encode() и Decode(), используемые для шифрования и дешифрования строк.
 * Создать класс ACoder, реализующий интерфейс ICoder.
 * Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
 * (В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder.
 * Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
 * расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э.
 * Написать программу, демонстрирующую функционирование классов).
 */
ACoder coder = new ACoder();

string OriginalString = "АБаб Hello, World! ABCD  ZXC abcd  zxc АБВ ЭЮЯ  абв эюя";

Console.WriteLine("*********** ACoder *************");
Console.WriteLine("Исходная строка: " + OriginalString);
string EncodeString = coder.Encode(OriginalString);
Console.WriteLine("Закодированная строка: " + EncodeString);
string DecodeString = coder.Decode(EncodeString);
Console.WriteLine("Раскодированная строка: " + DecodeString);

BCoder bCoder = new BCoder();
Console.WriteLine("\n*********** BCoder *************");
Console.WriteLine("Исходная строка: " + OriginalString);
EncodeString = bCoder.Encode(OriginalString);
Console.WriteLine("Закодированная строка: " + EncodeString);
DecodeString = bCoder.Decode(EncodeString);
Console.WriteLine("Раскодированная строка: " + DecodeString);

Console.WriteLine("\nНажмите любую клавишу для выхода.");
Console.ReadKey();
