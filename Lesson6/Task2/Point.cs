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
/// ТОчка
/// </summary>
public class Point : Figure
{
    protected int _x = 0;
    protected int _y = 0;
    public int X { get => _x; set => SetPosition(value, _y); }
    public int Y { get => _y; set => SetPosition(_x, value); }

    public override void MoveX(int value) => SetPosition(value + _x, _y);
    public override void MoveY(int value) => SetPosition(_x, value + _y);


    public void SetPosition(int X, int Y)
    {
        if (X == _x && Y == _y) return;
        _x = X; _y = Y;
        DoPositionChange();// вызов события..
    }

    public override void Draw() => Console.WriteLine("Point: " + ToString());
    public override double Area() => 0;

    public override string ToString() => $"X: {_x};\tY: {_y};\t" + base.ToString();

    #region конструкторы
    public Point() { }
    public Point(int X, int Y)
    {
        SetPosition(X, Y);
    }
    public Point(int X, int Y, uint Colour, bool Visible) : this(X, Y)
    {
        this.Visible = Visible;
        this.Colour = Colour;
    }
    #endregion

    /// <summary>
    /// событие "изменение положения объекта"
    /// </summary>
    public event EventHandler OnPositionChange;
    /// <summary>
    /// метод для вызова события OnPositionChange - изменение положения
    /// </summary>
    public void DoPositionChange() => OnPositionChange?.Invoke(this, EventArgs.Empty);
}
