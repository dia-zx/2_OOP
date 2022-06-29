/*
    3. В классе банковский счет удалить методы заполнения полей.
Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию,
создать конструктор для заполнения поля баланс,
конструктор для заполнения поля тип банковского счета,
конструктор для заполнения баланса и типа банковского счета.
Каждый конструктор должен вызывать метод, генерирующий номер счета.
*/

public class BankAccount
{
    public enum BankAccountType
    {
        Budget,             //Бюджетный счёт
        Foreign_currency,   //Валютный счёт
        Frozen,             //Замороженный счёт
        Insured,            //Застрахованный счёт
        Checking,           //Контокоррентный счёт
        Correspondent,      //Корреспондентский счёт
        Savings,            //Накопительный счёт
        Impersonal_metal,   //Обезличенный металлический счёт
        Total_score,        //Общий счёт
        On_call,            //Онкольный счёт
        Consolidated,       //Сводный счёт
        Loan,               //Ссудный счёт
        Current,            //Текущий счёт
        Transit,            //Транзитный счёт
        Fiduciary,          //Фидуциарный счёт
        Stock,              //Фондовый счёт
        Private,            //Частный счёт
    }
    const int NumberStart = 1000555;

    private static int _NumberUnical = NumberStart;
    private int _Number;
    private decimal _Balance;
    private BankAccountType _Type;

    /// <summary>
    /// конструктор по умоляанию
    /// </summary>
    public BankAccount()
    {
        SetNumber();
        _Balance = 0;
        _Type = BankAccountType.Savings;
    }

    public BankAccount(decimal Balance)
    {
        SetNumber();
        _Balance = Balance;
        _Type = BankAccountType.Savings;
    }

    public BankAccount(BankAccountType type)
    {
        SetNumber();
        _Balance = 0;
        _Type = type;
    }

    public BankAccount(decimal balance, BankAccountType type)
    {
        SetNumber();
        _Balance = balance;
        _Type = type;
    }

    public int GetNumber() => _Number;
    public decimal GetBalance() => _Balance;
    public new BankAccountType GetType() => _Type;

    private void SetNumber() => _Number = _NumberUnical++;


    public override string ToString()
    {
        return $"Номер счета: {_Number}\t\tБаланс: {_Balance}\t\tТип: {_Type}";
    }
}