using System;

class Cards
{
    // Create an enumeration to represent cards deck
    public enum CardsDeck
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Then,
        Jack,
        Queen,
        King,
        Ace
    }

    // Create an enumeration to represent card colores
    public enum Colores
    {
        club = 1,
        diamonds,
        hearts,
        spades
    }

    static void Main()
    {
        // Loop for all 4 colors and all card
        for (int j = 1; j < 4; j++)
        {
            for (int i = 2; i <= 14; i++)
            {
                Console.WriteLine("{0} of {1}", (CardsDeck)i, (Colores)j);          // Print English name of card and colore
            }

            Console.WriteLine();
        }

    }
}