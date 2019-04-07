using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Player
    {
        public string name;
        private static Random random = new Random();
        private Stack<Card> cards = new Stack<Card>();
        private Stack<Card> spoils = new Stack<Card>(); //Cards we've won

        public Player(string _name)
        {
            name = _name;
        }

        public void AddCard(Card c)
        {
            cards.Push(c);
        }

        //bool for if we're playing the card faceDown or faceUp
        public Card PlayCard(bool faceUp)
        {
            if (cards.Count > 0)
            {
                Card c = cards.Pop();
                if(faceUp)
                {
                    Console.WriteLine(name + " plays " + c.Display());
                } else
                {
                    Console.WriteLine(name + " plays a card face down.");
                }
                
                Console.ReadKey();
                return c;
            }
            else return null;
        }

        //Do we have cards/spoils? If not, lose the game
        public bool CanPlay()
        {
            if(cards.Count == 0)
            {
                //If we have spoils, shuffle them and re-add them to the deck.
                if(spoils.Count > 0)
                {
                    //TODO Shuffle
                    Deck.Shuffle(ref spoils);
                    Console.WriteLine(name + " finished hand. Shuffling and adding their spoils of war!\n");

                    int count = spoils.Count;//Get the count because it will inevitably be modified when we pop
                    for(int i=0; i < count; i++)
                    {
                        if(Program.logsEnabled)
                        {
                            Console.WriteLine(name + " ADDING: " + spoils.Peek().Display());
                        }
                        
                        cards.Push(spoils.Pop());
                    }
                    spoils.Clear();
                    return true;
                } else
                {
                    //No cards in our deck/spoils. We lose.
                    Console.WriteLine(name + " is out of cards!");
                    return false;
                }
            } else
            {
                return true;
            }
        }

        //We won a hand. Print a message and add the cards to our spoils of war
        public void WinHand(List<Card> winnings)
        {
            Console.WriteLine(name + " wins the hand!\n");
            foreach(Card c in winnings)
            {
                spoils.Push(c);
            }
            Console.ReadKey();
        }

    }
}
