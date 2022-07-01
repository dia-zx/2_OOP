/*
 *  2. Реализовать метод, который в качестве входного параметра принимает строку string,
 * возвращает строку типа string, буквы в которой идут в обратном порядке.
 * Протестировать метод.
 */
string TestString = "This is test string";

Console.WriteLine($"Тестируем строку \"{TestString}\"\n\n");
Console.WriteLine($"Метод ReverseString1: {ReverseString1(TestString)}");
Console.WriteLine($"Метод ReverseString2: {ReverseString2(TestString)}");

#region Замерим производительность методов
const int COUNT = 1000_000;
System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
stopwatch.Start();
for (int i = 0; i < COUNT; i++)
    ReverseString1(TestString);
stopwatch.Stop();
Console.WriteLine($"Вариант (ReverseString1) длительность, мс: {stopwatch.ElapsedMilliseconds}");

stopwatch.Reset();
stopwatch.Start();
for (int i = 0; i < COUNT; i++)
    ReverseString2(TestString);
stopwatch.Stop();
Console.WriteLine($"Вариант (ReverseString2) длительность, мс: {stopwatch.ElapsedMilliseconds}");
#endregion
Console.WriteLine("\n\nНажмите любую клавишу для выхода");
Console.ReadKey();

/// <summary>
/// Вариант 1 реверс строки через преобразование в массив символов
/// </summary>
/// <param name="str"></param>
/// <returns></returns>
static string? ReverseString1(string? str)
{
    if (str == null) return null;
    char[] mas = str.ToCharArray();
    for (int i = 0; i < mas.Length / 2; i++)
    {
        char c = mas[i];
        mas[i] = mas[mas.Length - 1 - i];
        mas[mas.Length - 1 - i] = c;
    }
    return new string(mas);
}

/// <summary>
/// Реверс строки в небезопасном режиме через указатели
/// </summary>
/// <param name="str"></param>
/// <returns></returns>
static unsafe string? ReverseString2(string? str)
{
    if (str == null) return null;
    string result = new string(str);    //подготовим строку под результат (выделим память...)
    fixed (char* p0_source = str, p0_result = result) //Зафиксируем str, result чтобы получить к ним доступ через указатели...
    {
        char* p_result = p0_result + str.Length - 1;//подготовим новый указатель на конец строки result
        char* p_source = p0_source;                 //подготовим новый указатель на начало строки str
        for (int i = 0; i < str.Length; i++)
            *(p_result--) = *(p_source++);
    }
    return result;
}