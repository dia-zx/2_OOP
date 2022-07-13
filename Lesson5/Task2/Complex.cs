using System.Text;

/// <summary>
/// класс для работы с комплексными числами
/// </summary>
public class Complex : ICloneable
{
    /// <summary>
    /// мнимая часть
    /// </summary>
    private double _im = 0;
    /// <summary>
    /// действительная часть
    /// </summary>
    private double _re = 0;
    public double Re { get => _re; }
    public double Im { get => _im; }

    #region конструкторы
    public Complex(double re, double im)
    {
        _im = im;
        _re = re;
    }
    public Complex() { }
    public Complex(Complex value)
    {
        _im = value._im;
        _re = value._re;
    }
    #endregion

    public static Complex operator +(Complex z1, Complex z2) =>
        new Complex(z1._re + z2._re, z1._im + z2._im);
    public static Complex operator -(Complex z1, Complex z2) =>
        new Complex(z1._re - z2._re, z1._im - z2._im);
    public static Complex operator *(Complex z1, Complex z2) =>
        new Complex(z1._re * z2._re - z1._im * z2._im, z1._re * z2._im + z1._im * z2._re);
    public static Complex operator -(Complex z) => new(-z._re, -z._im);

    /// <summary>
    /// явное преобразование double в Complex
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Complex(double value) => new(value, 0);

    public static bool operator ==(Complex x, Complex y) => x.Equals(y);
    public static bool operator !=(Complex x, Complex y) => !(x.Equals(y));

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        Complex complex = (Complex)obj;
        return (_re == complex._re) && (_im == complex._im);
    }

    public override string ToString()
    {
        if (_im == 0) return _re.ToString();
        StringBuilder stringBuilder = new();
        if (_re != 0) stringBuilder.Append(_re);
        if ((_im > 0) && (_re != 0)) stringBuilder.Append('+');
        stringBuilder.Append(_im);
        stringBuilder.Append("·i");
        return stringBuilder.ToString();
    }

    //клонирование объекта
    public object Clone() => new Complex(this);
}
