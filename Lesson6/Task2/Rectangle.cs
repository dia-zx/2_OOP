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

/// <summary>
/// Прямоугольник
/// </summary>
public class Rectangle : Point
{
    /// <summary>
    /// ширина
    /// </summary>
    private int _width;
    /// <summary>
    /// высота
    /// </summary>
    private int _height;
    /// <summary>
    /// ширина
    /// </summary>
    public int Width
    {
        get => _width;
        set
        {
            if (_width == value) return;
            _width = value;
            DoWidthChange();
        }
    }
    /// <summary>
    /// высота
    /// </summary>
    public int Height
    {
        get => _height;
        set
        {
            if (_height == value) return;
            _height = value;
            DoHeightChange();
        }
    }

    public override void Draw() => Console.WriteLine("Rectangle: " + ToString());
    public override string ToString() => $"Width: {_width};\tHeight: {_height};\t {base.ToString()}";
    public override double Area() => _height * _width;

    #region конструкторы
    public Rectangle() { }
    public Rectangle(int X, int Y, int Width, int Height) : base(X, Y)
    {
        this.Width = Width;
        this.Height = Height;
    }
    public Rectangle(int X, int Y, int Width, int Height, uint Colour, bool Visible) : base(X, Y, Colour, Visible)
    {
        this.Width = Width;
        this.Height = Height;
    }
    #endregion

    /// <summary>
    /// событие "изменение высоты объекта"
    /// </summary>
    public event EventHandler OnHeightChange;
    /// <summary>
    /// событие "изменение ширины объекта"
    /// </summary>
    public event EventHandler OnWidthChange;

    /// <summary>
    /// метод для вызова события OnHeightChange - изменение высоты объекта
    /// </summary>
    public void DoHeightChange() => OnHeightChange?.Invoke(this, EventArgs.Empty);
    /// <summary>
    /// метод для вызова события OnWidthChange - изменение ширины объекта
    /// </summary>
    public void DoWidthChange() => OnWidthChange?.Invoke(this, EventArgs.Empty);

}

