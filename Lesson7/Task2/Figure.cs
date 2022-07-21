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


public abstract class Figure : IFigure
{
    #region конструкторы
    protected Figure() { }
    protected Figure(int X, int Y) => SetPosition(X, Y);
    protected Figure(int X, int Y, uint Color, bool Visible) : this(X, Y)
    {
        _color = Color;
        _visible = Visible;
    } 
    #endregion

    /// <summary>
    /// координата по горизонтали
    /// </summary>
    protected int _x = 0;
    /// <summary>
    /// координата по вертикали
    /// </summary>
    protected int _y = 0;
    /// <summary>
    /// цвет
    /// </summary>
    protected uint _color = 0;
    /// <summary>
    /// состояние (видимый/невидимый) true - видимый
    /// </summary>
    protected bool _visible = true;

    public virtual int X { get => _x; set => SetPosition(value, _y); }
    public virtual int Y { get => _y; set => SetPosition(_x, value); }

    public virtual bool Visible
    {
        get => _visible;
        set
        {
            if (value != _visible) { _visible = value; DoVisibleChange(); }
        }
    }
    public virtual uint Color
    {
        get => _color;
        set
        {
            if (value != _color) { _color = value; DoColorChange(); }
        }
    }

    public virtual void SetPosition(int X, int Y)
    {
        if (X == _x && Y == _y) return;
        _x = X; _y = Y;
        DoPositionChange();// вызов события..
    }
    public virtual void MoveX(int value) => SetPosition(value + _x, _y);
    public virtual void MoveY(int value) => SetPosition(_x, value + _y);
    public abstract void Draw();
    public abstract double Area();
    public override string ToString() => $"X: {_x};\tY: {_y};\tColor: {_color}\tVisible: {_visible}";

    public event EventHandler OnVisibleChanged;
    public event EventHandler OnColorChanged;
    public event EventHandler OnPositionChange;

    public void DoVisibleChange() => OnVisibleChanged?.Invoke(this, EventArgs.Empty);
    public void DoColorChange() => OnColorChanged?.Invoke(this, EventArgs.Empty);
    public void DoPositionChange() => OnPositionChange?.Invoke(this, EventArgs.Empty);
}
