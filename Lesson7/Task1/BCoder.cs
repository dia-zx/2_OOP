using System.Text;

/// <summary>
/// Класс шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на букву того же регистра,
/// расположенную в алфавите на i-й позиции с конца алфавита.
/// </summary>
public class BCoder : ICoder
{
    public string Encode(IEnumerable<char> input)
    {
        if (input is null) throw new ArgumentNullException(nameof(input));
        StringBuilder stringBuilder = new();
        foreach (var item in input)
        {
            if (item >= 'A' && item <= 'Z')
                stringBuilder.Append((char)('A' + 'Z' - item));
            else
            if (item >= 'a' && item <= 'z')
                stringBuilder.Append((char)('a' + 'z' - item));
            else
            if (item >= 'А' && item <= 'Я')
                stringBuilder.Append((char)('А' + 'Я' - item));
            else
            if (item >= 'а' && item <= 'я')
                stringBuilder.Append((char)('а' + 'я' - item));
            else
                stringBuilder.Append(item);
        }
        return stringBuilder.ToString();
    }

    public string Decode(IEnumerable<char> input) => Encode(input);
}