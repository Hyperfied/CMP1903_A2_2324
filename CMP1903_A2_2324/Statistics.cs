using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal static class Statistics
    {
        public static ThreeOrMoreStat threeOrMore = new();
        public static SevensOutStat sevensOut = new();

        public static void SaveData()
        {
            string threeOrMoreSerialised = JsonSerializer.Serialize(threeOrMore);
            string sevensOutSerialised = JsonSerializer.Serialize(sevensOut);

            using (StreamWriter sw = new StreamWriter("ThreeOrMoreStats.json"))
            {
                sw.WriteLine(threeOrMoreSerialised);
            }
            using (StreamWriter sw = new StreamWriter("SevensOutStats.json"))
            {
                sw.WriteLine(sevensOutSerialised);
            }
        }
        public static void LoadData()
        {
            string threeOrMoreSerialised;
            string sevensOutSerialised;
            try 
            {
                using (StreamReader sr = new StreamReader("ThreeOrMoreStats.json"))
                {
                    threeOrMoreSerialised = sr.ReadToEnd();
                }
                using (StreamReader sr = new StreamReader("SevensOutStats.json"))
                {
                    sevensOutSerialised = sr.ReadToEnd();
                }

                ThreeOrMoreStat threeOrMoreStat = JsonSerializer.Deserialize<ThreeOrMoreStat>(threeOrMoreSerialised);
                SevensOutStat sevensOutStat = JsonSerializer.Deserialize<SevensOutStat>(sevensOutSerialised);
                threeOrMore = threeOrMoreStat;
                sevensOut = sevensOutStat;
            } catch (FileNotFoundException e)
            {
                sevensOut = new();
                threeOrMore = new();
            }
            
        }
    }

    internal interface IGameStat
    {
        int numberOfPlays { get; set; }
        int player1Wins { get; set; }
        int player2Wins { get; set; }

        void DisplayStats();
    }

    internal class SevensOutStat : IGameStat
    {
        public int numberOfPlays { get; set; }
        public int player1Wins { get; set; }
        public int player2Wins { get; set; }
        public int draws { get; set; }
        public int player1Highest {  get; set; }
        public int player2Highest {  get; set; }

        public SevensOutStat()
        {
            numberOfPlays = 0;
            player1Wins = 0;
            player2Wins = 0;
            draws = 0;
            player1Highest = 0;
            player2Highest = 0;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Stats for Sevens Out:");
            Console.WriteLine($"Number of Plays: {numberOfPlays}");
            Console.WriteLine($"Player 1 Wins: {player1Wins}");
            Console.WriteLine($"Player 2/Bot Wins: {player2Wins}");
            Console.WriteLine($"Draws: {draws}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Player 1 Highest Score: {player1Highest}");
            Console.WriteLine($"Player 2/Bot Highest Score: {player2Highest}");
            Console.ReadLine();
        }
    }

    internal class ThreeOrMoreStat : IGameStat
    {
        public int numberOfPlays { get; set; }
        public int player1Wins {  get; set; }
        public int player2Wins { get; set; }
        public int noMatches { get; set; }
        public int twoOfAKinds { get; set; }
        public int threeOfAKinds { get; set; }
        public int fourOfAKinds { get; set; }
        public int fiveOfAKinds { get; set; }

        public ThreeOrMoreStat()
        {
            numberOfPlays = 0;
            player1Wins = 0;
            player2Wins = 0;
            noMatches = 0;
            twoOfAKinds = 0;
            threeOfAKinds = 0;
            fourOfAKinds = 0;
            fiveOfAKinds = 0;
        }
        
        public void DisplayStats()
        {
            Console.WriteLine("Stats for Three or More:");
            Console.WriteLine($"Number of Plays: {numberOfPlays}");
            Console.WriteLine($"Number of No Matches: {noMatches}");
            Console.WriteLine($"Number of 2-of-a-kinds: {twoOfAKinds}");
            Console.WriteLine($"Number of 3-of-a-kinds: {threeOfAKinds}");
            Console.WriteLine($"Number of 4-of-a-kinds: {fourOfAKinds}");
            Console.WriteLine($"Number of 5-of-a-kinds: {fiveOfAKinds}");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Player 1 Wins: {player1Wins}");
            Console.WriteLine($"Player 2/Bot Wins: {player2Wins}");
            Console.ReadLine();
        }
    }


    
}
