using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    //In this case, we're assuming Ace is the highest card in the deck
    class Card
    {
        public enum Suit { Hearts, Spades, Clubs, Diamonds }

        public int value;
        private Suit suit;
        private string label; //2, Queen, Jack etc

        public Card(int _value, Suit _suit)
        {
            value = _value;
            suit = _suit;
            SetLabel(_value);
        }

        private void SetLabel(int value)
        {
            if(value < 11)
            {
                label = value.ToString();
            } else
            {
                switch (value)
                {
                    case 11:
                        label = "Jack";
                        break;

                    case 12:
                        label = "Queen";
                        break;

                    case 13:
                        label = "King";
                        break;

                    case 14:
                        label = "Ace";
                        break;

                    default:
                        label = "Undefined";
                        break;
                }
            }
            
        }

        //show the card
        public string Display()
        {
            return label + " of " + suit.ToString();
        }
    }

}
