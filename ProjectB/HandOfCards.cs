using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        #region Pick and Add related
        public void Add(PlayingCard card) => cards.Add(card);

        #endregion

        #region Highest Card related
        public PlayingCard Highest => cards.Max();
        public PlayingCard Lowest => cards.Min();

        #endregion
    }
}
