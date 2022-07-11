/*
 * 2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания.
 * Для этого изменить модификатор доступа к конструкторам класса,
 * в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания.
 * В классе Creator все методы сделать статическими, конструктор класса сделать закрытым.
 * Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
 * Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.
 * Создать тестовый пример, работающий с созданными классами.
*/

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
