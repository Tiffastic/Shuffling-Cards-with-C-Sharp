using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A03Cards
{
    class Deck
    {
        
        // properties
        public List<Card> Cards
        {
            get;
            private set;
        }   

        public Deck()
        {
            Cards = NewDeck();
        }

        public Deck(List<Card> cardDeck)
        {
            Cards = cardDeck;
        }


        // fields
        private Random random = new Random();


        // methods
        public static List<Card> NewDeck()
        {
            List<Card> deck = new List<Card>();

            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank r in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(r, s));
                }
            }

            return deck;
        }

        public void Shuffle()
        {
            KnuthShuffle();
            KnuthShuffle();

        }

        public List<Card> Deal(int i)
        {

            if (i > Cards.Count)
            {
                throw new ArgumentOutOfRangeException("Not enough cards in the deck");
            }


            List<Card> dealt = new List<Card>();

            for (int j = 0; j < i; j++)
            {
                Card card = Cards[0];
                dealt.Add(card);
                Cards.RemoveAt(0);
            }

            return dealt;
               
        }

        public override string ToString()
        {
           
            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach(Card c in Cards)
            {
                count++;
                sb.Append(string.Format("{0, -9}", c));

                if (count %4 == 0)
                {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        
        // private methods
        private void KnuthShuffle()
        {
            for (int i = 2; i < Cards.Count; i++)
            {
                int j = random.Next(i);
                Card temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
    }
}
