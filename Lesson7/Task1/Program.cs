﻿/*
 * 1. Определить интерфейс IСoder, который полагает методы поддержки шифрования строк.
 * В интерфейсе объявляются два метода Encode() и Decode(), используемые для шифрования и дешифрования строк.
 * Создать класс ACoder, реализующий интерфейс ICoder.
 * Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
 * (В результате такого сдвига буква А становится буквой Б). Создать класс BCoder, реализующий интерфейс ICoder.
 * Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
 * расположенную в алфавите на i-й позиции с конца алфавита. (Например, буква В заменяется на букву Э.
 * Написать программу, демонстрирующую функционирование классов).
 */


Console.WriteLine("Hello, World!");
interface ICoder {
    string Encode(IEnumerable<char> input);
    string Decode(IEnumerable<char> input);
}

public class ACoder : ICoder {
    public string Encode(IEnumerable<char> input)
    {
        StringBuilder stringBuilder = new();
        foreach (var item in input)
        {

        }
    }

    public string Decode(IEnumerable<char> input)
    {
        throw new NotImplementedException();
    }

    string
}