namespace _02.Humans
{
    // Worker class derived from Human 
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        // WeekSalary and WorkHoursPerDay
        public decimal WeekSalary { get; set; }

        public decimal WorkHoursPerDay { get; set; }

        // Return money per hour in decimal
        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay / 5m;
        }

        public override string ToString()
        {
            return string.Format("{0,-20} WeekSalary: {1,-15:C} WorkHoursPerDay: {2}", base.ToString(), this.WeekSalary, this.WorkHoursPerDay);
        }
    }
}