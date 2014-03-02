namespace _02.Bank
{
    using System;

    public static class InterestCalculator
    {
        public static decimal CalcInterest(DepositAccount account, DateTime startDate)
        {
            if (account.CurrentAmount < 1000)
            {
                return 0m;
            }

            int months = (int)(DateTime.Now.Date - account.StartDate).TotalDays / 30;
            return months * account.InterestRate;
        }

        public static decimal CalcInterest(LoanAccount account, DateTime startDate)
        {
            int months = (int)(DateTime.Now.Date - account.StartDate).TotalDays / 30;
            if (account.Owner is PersonCustomer)
            {
                if (months < 3)
                {
                    return 0m;
                }
            }
            else if (account.Owner is OrganizationCustomer)
            {
                if (months < 2)
                {
                    return 0m;
                }
            }

            return months * account.InterestRate;
        }

        public static decimal CalcInterest(MortgageAccount account, DateTime startDate)
        {
            int months = (int)(DateTime.Now.Date - account.StartDate).TotalDays / 30;
            if (account.Owner is PersonCustomer)
            {
                if (months < 6)
                {
                    return 0m;
                }
            }
            else if (account.Owner is OrganizationCustomer)
            {
                if (months < 12)
                {
                    return months * account.InterestRate / 2m;
                }
            }

            return months * account.InterestRate;
        }
    }
}