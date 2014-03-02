namespace _02.Bank
{
    // Interface for accounts that could deposit in it
    public interface IDepositable
    {
        void Deposit(decimal amount);
    }
}