using System;

class ReadCompanyInfo
{
    static void Main()
    {
        // Input data for the company
        Console.Write("Input the company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Input the company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Input the company phone number: ");
        string companyPhone = Console.ReadLine();

        Console.Write("Input the company fax number: ");
        string companyFax = Console.ReadLine();

        Console.Write("Input the company web site: ");
        string companyWebSite = Console.ReadLine();

        // Input data for the manager
        Console.Write("Input the manager first name: ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Input the manager last name: ");
        string managerLastName = Console.ReadLine();

        // Repeat until enter an integer number
        int managerAge = 0;
        bool isInt;

        do
        {
            Console.Write("Input the manager age: ");
            isInt = !int.TryParse(Console.ReadLine(), out managerAge);

            if (isInt)
            {
                Console.WriteLine("Input a number");
            }
        } while (isInt);

        Console.Write("Input the manager phone number: ");
        string managerPhone = Console.ReadLine();
        Console.WriteLine();

        // Print data for the company
        Console.WriteLine("Company: {0}", companyName);
        Console.WriteLine("Company address: {0}", companyAddress);
        Console.WriteLine("Company phone number: {0}", companyPhone);
        Console.WriteLine("Company fax number: {0}", companyFax);
        Console.WriteLine("Company web site: {0}", companyWebSite);
        Console.WriteLine();

        // Print data for the manager
        Console.WriteLine("Мanager first name: {0}", managerFirstName);
        Console.WriteLine("Мanager last name: {0}", managerLastName);
        Console.WriteLine("Мanager аге: {0}", managerAge);
        Console.WriteLine("Manager phone number: {0}", managerPhone);
    }
}