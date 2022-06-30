/*
 *      1.Создать класс счет в банке с закрытыми полями: номер счета, баланс,
 * тип банковского счета (использовать перечислимый тип).
 * Предусмотреть методы для доступа к данным – заполнения и чтения.
 * Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.
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

    private int _Number;
    private decimal _Balance;
    private BankAccountType _Type;

    public int GetNumber() => _Number; 
    public decimal GetBalance() => _Balance;
    public new BankAccountType GetType() => _Type;

    public void SetNumber(int value) => _Number = value;
    public void SetBalance(decimal value) => _Balance = value;
    public void SetType(BankAccountType value) => _Type = value;

    public override string ToString()
    {
        return $"Номер счета: {_Number}\t\tБаланс: {_Balance}\t\tТип: {_Type}";
    }
}