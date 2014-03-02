namespace _02.Bank
{
    // Interface for accounts that could withdraw from it
    public interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}