using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorijaUniversal
{
    public sealed class Board
    {
        int numberOfCards;
        int numberOfPlayers;
        private String deck; //TBD
        private List<Card> cards;
        private Int16 currentPlayer;

        private static readonly Board instance = new Board();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Board()
        {
        }

        private Board()
        {
        }

        public static Board Instance
        {
            get
            {
                return instance;
            }
        }


        public int NumberOfCards
        {
            get
            {
                return numberOfCards;
            }

            set
            {
                numberOfCards = value;
            }
        }

        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }

            set
            {
                numberOfPlayers = value;
            }
        }

        public string Deck
        {
            get
            {
                return deck;
            }

            set
            {
                deck = value;
            }
        }

        internal List<Card> Cards
        {
            get
            {
                return cards;
            }

            set
            {
                cards = value;
            }
        }

        public short CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }

            set
            {
                currentPlayer = value;
            }
        }

        public void startGame(int cards, int players)
        {
            NumberOfCards = cards;
            NumberOfPlayers = players;
            currentPlayer = 0;
            generateCards();

        }

        private void generateCards()
        {
            Random rnd = new Random();
            Cards = new List<Card>();
            while(Cards.Count< NumberOfCards) { 
                int num = rnd.Next(1, NumberOfCards/2 + 1);
                int n = 0;
                foreach (Card card in Cards){
                    if (card.Number == num) n++;
                }
                if (n < 2)
                {
                    Card card = new Card(num);
                    Cards.Add(card);
                }

            }
        }
    }
}
