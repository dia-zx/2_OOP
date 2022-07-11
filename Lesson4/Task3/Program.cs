/*
 * 3. * Разбить созданные классы (здания, фабричный класс) и тестовый пример в разные исходные файлы.
 * Разместить классы в одном пространстве имен. Создать сборку (DLL), включающие эти классы.
 * Подключить сборку к проекту и откомпилировать тестовый пример со сборкой.
 * Получить исполняемый файл, проверить с помощью утилиты ILDASM,
 * что тестовый пример ссылается на сборку и не содержит в себе классов здания и Creator.
 */


using Task3_Library;

House h;
h = Creator.CreateBuild();
Console.WriteLine($"Создан дом: {h}");

h = Creator.CreateBuild(10, 5, 80, 4);
Console.WriteLine($"Создан дом: {h}");

h = Creator.CreateBuild(20, 10, 160, 4);
Console.WriteLine($"Создан дом: {h}");

Console.WriteLine($"\nЧисло домов: {Creator.GetCount()}");

Console.WriteLine("\nСписок домов через Enumerate:");
var houses = new Creator();// создадим объект Creator для работы с коллекцией..
foreach (House house in houses)
    Console.WriteLine(house);

Console.WriteLine("Удалим дом с ID == 1");
Creator.Remove(1);
foreach (House house in houses)
    Console.WriteLine(house);

Console.WriteLine("Нажмите любую клавишу для выхода.");
Console.ReadKey();

