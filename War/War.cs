using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class War
    {
        Player p1 = new Player("Player 1");
        Player p2 = new Player("Player 2");

        Deck deck = new Deck();
        List<Card> winnings = new List<Card>(); //Cards the winner of the hand will take. Done this way to more easily accomodate the possibility of consecutive wars

        //Can we still play the game or has it ended?
        bool canPlay = true;
        Player winner;

        //Clear the variables, shuffle the deck, deal cards.
        public void StartGame()
        {
            winner = null;
            canPlay = true;
            Deck.Shuffle(ref deck.cards);
            DealCards();

        }

        public void DealCards()
        {
            while(deck.cards.Count > 0)
            {
                p1.AddCard(deck.cards.Pop());
                p2.AddCard(deck.cards.Pop());
            }
            PlayGame();
        }

        public void PlayGame()
        {
            while(canPlay) //Keep playing until we have a winner
            {
                canPlay = PlayRound();
            }
            Console.WriteLine(winner.name + " Wins the game!");
        }

        //Check for if either player can still go on
        public bool CanContinue()
        {

            if (!p1.CanPlay())
            {
                winner = p2;
                return false;
            }
            else if (!p2.CanPlay())
            {
                winner = p1;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool PlayRound()
        {
            if (!CanContinue())
            {
                return false;
            }

            //Play cards, add them to winnings and compare
            Card a = p1.PlayCard(true);
            Card b = p2.PlayCard(true);

            winnings.Add(a);
            winnings.Add(b);

            if(a.value > b.value)
            {
                p1.WinHand(winnings);
                winnings.Clear();
            }
            else if (b.value > a.value)
            {
                p2.WinHand(winnings);
                winnings.Clear();
            }
            else
            {
                return CardWar();
            }

            return CanContinue();
        }

        public bool CardWar()
        {
            Console.WriteLine("\nWAR!\n");

            //Do we still have cards we can play?
            if (!CanContinue())
            {
                return false;
            }

            //Each player plays a facedown card
            winnings.Add(p1.PlayCard(false));
            winnings.Add(p2.PlayCard(false));

            //Check if we still have cards.If so, play another round with all the previous cards played as winnings until someone comes out on top.
            if (!CanContinue())
            {
                return false;
            } else
            {
                return PlayRound();
            }

            

        }

    }
}
