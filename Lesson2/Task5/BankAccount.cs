/*
    5. * Добавить в класс счет в банке два метода:
снять со счета и положить на счет.
Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму,
и в случае положительного результата изменяет баланс.
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

    public int Number { get => _Number; }
    public decimal Balance { get => _Balance; set => _Balance = value; }
    public BankAccountType Type { get => _Type; set => _Type = value; }

    /// <summary>
    /// положить деньги на счет
    /// </summary>
    /// <param name="money"></param>
    /// <returns>true - если все OK</returns>
    public bool PutMoney(decimal money) { 
        if(money < 0) return false;
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
        if(money < 0) return false;
        if(money > _Balance) return false;
        _Balance -= money;
        return true;
    }

    /// <summary>
    /// создает уникальный номер
    /// </summary>
    private void SetNumber() => _Number = _NumberUnical++;


    public override string ToString()
    {
        return $"Номер счета: {_Number}\t\tБаланс: {_Balance}\t\tТип: {_Type}";
    }
}