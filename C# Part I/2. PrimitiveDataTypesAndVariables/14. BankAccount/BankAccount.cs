using System;

class BankAccount
{
    static void Main()
    {
        // Declare variables
        string firstName = "Клиент";
        string midleName = "Клиентов";
        string lastName = "Клиентов";
        decimal balance = 1234.56m;
        string bankName = "TelerikBank";
        string codeIBAN = "BGTBSF123456789A321";
        string codeBIC = "BGTBSF";
        string creditCard1 = "1234567890098765431";
        string creditCard2 = "1234567890098765432";
        string creditCard3 = "1234567890098765433";

        // Write variables on the console
        Console.WriteLine("Client: {0} {1} {2}", firstName, midleName, lastName);
        Console.WriteLine("Client balance: {0}", balance);
        Console.WriteLine("Bank name: {0}", bankName);
        Console.WriteLine("IBAN: {0}", codeIBAN);
        Console.WriteLine("BIC: {0}", codeBIC);
        Console.WriteLine("Credit catd #1: {0}", creditCard1);
        Console.WriteLine("Credit catd #2: {0}", creditCard2);
        Console.WriteLine("Credit catd #3: {0}", creditCard3);
    }
}