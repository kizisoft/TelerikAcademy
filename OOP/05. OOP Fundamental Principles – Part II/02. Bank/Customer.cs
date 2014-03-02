namespace _02.Bank
{
    public abstract class Customer
    {
        public BankAccount Accounts { get; protected set; }

        public string Name { get; protected set; }

        // Add new bank account
        public void AddAccount(BankAccount account)
        {
            this.Accounts = account;
        }
    }
}