namespace _02.Bank
{
    using System;

    public class BankTest
    {
        public static void Main(string[] args)
        {
            var bank = new Bank("Antinare");
            bank.AddClient(new PersonCustomer("Petar", "Pertov", new DepositAccount(1234m, 0.05m, new DateTime(2014, 01, 02))));
        }
    }
}