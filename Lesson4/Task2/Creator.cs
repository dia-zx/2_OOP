/*
 * 2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания.
 * Для этого изменить модификатор доступа к конструкторам класса,
 * в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания.
 * В классе Creator все методы сделать статическими, конструктор класса сделать закрытым.
 * Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
 * Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.
 * Создать тестовый пример, работающий с созданными классами.
*/
using System.Collections;

public class Creator : IEnumerable<House>
{
    static Creator() { }
    /// <summary>
    /// Хеш-таблица для хранения объектов
    /// </summary>
    private static System.Collections.Hashtable houses = new();
    /// <summary>
    /// Создает объект дома
    /// </summary>
    /// <returns>ссылка на созданный объект</returns>
    public static House CreateBuild()
    {
        return CreateBuild(0, 0, 0, 0);
    }
    /// <summary>
    /// Создает объект дома
    /// </summary>
    /// <param name="height">Высота, м</param>
    /// <param name="floorsCount">Число этажей</param>
    /// <param name="flatsCount">Число квартир</param>
    /// <param name="entrancesCount">Число подъездов</param>
    /// <returns>ссылка на созданный объект</returns>
    public static House CreateBuild(double height, int floorsCount, int flatsCount, int entrancesCount)
    {
        House house = new House(height, floorsCount, flatsCount, entrancesCount);
        houses.Add(house.ID, house);
        return house;
    }
    /// <summary>
    /// Возвращает число домов в хеш-таблице
    /// </summary>
    /// <returns></returns>
    public static int GetCount() => houses.Count;
    /// <summary>
    /// Очистка хеш-таблицы с домами
    /// </summary>
    public static void Clear() => houses.Clear();
    /// <summary>
    /// Удаление дома по его ID
    /// </summary>
    /// <param name="ID">уникальный номер дома</param>
    public static void Remove(int ID)
    {
        if (!houses.ContainsKey(ID))
            throw new ArgumentException("Указанное ID отсутствует.");
        houses.Remove(ID);
    }
    /// <summary>
    /// Возвращает здание по ID
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public static House GetHouse(int ID)
    {
        if (!houses.ContainsKey(ID))
            throw new ArgumentException("Указанное ID отсутствует.");
        return (House)houses[ID]!;
    }
    /// <summary>
    /// Добавим Enumerator...)
    /// </summary>
    /// <returns></returns>
    public IEnumerator<House> GetEnumerator()
    {
        foreach (var house in houses.Values)
        {
            yield return (House)house;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

