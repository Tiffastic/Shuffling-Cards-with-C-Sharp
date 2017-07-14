using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A03Cards
{
    struct Card : IComparable<Card>
    {
        
        //  properties
        public Rank Rank
        {
            get;
            private set;
        }


        public Suit Suit
        {
            get;
            private set;
        }

        // constructor
        public Card(Rank rank, Suit suit):this()
        {
            Rank = rank;
            Suit = suit;
        }


        // public methods
        public override string ToString()
        {
            return string.Format("{0} {1}", (char) Suit, Rank);
        }


        public int CompareTo(Card other)
        {
            if (Rank.CompareTo(other.Rank) < 0)
            {
                return -1;
            }
            else if (Rank.CompareTo(other.Rank) > 0)
            {
                return 1;
            }
            else
            {
                return this.Suit.CompareTo(other.Suit);
            }
            
        }


        // overloaded operators
        public static bool operator >(Card c1, Card c2)
        {
            if (c1.Rank > c2.Rank)
            {
                return true;
            }
            else if (c1.Rank < c2.Rank)
            {
                return false;
            }
            else
            {
                if (c1.Suit > c2.Suit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
   
        public static bool operator <(Card c1, Card c2)
        {
            if (c1.Rank < c2.Rank)
            {
                return true;
            }
            else if (c1.Rank > c2.Rank)
            {
                return false;
            }
            else
            {
                if (c1.Suit < c2.Suit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    
        public static bool operator >=(Card c1, Card c2)
        {
           if (c1 > c2)
           {
               return true;
           }
           else if (c1 == c2)
           {
               return true;
           }
           else
           {
               return false;
           }

           
        }
   
        public static bool operator <= (Card c1, Card c2)
        {
            if (c1 < c2)
            {
                return true;
            }
            else if (c1 == c2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator ==(Card c1, Card c2)
        {
            return (c1.Rank == c2.Rank) && (c1.Suit == c2.Suit);
        }
    
        public static bool operator !=(Card c1, Card c2)
        {
            return !(c1 == c2);
        }
    }
}
