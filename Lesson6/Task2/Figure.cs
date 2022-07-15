/*
 * 2. * Создать класс Figure для работы с геометрическими фигурами.
 * В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
 * Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали,
 * изменение цвета, опрос состояния (видимый/невидимый).
 * Метод вывода на экран должен выводить состояние всех полей объекта. 
 * Создать класс Point (точка) как потомок геометрической фигуры. 
 * Создать класс Circle (окружность) как потомок точки.
 * В класс Circle добавить метод, который вычисляет площадь окружности. 
 * Создать класс Rectangle (прямоугольник) как потомок точки,
 * реализовать метод вычисления площади прямоугольника.
 * Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали,
 * изменения цвета.
 */


public abstract class Figure
{
    protected uint _colour = 0;
    protected bool _visible = true;

    public bool Visible
    {
        get => _visible;
        set
        {
            if (value != _visible) { _visible = value; DoVisibleChange(); }
        }
    }
    public uint Colour
    {
        get => _colour;
        set
        {
            if (value != _colour) { _colour = value; DoColourChange(); }
        }
    }
    public abstract void MooveX(int value);
    public abstract void MooveY(int value);
    public abstract void Draw();

    public override string ToString() => $"Colour: {_colour}\tVisible: {_visible}";

    public void DoVisibleChange() => OnVisibleChanged?.Invoke(this, EventArgs.Empty);
    public void DoColourChange() => OnColourChanged?.Invoke(this, EventArgs.Empty);

    public event EventHandler OnVisibleChanged;
    public event EventHandler OnColourChanged;

    #region конструкторы
    protected Figure() { }
    protected Figure(int X, int Y, uint Colour, bool Visible)
    {
        _x = X;
        _y = Y;
        _colour = Colour;
        _visible = Visible;
    }
    protected Figure(int X, int Y)
    {
        _x = X;
        _y = Y;
    }
    #endregion
}
