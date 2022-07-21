/*
 * 2. * Создать класс Figure для работы с геометрическими фигурами.
 * В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
 * Реализовать операции: передвижение геометрической фигуры по горизонтали,
 * по вертикали, изменение цвета, опрос состояния (видимый/невидимый).
 * Метод вывода на экран должен выводить состояние всех полей объекта.
 * Создать класс Point (точка) как потомок геометрической фигуры. 
 * Создать класс Circle (окружность) как потомок точки.
 * В класс Circle добавить метод, который вычисляет площадь окружности.
 * Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника.
 * Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
 * Подумать, какие методы можно объявить в интерфейсе, нужно ли объявлять абстрактный класс,
 * какие методы и поля будут в абстрактном классе, какие методы будут виртуальными, какие перегруженными.
 */


public abstract class Figure
{
    /// <summary>
    /// цвет
    /// </summary>
    protected uint _colour = 0;
    /// <summary>
    /// сестояние (видимый/невидимый) true - видимый
    /// </summary>
    protected bool _visible = true;
    /// <summary>
    /// сестояние (видимый/невидимый) true - видимый
    /// </summary>
    public bool Visible
    {
        get => _visible;
        set
        {
            if (value != _visible) { _visible = value; DoVisibleChange(); }
        }
    }
    /// <summary>
    /// цвет
    /// </summary>
    public uint Colour
    {
        get => _colour;
        set
        {
            if (value != _colour) { _colour = value; DoColourChange(); }
        }
    }

    /// <summary>
    /// перемещение по горизонтали
    /// </summary>
    /// <param name="value">величина перемещения</param>
    public abstract void MoveX(int value);
    /// <summary>
    /// перемещение по вертикали
    /// </summary>
    /// <param name="value">величина перемещения</param>
    public abstract void MoveY(int value);
    /// <summary>
    /// вывод состояния полей объекта
    /// </summary>
    public abstract void Draw();
    /// <summary>
    /// площадь фигуры
    /// </summary>
    /// <returns></returns>
    public abstract double Area();
    public override string ToString() => $"Colour: {_colour}\tVisible: {_visible}";

    /// <summary>
    /// метод для вызова события OnVisibleChanged - изменение свойства видимости
    /// </summary>
    public void DoVisibleChange() => OnVisibleChanged?.Invoke(this, EventArgs.Empty);
    /// <summary>
    /// метод для вызова события OnColourChanged - изменение цвета
    /// </summary>
    public void DoColourChange() => OnColourChanged?.Invoke(this, EventArgs.Empty);

    /// <summary>
    /// событие "изменение видимости объекта"
    /// </summary>
    public event EventHandler OnVisibleChanged;
    /// <summary>
    /// событие "изменение цвета объекта"
    /// </summary>
    public event EventHandler OnColourChanged;
}
