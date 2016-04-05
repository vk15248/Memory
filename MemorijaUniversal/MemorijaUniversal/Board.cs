﻿using System;
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
        private List<Card> openCards;
        private int currentPlayer;

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

        public int CurrentPlayer
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
            openCards = new List<Card>();
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

        public bool playMove(Card card)
        {
            if(openCards.Count<2 && !openCards.Contains(card))
                openCards.Add(card);
            else if (openCards.Count == 2)
            {
                if(openCards[0].Number == openCards[1].Number)
                {
                    Cards[cards.IndexOf(openCards[0])].Isout = true;
                    Cards[cards.IndexOf(openCards[1])].Isout = true;
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer == numberOfPlayers) currentPlayer = 0;
                }
                openCards = new List<Card>();
                return true;
            }
            return false;
        }
    }
}
