using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        public Statistics statistics;
        protected Die[]? dice;
        protected Testing tests;
        protected Random random;

        public Game()
        {
            statistics = new Statistics();
            tests = new Testing();
            random = new Random();
        }

        public virtual void Play()
        {

        }

        protected void RollDice()
        {
            if (dice != null)
            {
                foreach (var die in dice)
                {
                    die.Roll(random);
                }
            }
        }
    }

    internal class SevensOut : Game
    {
        public SevensOut() : base()
        {
            dice = [new Die(), new Die()];
        }

        public override void Play()
        {
            Console.WriteLine("Welcome to Sevens Out!");

            // Get whether they are playing singleplayer or multiplayer
            bool? singlePlayer = null;
            Console.WriteLine("Are you playing with a friend, or by yourself? (Y/N)");
            while(singlePlayer is null)
            {
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "y":
                        singlePlayer = false;
                        break;
                    case "n":
                        singlePlayer = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;

                }
            }

            int p1score = 0, p2score = 0;
            bool p1alive = true, p2alive = true;

            while(p1alive || p2alive)
            {
                if(p1alive)
                {
                    Console.WriteLine("Player 1, it's your turn!");
                    Console.ReadLine();
                    RollDice();
                    Console.WriteLine($"You rolled: {dice[0].currentValue}, {dice[1].currentValue}");
                    if (dice[0].currentValue + dice[1].currentValue == 7)
                    {
                        Console.WriteLine("You rolled a seven, so you stop playing!");
                        p1alive = false;
                    }
                    else
                    {
                        int sum = dice[0].currentValue + dice[1].currentValue;
                        if (dice[0].currentValue == dice[1].currentValue)
                        {
                            Console.WriteLine($"You rolled a double! You get {sum * 2} score!");
                            p1score += sum * 2;
                        }
                        else
                        {
                            Console.WriteLine($"You rolled a {sum}, you get {sum} score");
                            p1score += sum;
                        }
                    }
                }
                if(p2alive)
                {
                    if ((bool)singlePlayer)
                    {
                        Console.WriteLine("Bot, it's your turn!");
                        Console.ReadLine();
                        RollDice();
                        Console.WriteLine($"The bot rolled: {dice[0].currentValue}, {dice[1].currentValue}");
                        if (dice[0].currentValue + dice[1].currentValue == 7)
                        {
                            Console.WriteLine("They rolled a seven, so they stop playing!");
                            p2alive = false;
                        }
                        else
                        {
                            int sum = dice[0].currentValue + dice[1].currentValue;
                            if (dice[0].currentValue == dice[1].currentValue)
                            {
                                Console.WriteLine($"They rolled a double! they get {sum * 2} score!");
                                p2score += sum * 2;
                            }
                            else
                            {
                                Console.WriteLine($"They rolled a {sum}, they get {sum} score");
                                p2score += sum;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Player 2, it's your turn!");
                        Console.ReadLine();
                        RollDice();
                        Console.WriteLine($"You rolled: {dice[0].currentValue}, {dice[1].currentValue}");
                        if (dice[0].currentValue + dice[1].currentValue == 7)
                        {
                            Console.WriteLine("You rolled a seven, so you stop playing!");
                            p2alive = false;
                        }
                        else
                        {
                            int sum = dice[0].currentValue + dice[1].currentValue;
                            if (dice[0].currentValue == dice[1].currentValue)
                            {
                                Console.WriteLine($"You rolled a double! You get {sum * 2} score!");
                                p2score += sum * 2;
                            }
                            else
                            {
                                Console.WriteLine($"You rolled a {sum}, you get {sum} score");
                                p2score += sum;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Both players rolled a 7, so the game is over!");
            Console.ReadLine();
            Console.Write($"Player 1 got a score of {p1score}");
            Console.ReadLine();
            Console.WriteLine($"""{((bool)singlePlayer ? "The bot" : "Player 2")} got a score of {p2score}""");
            Console.ReadLine();






            if (p1score > p2score)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (p2score > p1score)
            {
                Console.WriteLine($"""{((bool)singlePlayer ? "The bot" : "Player 2")} wins!""");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }
    }

    internal class ThreeOrMore : Game
    {
        public ThreeOrMore() : base()
        {
            dice = [new Die(), new Die(), new Die(), new Die(), new Die()];
        }

        public override void Play()
        {
            
        }
    }
}
