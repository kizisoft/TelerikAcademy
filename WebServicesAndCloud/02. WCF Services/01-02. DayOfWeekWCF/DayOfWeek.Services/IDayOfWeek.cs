namespace DayOfWeek.Services
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeek
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}