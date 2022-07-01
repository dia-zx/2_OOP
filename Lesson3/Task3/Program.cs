/*
 * 3. * Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес.
 * Разделителем между ФИО и адресом электронной почты является символ &:
 * Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru
 * Сформировать новый файл, содержащий список адресов электронной почты.
 * Предусмотреть метод, выделяющий из строки адрес почты.
 * Методу в качестве параметра передается символьная строка s,
 * e-mail возвращается в той же строке s: public void SearchMail (ref string s).
 */

using System.Text;


Parse.Process("NamesEmails.txt", "Emails.txt");



Console.WriteLine("\n\nНажмите любую клавишу для выхода");
Console.ReadKey();

class Parse
{
    /// <summary>
    /// Ищет Email в строке текста [s]
    /// </summary>
    /// <param name="s">строка текста и результата</param>
    public static void SearchMail(ref string s)
    {
        var p = s.AsSpan();
        int index = p.IndexOf('@');
        if (index == -1)
        {//в строке нет '@'
            s = string.Empty;
            return;
        }

        #region Ищем конец Email справа от '@'
        for (int i = index; i < p.Length; i++)
        {
            if ((p[i] == ' ') || (p[i] == '\r') || (p[i] == '\t'))
            {
                p = p[..(i-1)];
                break;
            }
        }
        #endregion

        #region Ищем конец Email слева от '@'
        for (int i = index; i >= 0; i--)
        {
            if ((p[i] == ' ') || (p[i] == '\r') || (p[i] == '\t'))
            {
                p = p[(i + 1)..];
                break;
            }
        }
        #endregion
        s = p.ToString();
    }

    /// <summary>
    /// читает файл PathSource, выделяет Emailы и записывает их в файл PathDest
    /// </summary>
    /// <param name="PathSource">путь к файлу источнику </param>
    /// <param name="PathDest">путь к файлу для записи Email</param>
    public static void Process(string PathSource, string PathDest)
    {
        StringBuilder stringBuider = new();
        using System.IO.StreamReader sr = new(PathSource);
        using System.IO.StreamWriter sw = new(PathDest);

        int r;
        char c;
        do
        {
            r = sr.Read(); // читаем файл небольшими блоками :)
            c = (r == -1) ? '&' : (char)r;
            if ((c == '&') || (c == '\r') || (c == '\t') || (c == ' '))
            {
                string str = stringBuider.ToString();
                SearchMail(ref str);
                if (str != string.Empty)
                    sw.WriteLine(str);
                stringBuider.Clear();
                continue;
            }
            stringBuider.Append(c);
        } while (r != -1);
    }
}


