using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectB
{
    class DeckOfCards : IDeckOfCards
    {
        #region cards List related
        protected const int MaxNrOfCards = 52;
        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards);

        public PlayingCard this[int idx] => cards[idx];
        public int Count => cards.Count;
        #endregion

        #region ToString() related
        public override string ToString()
        {
            int createSpace = 0;
            string sRet = "";
            for (int i = 0; i < Count; i++)
            {
                if (cards[i] != null)
                {
                    sRet += String.Format("{0, -9}", cards[i].ToString());
                    createSpace++;

                    if (createSpace == 13)
                    {
                        sRet += "\n";
                        createSpace = 0;
                    }
                }
            }
            return sRet;
        }
        #endregion

        #region Shuffle and Sorting
        public void Shuffle()
        {
            var rnd = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int idx1 = rnd.Next(0, 52);
                int idx2 = rnd.Next(0, 52);
                while (idx1 == idx2)
                {
                    idx2 = rnd.Next(0, 52);
                }
                (cards[idx1], cards[idx2]) = (cards[idx2], cards[idx1]);
            }
            //cards = cards.OrderBy(i => rnd.Next()).ToList();

        }
        public void Sort()
        {
            //cards.Sort();
            cards = cards.OrderBy(c => c.Color).ToList();
            cards = cards.OrderBy(v => v.Value).ToList();
        }
        #endregion

        #region Creating a fresh Deck
        public void Clear()
        {
            cards.Clear();
        }
        public void CreateFreshDeck()
        {
            for (PlayingCardColor c = PlayingCardColor.Clubs; c <= PlayingCardColor.Spades; c++)
            {
                for (PlayingCardValue v = PlayingCardValue.Two; v <= PlayingCardValue.Ace; v++)
                {
                    cards.Add(new PlayingCard { Color = c, Value = v });
                }
            }


        }
        #endregion

        #region Dealing
        public PlayingCard RemoveTopCard()
        {
            PlayingCard topCard;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards.ElementAt(i) != null)
                {
                    topCard = cards.ElementAt(i);
                    cards.RemoveAt(i);
                    return topCard;
                }
            }
            Console.WriteLine("TopCard removed");
            return null;
        }
        #endregion
    }

}
