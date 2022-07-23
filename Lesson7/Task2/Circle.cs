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


/// <summary>
/// Окружность
/// </summary>
public class Circle : Point
{
    /// <summary>
    /// радиус
    /// </summary>
    private int _r;
    /// <summary>
    /// радиус
    /// </summary>
    public int R
    {
        get => _r;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException("Радиус < 0!");
            if(_r == value) return;
            _r = value;
            DoRadiusChange();
        }
    }
    public override void Draw() => Console.WriteLine("Circle: " + ToString());

    public override string ToString() => $"R: {_r};\t{base.ToString()}";
    public override double Area() => Math.PI * _r * _r;

    #region конструкторы
    public Circle() { }
    public Circle(int X, int Y, int R) : base(X, Y) => this.R = R;
    public Circle(int X, int Y, int R, uint Color, bool Visible) : base(X, Y, Color, Visible) => this.R = R;
    #endregion

    /// <summary>
    /// событие "изменение радиуса объекта"
    /// </summary>
    public event EventHandler OnRadiusChange;
    /// <summary>
    /// метод для вызова события OnRadiusChange - изменение радиуса
    /// </summary>
    public void DoRadiusChange() => OnRadiusChange?.Invoke(this, EventArgs.Empty);   

}