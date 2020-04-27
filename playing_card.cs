using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp113
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingCard p1 = new PlayingCard(4, 13);
            Console.WriteLine(p1 + p1.SuitToString() + ", " + p1.RankToString());
            Console.ReadKey();
        }
    }

    internal class PlayingCard
    {
        private int rank;
        private int suit;



        
        public static int DIAMONDS = 1;
        public static int CLUBS = 2;
        public static int HEARTS = 3;
        public static int SPADES = 4;

        
        public static int ACE = 1;
        public static int DEUCE = 2;
        public static int THREE = 3;
        public static int FOUR = 4;
        public static int FIVE = 5;
        public static int SIX = 6;
        public static int SEVEN = 7;
        public static int EIGHT = 8;
        public static int NINE = 9;
        public static int TEN = 10;
        public static int JACK = 11;
        public static int QUEEN = 12;
        public static int KING = 13;
        public static bool isValidSuit(int suit)
        {
            if ((suit >= DIAMONDS) && (suit <= SPADES))
            {
               Console.WriteLine("VALID SUIT");
                return true;
            }
            return false;
        }
        public static bool isValidRank(int rank)
        {
            if ((rank >= ACE) && (rank <= KING))
            {
                Console.WriteLine("VALID RANK");
                return true;
            }
            return false;
        }
        public PlayingCard(int suit, int rank)
        {

            bool okrank = isValidRank(rank);
            bool oksuit = isValidSuit(suit);
            if (okrank == true)

                this.rank = rank;

            else
               Console.WriteLine("NOT A VALID RANK");
            if (oksuit == true)
                this.suit = suit;
            else
                Console.WriteLine("NOT A VALID SUIT");
        }
        public int getSuit()
        {
            return suit;
        }
        public int getRank()
        {
            return rank;
        }

        public string RankToString()
        {
            switch (rank)
            {
                case 1:
                    
                    return "Ace";
                
                case 2:
                    
                    return "Deuce";
                case 3:
                    
                    return "Three";
                case 4:
                    
                    return "Four";
                case 5:
                    
                    return "Five";
                case 6:
                    
                    return "Six";
                case 7:
                    
                    return "Seven";
                case 8:
                    
                    return "Eight";
                case 9:
                    
                    return "Nine";
                case 10:
                    
                    return "Ten";
                case 11:
                    
                    return "Jack";
                case 12:
                    
                    return "Queen";
                case 13:
                    
                    return "King";

                default:
                    return "error";
            }
        }
        public string SuitToString()
        {
            switch (suit)
            {
                case 1: return "DIAMONDS";
                case 2: return "CLUBS";
                case 3: return "HEARTS";
                case 4: return "SPADES";
                default: return "ERROR";

            }

        }
        public override string ToString()
        {
            return string.Format($" You introduced: {suit}, {rank}, equivalent to ");
        }

    }
}
