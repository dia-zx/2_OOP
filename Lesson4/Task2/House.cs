/*
 * 2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания.
 * Для этого изменить модификатор доступа к конструкторам класса,
 * в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания.
 * В классе Creator все методы сделать статическими, конструктор класса сделать закрытым.
 * Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
 * Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.
 * Создать тестовый пример, работающий с созданными классами.
*/
public class House
{
    /// <summary>
    /// Уникальный номер для генерации _ID
    /// </summary>
    private static int _UID = 0;
    /// <summary>
    /// Уникальный номер здания
    /// </summary>
    private int _ID;
    /// <summary>
    /// высота здания, м
    /// </summary>
    private double _Height = 0;
    /// <summary>
    /// Количество этажей
    /// </summary>
    private int _FloorsCount = 0;
    /// <summary>
    /// Количество квартир
    /// </summary>
    private int _FlatsCount = 0;
    /// <summary>
    /// Количество подъездов
    /// </summary>
    private int _EntrancesCount = 0;

    internal House()
    {// TO DO для запрета доступа к конструктору вне Creator необходимо выполнить реализацию в отдельной сборке (Task3)..
        _ID = _UID++;
    }
    internal House(double height, int floorsCount, int flatsCount, int entrancesCount) : this()
    {// TO DO для запрета доступа к конструктору вне Creator необходимо выполнить реализацию в отдельной сборке (Task3)..
        _Height = height;
        _FloorsCount = floorsCount;
        _FlatsCount = flatsCount;
        _EntrancesCount = entrancesCount;
    }

    /// <summary>
    /// Уникальный номер здания
    /// </summary>
    public int ID { get => _ID; }
    /// <summary>
    /// высота здания, м
    /// </summary>
    public double Height
    {
        get => _Height; set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Height");
            _Height = value;
        }
    }
    /// <summary>
    /// Количество этажей
    /// </summary>
    public int FloorsCount
    {
        get => _FloorsCount; set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("FloorCount");
            _FloorsCount = value;
        }
    }
    /// <summary>
    /// Количество квартир
    /// </summary>
    public int FlatsCount
    {
        get => _FlatsCount; set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("FlatCount");
            _FlatsCount = value;
        }
    }
    /// <summary>
    /// Количество подъездов
    /// </summary>
    public int EntrancesCount
    {
        get => _EntrancesCount; set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("EntranceCount");
            _EntrancesCount = value;
        }
    }

    /// <summary>
    /// Вычисляет высоту этажа, м
    /// </summary>
    /// <returns>высота этажа, м</returns>
    public double CalcFloorHeight() => _Height / _FloorsCount;
    /// <summary>
    /// Вычисляет число квартир в подъезде
    /// </summary>
    /// <returns>число квартир в подъезде</returns>
    public int CalcFlatsInEntrance() => _FlatsCount / _EntrancesCount;
    /// <summary>
    /// Вычисляет число квартир на этаже
    /// </summary>
    /// <returns>число квартир на этаже</returns>
    public int CalcFlatsInFloor() => _FlatsCount / _FloorsCount;

    public override string ToString()
    {
        return $"ID здания: {_ID}, высота: {_Height}м, число этажей: {_FloorsCount}, число квартир: {_FlatsCount}, число подъездов: {_FloorsCount}";
    }
}

