namespace _02.Bank
{
    using System;

    public class LoanAccount : BankAccount, IDepositable
    {
        public LoanAccount(decimal amount, decimal interestRate, DateTime startDate)
        {
            this.InterestRate = interestRate;
            this.CurrentAmount = amount;
            this.StartDate = startDate;
        }

        public override decimal InterestAmount
        {
            get { return InterestCalculator.CalcInterest(this, this.StartDate); }
        }

        // Implement the interfce methode for deposit amount
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount for deposit should be > 0.0!");
            }

            this.CurrentAmount += amount;
        }
    }
}