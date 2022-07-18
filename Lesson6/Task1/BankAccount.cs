/*
 * 1. Для класса банковский счет переопределить операторы == и != для сравнения информации в двух счетах.
 * Переопределить метод Equals аналогично оператору ==, не забыть переопределить метод GetHashCode().
 * Переопределить методToString() для печати информации о счете.
 * Протестировать функционирование переопределенных методов и операторов на простом примере.
 */

public class BankAccount
{
    public enum BankAccountType
    {
        /// <summary>
        /// Бюджетный счёт
        /// </summary>
        Budget,
        /// <summary>
        /// Валютный счёт
        /// </summary>
        Foreign_currency,
        /// <summary>
        /// Замороженный счёт
        /// </summary>
        Frozen,
        /// <summary>
        /// Застрахованный счёт
        /// </summary>
        Insured,
        /// <summary>
        /// Контокоррентный счёт
        /// </summary>
        Checking,
        /// <summary>
        /// Корреспондентский счёт
        /// </summary>
        Correspondent,
        /// <summary>
        /// Накопительный счёт
        /// </summary>
        Savings,
        /// <summary>
        /// Обезличенный металлический счёт
        /// </summary>
        Impersonal_metal,
        /// <summary>
        /// Общий счёт
        /// </summary>
        Total_score,
        /// <summary>
        /// Онкольный счёт
        /// </summary>
        On_call,
        /// <summary>
        /// Сводный счёт
        /// </summary>
        Consolidated,
        /// <summary>
        /// Ссудный счёт
        /// </summary>
        Loan,
        /// <summary>
        /// Текущий счёт
        /// </summary>
        Current,
        /// <summary>
        /// Транзитный счёт
        /// </summary>
        Transit,
        /// <summary>
        /// Фидуциарный счёт
        /// </summary>
        Fiduciary,
        /// <summary>
        /// Фондовый счёт
        /// </summary>
        Stock,
        /// <summary>
        /// Частный счёт
        /// </summary>
        Private,
    }
    const int NumberStart = 1000555;

    /// <summary>
    /// Переводит запрошенную сумму со счета [source]
    /// </summary>
    /// <param name="source">счет источник</param>
    /// <param name="money"> сумма перевода</param>
    public void Transfer(BankAccount source, decimal money)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        source.GetMoney(money);
        _Balance += money;
    }



    #region конструкторы
    /// <summary>
    /// конструктор по умолчанию
    /// </summary>
    public BankAccount() : this(0, BankAccountType.Savings)
    {

    }

    public BankAccount(decimal Balance) : this(Balance, BankAccountType.Savings)
    {

    }

    public BankAccount(BankAccountType type) : this(0, type)
    {

    }

    public BankAccount(decimal balance, BankAccountType type)
    {
        _Number = CreateNumber();
        _Balance = balance;
        _Type = type;
    }
    #endregion

    public int Number { get => _Number; }
    public decimal Balance { get => _Balance; set => _Balance = value; }
    public BankAccountType Type { get => _Type; set => _Type = value; }

    /// <summary>
    /// положить деньги на счет
    /// </summary>
    /// <param name="money"></param>
    /// <returns>true - если все OK</returns>
    public void PutMoney(decimal money)
    {
        if (money < 0) throw new ArgumentOutOfRangeException(nameof(money), money, "Количество денег должно быть больше 0");
        _Balance += money;
    }

    /// <summary>
    /// снять деньги со счета
    /// </summary>
    /// <param name="money"></param>
    public void GetMoney(decimal money)
    {
        if (money < 0) throw new ArgumentOutOfRangeException(nameof(money), money, "Количество денег должно быть больше 0");
        if (money > _Balance) throw new ArgumentOutOfRangeException(nameof(money), money, "Недостаточно денег.");
        _Balance -= money;
    }

    public override string ToString()
    {
        return $"Номер счета: {_Number}\t\tБаланс: {_Balance}\t\tТип: {_Type}";
    }

    private static int _NumberUnical = NumberStart;
    private int _Number;
    private decimal _Balance;
    private BankAccountType _Type;

    /// <summary>
    /// создает уникальный номер
    /// </summary>
    private static int CreateNumber() => _NumberUnical++;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        BankAccount bankAccount = (BankAccount)obj;
        return Balance == bankAccount.Balance &&
               Type == bankAccount.Type &&
               Number == bankAccount.Number;
    }

    public static bool operator ==(BankAccount account1, BankAccount account2) => Equals(account1, account2);

    public static bool operator !=(BankAccount account1, BankAccount account2) => !(account1 == account2);

    public override int GetHashCode() => HashCode.Combine(_Number, _Balance, _Type);
}