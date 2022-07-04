/*
    1. В класс банковский счет, созданный в упражнениях,
добавить метод, который переводит деньги с одного счета на другой.
У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги,
второй параметр – сумма.
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
    /// <returns>true - операция успешна</returns>
    public bool Transfer(BankAccount source, decimal money)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (!source.GetMoney(money)) return false;
        _Balance += money;
        return true;
    }



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

    public int Number { get => _Number; }
    public decimal Balance { get => _Balance; set => _Balance = value; }
    public BankAccountType Type { get => _Type; set => _Type = value; }

    /// <summary>
    /// положить деньги на счет
    /// </summary>
    /// <param name="money"></param>
    /// <returns>true - если все OK</returns>
    public bool PutMoney(decimal money)
    {
        if (money < 0) return false;
        _Balance += money;
        return true;
    }

    /// <summary>
    /// снять деньги со счета
    /// </summary>
    /// <param name="money"></param>
    /// <returns>true - если все OK</returns>
    public bool GetMoney(decimal money)
    {
        if (money < 0) throw new ArgumentOutOfRangeException(nameof(money), money, "Количество денег должно быть больше 0");
        if (money > _Balance) return false;
        _Balance -= money;
        return true;
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
    private static int CreateNumber() =>_NumberUnical++;
}