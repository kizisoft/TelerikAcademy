namespace CountSubString.Services
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICountSubStringService
    {
        [OperationContract]
        int CountSubString(string text, string subString);
    }
}