namespace CountSubString.ConsoleClient
{
    using System;
    using CountSubString.ConsoleClient.ServiceReferenceCountSubStringService;

    class CountSubStringConsoleClient
    {
        static void Main(string[] args)
        {
            var text = "Alabala balaala bla ala";
            var subString = "ala";

            CountSubStringServiceClient client = new CountSubStringServiceClient();
            var result = client.CountSubString(text, subString);
            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Sub string: {0}", subString);
            Console.WriteLine("Contains {0} time(s)", result);
        }
    }
}