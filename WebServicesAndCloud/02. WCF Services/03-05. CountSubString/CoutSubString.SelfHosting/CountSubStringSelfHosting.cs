namespace CoutSubString.SelfHosting
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    using CountSubString.Services;

    class CountSubStringSelfHosting
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:4666";
            var behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            ServiceHost host = new ServiceHost(typeof(CountSubStringService), new Uri(uri));
            host.Description.Behaviors.Add(behavior);
            host.Open();

            Console.WriteLine("The service is running on {0}...", uri);
            Console.WriteLine("Press any key to stop it!");
            Console.ReadKey();

            host.Close();
        }
    }
}