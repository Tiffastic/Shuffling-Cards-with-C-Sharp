using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A03Cards
{
    class Hand
    {
        
        // properties
        public List<Card> Cards
        {
            get;
            set;
        }

        
        // constructor
        public Hand(List<Card> newHand)
        {
            newHand.Sort();
            Cards = newHand;
        }


        // public methods
        public bool isFlush()
        {
            // five hards of same suit
            return !hasDifferentSuits();
        }


        public bool isStraight()
        {
            
            if (!hasDifferentSuits())
            {
                return false;
            }

            // check for special case of royal straight:
            if (isRoyalSequential())
            {
                return true;
            }

            return isSequential();

           
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            foreach (Card c in Cards)
            {
                sb.Append(string.Format("{0, -9}", c));
            }

            if (isFlush())
            {
                sb.Append(isSequential() ? "Straight Flush!" : isRoyalSequential() ? "Royal Flush!" : "Flush!");

            }
            else if (isStraight())
            {
                sb.Append((isRoyalSequential()) ? "Royal Straight!" : "Straight!");
            }

            return sb.ToString();

        }



        // private helper methods
        private bool hasDifferentSuits()
        {
            Suit suit = Cards[0].Suit;

            foreach (Card c in Cards)
            {
                if (c.Suit != suit)
                {
                    return true;
                }
            }

            return false;
            
        }


        private bool isRoyalSequential()
        {
            Rank first = Cards[0].Rank;
            Rank next;

            if (first == Rank.Ace)
            {
                next = Rank.Ten;
            }
            else
            {
                return false;
            }

            return isSequential(next);
          

        }


        private bool isSequential()
        {
            Rank first = Cards[0].Rank;
            Rank next = first + 1;

            return isSequential(next);
        }


        private bool isSequential(Rank next)
        {
            for (int i = 1; i < Cards.Count; i++)
            {
                if (Cards[i].Rank != next)
                {
                    return false;
                }
                next++;
            }

            return true;

        }
       


    }
}
