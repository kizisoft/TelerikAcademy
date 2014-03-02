namespace _02.Bank
{
    public class OrganizationCustomer : Customer
    {
        public OrganizationCustomer(string name, string shortName, BankAccount account)
        {
            this.Accounts = account;
            this.Name = name;
            this.ShortName = shortName;
        }

        public string ShortName { get; protected set; }
    }
}