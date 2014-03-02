namespace _02.Bank
{
    public class PersonCustomer : Customer
    {
        public PersonCustomer(string name, string lastName, BankAccount account)
        {
            this.Accounts = account;
            this.Name = name;
            this.LastName = lastName;
        }

        public string LastName { get; protected set; }
    }
}