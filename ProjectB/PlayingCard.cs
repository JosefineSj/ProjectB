using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
    {
        public PlayingCardColor Color { get; init; }
        public PlayingCardValue Value { get; init; }

        #region IComparable Implementation
        //Need only to compare value in the project
        public int CompareTo(PlayingCard card1)
        {
            int val = 0;
            if (Value < card1.Value)
                val--;
            if (Value > card1.Value)
                val++;

            return val;
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (obj is PlayingCard other)
            {
                return Value == other.Value;
            }
            return false;
        }

        #region ToString() related
        string ShortDescription
        {
            //Use switch statement or switch expression
            //https://en.wikipedia.org/wiki/Playing_cards_in_Unicode
            get
            {
                char c = Color switch
                {
                    PlayingCardColor.Clubs => '\u2663',
                    PlayingCardColor.Diamonds => '\u2666',
                    PlayingCardColor.Hearts => '\u2665',
                    PlayingCardColor.Spades => '\u2660',
                    _ => throw new NotImplementedException()

                };

                return $"{c}{Value}";
            }
        }

        public override string ToString() => ShortDescription;

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
