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


Console.WriteLine("\nНажмите любую клавишу для выхода.");
Console.ReadKey();

public class Point : Figure
{
    protected int _x = 0;
    protected int _y = 0;
    public int X { get => _x; set => SetPosition(X, _y); }
    public int Y { get => _y; set => SetPosition(_x, Y); }

    public override void MooveX(int value) => SetPosition(value, _y);
    public override void MooveY(int value) => SetPosition(_x, value);


    public void SetPosition(int X, int Y)
    {
        if (X == _x && Y == _y) return;
        _x = X; _y = Y;
        DoPositionChange();// вызов события..
    }

    public override void Draw() => Console.WriteLine("Point: " + ToString());
    public override string ToString() => $"X: {_x};\tY: {_y};\t" + base.ToString();
    public Point() { }
    public Point(int X, int Y) : base(X, Y) { }
    public Point(int X, int Y, uint Colour, bool Visible) : base(X, Y, Colour, Visible) { }

    public event EventHandler OnPositionChange;

    public void DoPositionChange() => OnPositionChange?.Invoke(this, EventArgs.Empty);
}

public class Circle : Point
{
    private int _r;
    public int R
    {
        get => _r;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Радиус < 0!");
            _r = value;
        }
    }
    public override void Draw() => Console.WriteLine(ToString());
    public override string ToString() => "Circle: " + Figure.ToString() + "";
    public Circle() { }
    public Circle(int X, int Y, int R) : base(X, Y) { }
    public Circle(int X, int Y, uint Colour, bool Visible) : base(X, Y, Colour, Visible) { }
}