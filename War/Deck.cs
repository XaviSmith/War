using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Deck
    {
        public Stack<Card> cards = new Stack<Card>();
        private static Random random = new Random(); //For shuffling

        //Fill out the deck with all suits and values;
        public Deck()
        {
            //Doing it this way in case we decide we ever want to change suit names or add/remove suits
            foreach(Card.Suit _suit in Enum.GetValues(typeof(Card.Suit)) )
            {
                //Starting at 2 because we don't have a 0 or 1 card
                for(int i=2; i<=14; i++)
                {
                    cards.Push(new Card(i, _suit));
                }
            }
        }

        //Convert stack to a list then Fisher-Yates shuffle. Passing by ref here mostly just because I wanted to play around with it.
        public static void Shuffle(ref Stack<Card> stack)
        {
            List<Card> _cards = stack.ToList(); //Conveting to a list just to make shuffling and debug logs easier
            int n = stack.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }

            stack = new Stack<Card>(_cards); //Convert our shuffled list back to a stack.

            //If we want to see what the deck looks like after being shuffled
            if(Program.logsEnabled)
            {
                Console.WriteLine("SHUFFLED CARDS: ");
                foreach(Card c in _cards)
                {
                    Console.WriteLine(c.Display());
                }
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
