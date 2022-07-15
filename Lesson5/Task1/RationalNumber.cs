public readonly struct RationalNumber : ICloneable
{
    /// <summary>
    /// числитель
    /// </summary>
    private int _numerator = 0;
    /// <summary>
    /// знаменатель
    /// </summary>
    private int _denominator = 1;
    /// <summary>
    /// числитель
    /// </summary>
    public int Numerator { get => _numerator; }
    /// <summary>
    /// знаменатель
    /// </summary>
    public int Denominator { get => _denominator; }

    /// <summary>
    /// установка числителя и знаменателя с упрощением 
    /// </summary>
    /// <param name="numerator">числитель</param>
    /// <param name="denominator">знаменатель</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public RationalNumber Set(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentOutOfRangeException("Знаменатель равен 0!");
        if (denominator < 0)
        {//знак будет только у числителя!
            numerator = -numerator;
            denominator = -denominator;
        }
        _numerator = numerator;
        _denominator = denominator;

        return Simplify();
    }

    #region Конструкторы
    public RationalNumber(int numerator, int denominator) => Set(numerator, denominator);
    public RationalNumber() : this(0, 1) { }
    #endregion

    /// <summary>
    /// Упрощение рационального числа
    /// </summary>
    /// <returns></returns>
    private RationalNumber Simplify()
    {
        int nod = NOD(_numerator, _denominator);
        _numerator /= nod;
        _denominator /= nod;
        return this;
    }

    /// <summary>
    /// Преобразование к вещественному типу
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static double ToDouble(RationalNumber num) => num.ToDouble();
    public double ToDouble() => (double)_numerator / _denominator;

    public static bool operator ==(RationalNumber num1, RationalNumber num2) =>
        (num1._numerator == num2._numerator) && (num1._denominator == num2._denominator);
    public static bool operator !=(RationalNumber num1, RationalNumber num2) => !(num1 == num2);
    public static bool operator <(RationalNumber num1, RationalNumber num2) => (num1 - num2)._numerator < 0;
    public static bool operator >(RationalNumber num1, RationalNumber num2) => (num1 - num2)._numerator > 0;
    public static bool operator <=(RationalNumber num1, RationalNumber num2) => (num1 - num2)._numerator <= 0;
    public static bool operator >=(RationalNumber num1, RationalNumber num2) => (num1 - num2)._numerator >= 0;
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        return this == (RationalNumber)obj;
    }

    /// <summary>
    /// Создает копию объекта
    /// </summary>
    /// <returns></returns>
    public object Clone() => new RationalNumber(this._numerator, this._denominator);

    #region перегрузка операторов "+"
    public static RationalNumber operator +(RationalNumber num1, RationalNumber num2) =>
        new(num1.Numerator * num2.Denominator + num2.Numerator * num1.Denominator,
            num1.Denominator * num2.Denominator);

    public static RationalNumber operator +(int a, RationalNumber num) =>
        new(num.Numerator + a * num.Denominator, num.Denominator);

    public static RationalNumber operator +(RationalNumber num, int a) => a + num;

    #endregion

    #region перегрузка оператора "-"
    public static RationalNumber operator -(RationalNumber num1, RationalNumber num2)
    {
        RationalNumber res = new(num1.Numerator * num2.Denominator - num2.Numerator * num1.Denominator,
            num1.Denominator * num2.Denominator);
        return res;
    }
    public static RationalNumber operator -(int a, RationalNumber num)
    {
        RationalNumber res = new(-num.Numerator + a * num.Denominator, num.Denominator);
        return res;
    }
    public static RationalNumber operator -(RationalNumber num, int a)
    {
        return -a + num;
    }
    #endregion

    #region перегрузка инкркмента, десремента
    public static RationalNumber operator ++(RationalNumber num)
    {
        num.Set(num.Numerator + num.Denominator, num.Denominator);
        return num;
    }
    public static RationalNumber operator --(RationalNumber num)
    {
        num.Set(num.Numerator - num.Denominator, num.Denominator);
        return num;
    }
    #endregion

    public static RationalNumber operator -(RationalNumber num) => new(-num.Numerator, num.Denominator);

    /// <summary>
    /// Преобразование рационоального числа в string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (_denominator == 1)
            return _numerator.ToString();
        return $"{'{'}{_numerator} / {_denominator}{'}'}";
    }

    /// <summary>
    /// Наибольший общий делитель
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    private static int NOD(int num1, int num2)
    {
        num1 = (num1 < 0) ? -num1 : num1;
        num2 = (num2 < 0) ? -num2 : num2;
        while ((num1 != 0) && (num2 != 0))
        {
            if (num2 > num1) num2 = num2 % num1;
            else num1 = num1 % num2;
        }
        return num1 + num2;
    }

    /// <summary>
    /// явное преобразование в double
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator double(RationalNumber value) => value.ToDouble();

    /// <summary>
    /// явное преобразование в int
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator int(RationalNumber value) => value._numerator / value._denominator;

    /// <summary>
    /// Неявное преобразование в int
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator RationalNumber(int value) => new(value, 1);

    public static RationalNumber operator *(RationalNumber num1, RationalNumber num2) =>
        new RationalNumber(num1._numerator * num2._numerator, num1._denominator * num2._denominator);

    public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
    {
        if (num2._numerator == 0) throw new ArgumentException("Деление на ноль!");
        return new RationalNumber(num1._numerator * num2._denominator, num1._denominator * num2._numerator);
    }

    public static RationalNumber operator %(RationalNumber num1, RationalNumber num2)
    {
        RationalNumber res = num1 / num2;
        res -= (int)res;
        return res * num2;
    }
}
