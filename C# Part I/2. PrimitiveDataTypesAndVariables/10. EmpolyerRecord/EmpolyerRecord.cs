using System;

class EmpolyerRecord
{
    enum Gender { Male, Female };       // Create enumeration for "Male" and "Female"

    static void Main()
    {
        // Declare variables
        string firstName = "Работник";
        string lastName = "Работников";
        byte age = 36;
        Gender gender = Gender.Male;    // Declare variable of enumeration type Gender
        long idNumber = 27560000;

        // Write variables on the console
        Console.WriteLine("First name: {0}", firstName);
        Console.WriteLine("Last name: {0}", lastName);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Gender: {0}", gender);
        Console.WriteLine("ID number: {0}", idNumber);
    }
}