using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB2
{
    class PokerHand : HandOfCards
    {
        #region Clear
        public override void Clear() => cards.Clear();
        #endregion

        #region Remove and Add related
        public override void Add(PlayingCard card) => cards.Add(card);
        #endregion

        #region Poker Rank related
        //https://www.poker.org/poker-hands-ranking-chart/

        //Hint: using backing fields
        private PokerRank _rank = PokerRank.Unknown;
        private PlayingCard _rankHigh = null;
        private PlayingCard _rankHighPair1 = null;
        private PlayingCard _rankHighPair2 = null;

        public PokerRank Rank => _rank;
        public PlayingCard RankHiCard => _rankHigh;
        public PlayingCard RankHiCardPair1 => _rankHighPair1;
        public PlayingCard RankHiCardPair2 => _rankHighPair2;

        //Hint: Worker Methods to examine a sorted hand
        private int[] NrSameValue()
        {
            // [3,3,3,4,4] <- [3,2]
            // [2,2,3,4,5] <- [2]
            // [2,3,4,5,6] 
            // a = 0
            // b = 0
            // [a] == [b]?
            //Dictionary
            var dictionary = new Dictionary<PlayingCardValue, List<PlayingCardValue>>();
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    //Console.WriteLine($"i: {i} \t j: {j} \t cards[i].Value: {cards[i].Value} \t cards[j].Value: {cards[j].Value}");
                    if (i != j && cards[i].Value == cards[j].Value)
                    {
                        if (!dictionary.TryGetValue(cards[i].Value, out List<PlayingCardValue> value))
                        {
                            value = new List<PlayingCardValue> { };
                            dictionary.Add(cards[i].Value, value);
                        }
                        value.Add(cards[j].Value);
                        //Console.WriteLine($"[{string.Join(",",dictionary.Values.Select(v=>v.Count))}]");
                        break;
                    }

                }
            }

            var found = new List<int>();
            foreach (var value in dictionary.Values)
            {
                found.Add(value.Count);
            }

            return found.ToArray();

        }
        private bool IsSameColor(out PlayingCard HighCard)
        {
            HighCard = null;
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    if (cards[i] == cards[j])
                    {
                        var sameValue = NrSameValue();
                        return sameValue.Length > 0 && sameValue.Max() == 5;
                    }
                }
            }
            return false;
        }
        private bool IsConsecutive(out PlayingCard HighCard)
        {
            HighCard = null;
            for (int i = 0; i < 4; i++)
            {
                if ((int)cards[i].Value + 1 != (int)cards[i + 1].Value)
                {
                    return false;
                }

            }
            return true;
        }

        //Hint: Worker Properties to examine each rank
        private bool IsRoyalFlush => IsConsecutive(out _rankHigh) && IsSameColor(out _rankHigh) && _rankHigh.Value == PlayingCardValue.Ace;
        private bool IsStraightFlush => IsSameColor(out _rankHigh) && IsConsecutive(out _rankHigh);
        private bool IsFourOfAKind
        {
            get
            {
                var sameValue = NrSameValue();
                return sameValue.Length > 0 && sameValue.Max() == 4;
            }
        }
        private bool IsFullHouse  //NrSameValue == 3 && NrSameValue == 2;
        {
            get
            {
                var sameValue = NrSameValue();
                return sameValue.Length > 0 && sameValue.Length == 2 && sameValue.Max() == 3;
            }
        }
        private bool IsFlush => IsSameColor(out _rankHigh);
        private bool IsStraight => IsConsecutive(out _rankHigh);
        private bool IsThreeOfAKind
        {
            get
            {
                var sameValue = NrSameValue();
                return sameValue.Length > 0 && sameValue.Max() == 3;
            }
        }
        private bool IsTwoPair
        {
            get
            {
                var sameValue = NrSameValue(); // [2,2] = sant
                return sameValue.Length == 2 && sameValue.Max() == 2;

            }
        }
        private bool IsPair
        {
            get
            {
                var sameValue = NrSameValue();
                return sameValue.Length > 0 && sameValue.Max() == 2;
            }
        }

        public PokerRank DetermineRank()
        {
            ClearRank();

            if (IsRoyalFlush)
            {
                return PokerRank.RoyalFlush;
            }
            if (IsStraightFlush)
            {
                return PokerRank.StraightFlush;
            }
            if (IsFourOfAKind)
            {
                return PokerRank.FourOfAKind;
            }
            if (IsFullHouse)
            {
                return PokerRank.FullHouse;
            }
            if (IsFlush)
            {
                return PokerRank.Flush;
            }
            if (IsStraight)
            {
                return PokerRank.Straight;
            }
            if (IsThreeOfAKind)
            {
                return PokerRank.ThreeOfAKind;
            }
            if (IsTwoPair)
            {
                return PokerRank.TwoPair;
            }
            if (IsPair)
            {
                return PokerRank.Pair;
            }

            return PokerRank.HighCard;
        }

        //Hint: Clear rank
        private void ClearRank()
        {
            _rankHigh = null;
            _rankHighPair1 = null;
            _rankHighPair2 = null;
            _rank = PokerRank.Unknown;

        }
        #endregion
    }
}
