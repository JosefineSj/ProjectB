using System;

namespace ProjectB
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

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();


            Console.WriteLine("Press enter to begin \n");
            Console.ReadKey();

            //Your code to play the game comes here


            Console.WriteLine("Let's play a game of highest card with two players! ");
            bool couldReadCard = TryReadNrOfCards(out int NrOfCards);
            if (couldReadCard == false)
                return;
            TryReadNrOfRounds(out int NrOfRounds);
            Console.WriteLine();

            for (int i = 0; i < NrOfRounds; i++)
            {
                Console.WriteLine($"Playing round nr {i + 1} \n------------------");
                Console.WriteLine();
                Deal(myDeck, NrOfCards, player1, player2);
                Console.WriteLine();
                DetermineWinner(player1, player2);
                player1.Clear();
                player2.Clear();
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Asking a user to give how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {

            bool inputWasWrong = true;
            do
            {
                Console.WriteLine("How many cards to deal to each player? (1-5 or Q to quit) ");
                string input = Console.ReadLine();
                int.TryParse(input, out NrOfCards);
                if (NrOfCards >= 1 && NrOfCards <= 5)
                {
                    inputWasWrong = false;
                }

                else if (input == "Q" || input == "q")
                {
                    Console.WriteLine("You chose to end the game - thanks for nothing!");
                    return false;

                }
                else
                    Console.WriteLine("Number was wrong, pls try again");


            } while (inputWasWrong);
            return true;


        }

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {

            bool inputIncorrect = true;
            do
            {
                Console.WriteLine("How many rounds should we play? (1-5 or Q to quit)");
                string input = Console.ReadLine();
                int.TryParse(input, out NrOfRounds);
                if (NrOfRounds >= 1 && NrOfRounds <= 5)
                    inputIncorrect = false;

                else if (input == "Q" || input == "q")
                {
                    Console.WriteLine("You chose to end the game - what are you even doing here?");
                    break;
                }
                else
                    Console.WriteLine("Number was wrong, pls try again");

            } while (inputIncorrect);
            return false;

        }


        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }
            Console.WriteLine($"Gave {nrCardsToPlayer} cards to each of the players from the top of the deck. Deck now has {myDeck.Count} cards \n");
            Console.WriteLine($"Player 1's hand with {nrCardsToPlayer} cards:");
            Console.WriteLine($"Lowest card in hand is {player1.Lowest} and the highest card is {player1.Highest}: ");
            Console.WriteLine($"{player1} \n");

            Console.WriteLine($"Player 2's hand with {nrCardsToPlayer} cards:");
            Console.WriteLine($"Lowest card in hand is {player2.Lowest} and the highest card is {player2.Highest}: ");
            Console.WriteLine($"{player2}");

        }

        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            if (player1.Highest.CompareTo(player2.Highest) > 0)
                Console.WriteLine("Player 1 is the winner!\n");
            if (player2.Highest.CompareTo(player1.Highest) > 0)
                Console.WriteLine("Player 2 is the winner!");
            if (player1.Highest.Equals(player2.Highest))
                Console.WriteLine("You are both winners!");


        }
    }

}
