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

Point point = new(X: 10, Y: 10, Colour: 55, Visible: true);
Circle circle = new(X: 2, Y: 2, R: 5, Colour: 33, Visible: false);
Rectangle rectangle = new(X: 2, Y: 2, Width: 6, Height: 8, Colour: 33, Visible: false);

point.OnPositionChange += OnPositionChange;
circle.OnPositionChange += OnPositionChange;
rectangle.OnPositionChange += OnPositionChange;

point.Draw();
Console.WriteLine($"S= {point.Area()}");
point.MoveX(-1);
point.MoveY(1);
point.Draw();
Console.WriteLine();


circle.Draw();
Console.WriteLine($"S= {circle.Area()}");
circle.MoveX(-1);
circle.MoveY(1);
circle.Draw();
Console.WriteLine();

rectangle.Draw();
Console.WriteLine($"S= {rectangle.Area()}");
rectangle.MoveX(-1);
rectangle.MoveY(1);
rectangle.Draw();
Console.WriteLine();

Console.WriteLine("\nНажмите любую клавишу для выхода.");
Console.ReadKey();

static void OnPositionChange(object? sender, EventArgs e)
{
    if (sender is not Figure) return;
    Console.WriteLine($"****** событие PositionChange ({sender.GetType()}) ***** ");
}