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
        List<Card> winnings = new List<Card>();

        //Can we still play the game;
        bool canPlay = true;
        Player winner;

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
            while(canPlay)
            {
                canPlay = PlayRound();
            }
            Console.WriteLine(winner.name + " Wins the game!");
        }

        //Can we still play?
        public bool CanContinue()
        {
            //Check if anyone has lost
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

            //Play cards and compare
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
