using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        public static bool logsEnabled = false; //Enable this to see logs such as what cards are added when we shuffle etc

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            War war = new War();

            war.StartGame();

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
