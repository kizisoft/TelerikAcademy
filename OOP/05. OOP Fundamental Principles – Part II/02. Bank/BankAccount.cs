namespace _02.Bank
{
    using System;

    // Abstract class to be inherited from different account types
    public abstract class BankAccount
    {
        // customer, start date, balance and interest rate
        public Customer Owner { get; protected set; }

        public decimal CurrentAmount { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public abstract decimal InterestAmount { get; }
    }
}