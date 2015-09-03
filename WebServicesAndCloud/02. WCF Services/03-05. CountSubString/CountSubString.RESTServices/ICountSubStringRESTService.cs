namespace CountSubString.RESTServices
{
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Web.Http;

    [ServiceContract]
    public interface ICountSubStringRESTService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "/CountSubString?text={text}&subString={subString}",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        int CountSubStringREST(string text, string subString);
    }
}