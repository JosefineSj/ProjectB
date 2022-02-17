using System;

namespace ProjectB2
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            Console.WriteLine("Press enter to begin!\n");
            Console.ReadKey();

            PokerHand Player = new PokerHand();
            while (myDeck.Count > 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    Player.Add(myDeck.RemoveTopCard());
                }

                Console.WriteLine("Player hand: " + Player.ToString());

                var playerRank = Player.DetermineRank();
                Console.WriteLine("Rank is " + playerRank.ToString() + " with rank-high-card " + Player.Highest);
                Console.WriteLine("Deck now has " + myDeck.Count + " cards.\n");

                Player.Clear();
            }

            Console.WriteLine("Press enter to sort");
            Console.ReadKey();
            myDeck.Clear();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine();
            myDeck.Sort();
            while (myDeck.Count > 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    Player.Add(myDeck.RemoveTopCard());
                }

                Console.WriteLine("Player hand: " + Player.ToString());
                var playerRank = Player.DetermineRank();
                Console.WriteLine("Rank is " + playerRank.ToString() + " with rank-high-card " + Player.Highest);
                Console.WriteLine("Deck now has " + myDeck.Count + " cards.\n");
                Player.Clear();
            }
        }
    }
}

