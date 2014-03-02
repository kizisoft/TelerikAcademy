namespace _02.Bank
{
    using System.Collections.Generic;

    public class Bank
    {
        public Bank(string name)
        {
            this.BankName = name;
        }

        public string BankName { get; protected set; }

        public List<Customer> Clients { get; protected set; }

        // Add new client
        public void AddClient(Customer client)
        {
            this.Clients.Add(client);
        }
    }
}