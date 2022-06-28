/*
    2. Изменить класс счет в банке из упражнения таким образом,
чтобы номер счета генерировался сам и был уникальным.
Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.
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

    public int GetNumber() => _Number; 
    public decimal GetBalance() => _Balance;
    public new BankAccountType GetType() => _Type;

    public void SetNumber() => _Number = _NumberUnical++;
    public void SetBalance(decimal value) => _Balance = value;
    public void SetType(BankAccountType value) => _Type = value;

    public override string ToString()
    {
        return $"Номер счета: {_Number}\t\tБаланс: {_Balance}\t\tТип: {_Type}";
    }
}