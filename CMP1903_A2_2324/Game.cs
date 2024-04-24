using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        protected Die[]? dice;
        protected Testing tests;
        protected Random random;
        protected int p1Score;
        protected int p2Score;
        protected bool singlePlayer;

        public Game()
        {
            tests = new Testing();
            random = new Random();
        }

        public virtual void Play()
        {
            bool gameLoop = true;
            while (gameLoop)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play Sevens Out.");
                Console.WriteLine("2. Play Three or More.");
                Console.WriteLine("3. View stats.");
                Console.WriteLine("4. Perform tests.");
                Console.WriteLine("5. Exit");

                string? input = Console.ReadLine();
                switch (input) 
                {
                    case "1":
                        Console.Clear();
                        Game sevensOut = new SevensOut();
                        sevensOut.Play();
                        break;
                    case "2":
                        Console.Clear();
                        Game threeOrMore = new ThreeOrMore();
                        threeOrMore.Play();
                        break;
                    case "3":
                        bool statsLoop = true;
                        while (statsLoop)
                        {
                            Console.Clear();
                            Console.WriteLine("Choose an option:");
                            Console.WriteLine("1. View Sevens Out Statistics.");
                            Console.WriteLine("2. View Three or More Statistics.");
                            Console.WriteLine("3. Clear Sevens Out Statistics.");
                            Console.WriteLine("4. Clear Three or More Statistics.");
                            Console.WriteLine("5. Exit Statistics.");

                            string? statInput = Console.ReadLine();
                            switch (statInput)
                            {
                                case "1":
                                    Console.Clear();
                                    Statistics.sevensOut.DisplayStats();
                                    break;
                                case "2":
                                    Console.Clear();
                                    Statistics.threeOrMore.DisplayStats();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Statistics.sevensOut = new SevensOutStat();
                                    Console.WriteLine("Cleared Sevens Out Statistics.");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.Clear();
                                    Statistics.threeOrMore = new ThreeOrMoreStat();
                                    Console.WriteLine("Cleared Three or More Statistics.");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    Console.WriteLine("Exiting Statistics...");
                                    Console.ReadLine();
                                    statsLoop = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid input, make sure to input a number from 1-5.");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        gameLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, make sure to input a number from 1-5.");
                        Console.ReadLine();
                        break;
                }
            }
            

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

        protected static bool SelectPlayerType()
        {
            // Get whether they are playing singleplayer or multiplayer
            bool? singlePlayer = null;
            Console.WriteLine("Are you playing with a friend, or by yourself? (Y/N)");
            while (singlePlayer is null)
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
            return (bool)singlePlayer;
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
            Statistics.sevensOut.numberOfPlays++;
            Console.WriteLine("Welcome to Sevens Out!");

            singlePlayer = SelectPlayerType();

            p1Score = 0;
            p2Score = 0;
            bool p1Alive = true, p2Alive = true;

            // Start game
            Console.WriteLine("-----------------------");
            while (p1Alive || p2Alive)
            {
                if(p1Alive)
                {
                    Console.WriteLine("Player 1, it's your turn!");
                    Console.ReadLine();
                    RollDice();
                    Console.WriteLine($"You rolled: {dice[0].currentValue}, {dice[1].currentValue}");
                    if (dice[0].currentValue + dice[1].currentValue == 7)
                    {
                        Console.WriteLine("You rolled a seven, so you stop playing!");
                        p1Alive = false;
                    }
                    else
                    {
                        int sum = dice[0].currentValue + dice[1].currentValue;
                        if (dice[0].currentValue == dice[1].currentValue)
                        {
                            Console.WriteLine($"You rolled a double! You get {sum * 2} score!");
                            p1Score += sum * 2;
                        }
                        else
                        {
                            Console.WriteLine($"You rolled a {sum}, you get {sum} score");
                            p1Score += sum;
                        }
                    }
                    Console.ReadLine();
                    Console.WriteLine("-----------------------");
                }
                if (p2Alive)
                {
                    if (singlePlayer)
                    {
                        Console.WriteLine("Bot, it's your turn!");
                        Console.ReadLine();
                        RollDice();
                        Console.WriteLine($"The bot rolled: {dice[0].currentValue}, {dice[1].currentValue}");
                        if (dice[0].currentValue + dice[1].currentValue == 7)
                        {
                            Console.WriteLine("They rolled a seven, so they stop playing!");
                            p2Alive = false;
                        }
                        else
                        {
                            int sum = dice[0].currentValue + dice[1].currentValue;
                            if (dice[0].currentValue == dice[1].currentValue)
                            {
                                Console.WriteLine($"They rolled a double! they get {sum * 2} score!");
                                p2Score += sum * 2;
                            }
                            else
                            {
                                Console.WriteLine($"They rolled a {sum}, they get {sum} score");
                                p2Score += sum;
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
                            p2Alive = false;
                        }
                        else
                        {
                            int sum = dice[0].currentValue + dice[1].currentValue;
                            if (dice[0].currentValue == dice[1].currentValue)
                            {
                                Console.WriteLine($"You rolled a double! You get {sum * 2} score!");
                                p2Score += sum * 2;
                            }
                            else
                            {
                                Console.WriteLine($"You rolled a {sum}, you get {sum} score");
                                p2Score += sum;
                            }
                        }
                    }
                    Console.ReadLine();
                    Console.WriteLine("-----------------------");
                }
            }
            Console.WriteLine("Both players rolled a 7, so the game is over!");
            Console.ReadLine();
            Console.Write($"Player 1 got a score of {p1Score}");
            Console.ReadLine();
            Console.WriteLine($"""{(singlePlayer ? "The bot" : "Player 2")} got a score of {p2Score}""");
            Console.ReadLine();

            if (p1Score > p2Score)
            {
                Console.WriteLine("Player 1 wins!");
                Statistics.sevensOut.player1Wins++;
            }
            else if (p2Score > p1Score)
            {
                Console.WriteLine($"""{(singlePlayer ? "The bot" : "Player 2")} wins!""");
                Statistics.sevensOut.player2Wins++;
            }
            else
            {
                Console.WriteLine("It's a draw!");
                Statistics.sevensOut.draws++;
            }

            if (p1Score > Statistics.sevensOut.player1Highest)
            {
                Statistics.sevensOut.player1Highest = p1Score;
            }
            if (p2Score > Statistics.sevensOut.player2Highest)
            {
                Statistics.sevensOut.player2Highest = p2Score;
            }

            Console.WriteLine("Returning to menu...");
            Console.ReadLine();
        }
    }

    internal class ThreeOrMore : Game
    {
        public ThreeOrMore() : base()
        {
            
        }

        private void FindOfKind(List<int> values, bool player1, bool firstCheck = true)
        {

            string pronoun = (singlePlayer && !player1 ? "They" : "You");
            // Groups any 2 or more of a kind together. (Dice Number, Count)
            var groups = values.GroupBy(n => n).Where(g => g.Count() >= 2).OrderByDescending(g => g.Count());
            var highest = groups.FirstOrDefault();
            List<int> newValues;

            // Checks if there is a 2 or more of a kind
            if (highest != null)
            {
                Console.WriteLine($"{pronoun} got a {highest.Count()}-of-a-kind!");
                switch (highest.Count())
                {
                    case 2:
                        if (firstCheck)
                        {
                            if (!player1 && singlePlayer)
                            {
                                Console.WriteLine("Rerolling the rest.");

                                // Create 3 die and roll them, since we know the 2-of-a-kind already.
                                dice = [new Die(), new Die(), new Die()];
                                RollDice();
                                Console.ReadLine();

                                newValues = new() { highest.Key, highest.Key };

                                // Write new dice numbers
                                Console.Write("They rolled: ");
                                Console.Write($"{highest.Key} {highest.Key} ");
                                foreach (Die d in dice)
                                {
                                    Console.Write($"{d.currentValue} ");
                                    newValues.Add(d.currentValue);
                                }
                                Console.ReadLine();
                                FindOfKind(newValues, player1, false);
                                break;
                            }
                            Console.WriteLine("Would you like to reroll the rest of the dice, or all of them? (Y/N)");
                            bool invalidInput = true;
                            while (invalidInput)
                            {
                                string? input = Console.ReadLine();
                                if (input == null) continue;
                                switch (input.ToLower())
                                {
                                    case "y":
                                        Console.WriteLine("Rerolling the rest.");

                                        // Create 3 die and roll them, since we know the 2-of-a-kind already.
                                        dice = [new Die(), new Die(), new Die()];
                                        RollDice();
                                        Console.ReadLine();

                                        newValues = new() { highest.Key, highest.Key };

                                        // Write new dice numbers
                                        Console.Write("You rolled: ");
                                        Console.Write($"{highest.Key} {highest.Key} ");
                                        foreach (Die d in dice)
                                        {
                                            Console.Write($"{d.currentValue} ");
                                            newValues.Add(d.currentValue);
                                        }
                                        Console.ReadLine();
                                        FindOfKind(newValues, player1, false);
                                        invalidInput = false;
                                        break;
                                    case "n":
                                        Console.WriteLine("Rerolling all.");

                                        RollDice();
                                        Console.ReadLine();

                                        newValues = new();

                                        // Write new dice numbers
                                        Console.Write("You rolled: ");
                                        foreach (Die d in dice)
                                        {
                                            Console.Write($"{d.currentValue} ");
                                            newValues.Add(d.currentValue);
                                        }
                                        Console.ReadLine();
                                        FindOfKind(newValues, player1, false);

                                        invalidInput = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input.");
                                        break;
                                }
                            }
                        }
                        Statistics.threeOrMore.twoOfAKinds++;
                        break;
                    case 3:
                        if (player1)
                        {
                            p1Score += 3;
                            Console.WriteLine($"{pronoun} gain 3 points! (Total: {p1Score})");
                        }
                        else
                        {
                            p2Score += 3;
                            Console.WriteLine($"{pronoun} gain 3 points! (Total: {p2Score})");
                        }
                        Statistics.threeOrMore.threeOfAKinds++;
                        break;
                    case 4:
                        if (player1)
                        {
                            p1Score += 6;
                            Console.WriteLine($"{pronoun} gain 6 points!! (Total: {p1Score})");
                        }
                        else
                        {
                            p2Score += 6;
                            Console.WriteLine($"{pronoun} gain 6 points!! (Total: {p2Score})");
                        }
                        Statistics.threeOrMore.fourOfAKinds++;
                        break;
                    case 5:
                        if (player1)
                        {
                            p1Score += 12;
                            Console.WriteLine($"{pronoun} gain 12 points!!! (Total: {p1Score})");
                        }
                        else
                        {
                            p2Score += 12;
                            Console.WriteLine($"{pronoun} gain 12 points!!! (Total: {p2Score})");
                        }
                        Statistics.threeOrMore.fiveOfAKinds++;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{pronoun} didn't get any matches... :(");
                Statistics.threeOrMore.noMatches++;
            }
        }

        public override void Play()
        {
            Statistics.threeOrMore.numberOfPlays++;
            Console.WriteLine("Welcome to Three or More!");

            singlePlayer = SelectPlayerType();

            // Initialise variables
            p1Score = 0;
            p2Score = 0;
            List<int> values = new();

            // Start Game
            Console.WriteLine("-----------------------");

            while (p1Score < 20 && p2Score < 20)
            {
                // Player 1 Turn
                Console.WriteLine("Player 1, it's your turn!");

                dice = [new Die(), new Die(), new Die(), new Die(), new Die()];
                RollDice();
                Console.ReadLine();

                values = new();
                Console.Write($"You rolled: ");
                foreach ( Die d in dice )
                {
                    Console.Write($"{d.currentValue} ");
                    values.Add(d.currentValue);
                }
                Console.ReadLine();
                FindOfKind(values, true);

                // End P1 turn
                Console.WriteLine("-----------------------");
                // P2/Bot turn, check if P1 reached the score to win last turn.
                if (p1Score >= 20) break;
                Console.WriteLine(singlePlayer ? "It's the bot's turn!" : "Player 2, it's your turn!");

                dice = [new Die(), new Die(), new Die(), new Die(), new Die()];
                RollDice();
                Console.ReadLine();

                if (singlePlayer)
                {
                    values = new();
                    Console.Write($"They rolled: ");
                    foreach (Die d in dice)
                    {
                        Console.Write($"{d.currentValue} ");
                        values.Add(d.currentValue);
                    }
                    Console.ReadLine();
                    FindOfKind(values, false);

                }
                else
                {
                    values = new();
                    Console.Write($"You rolled: ");
                    foreach (Die d in dice)
                    {
                        Console.Write($"{d.currentValue} ");
                        values.Add(d.currentValue);
                    }
                    Console.ReadLine();
                    FindOfKind(values, false);
                }
                // End P2/Bot turn
                Console.WriteLine("-----------------------");
            }
            Console.ReadLine();
            if (p1Score >= 20)
            {
                Console.WriteLine($"Player 1 won with a score of {p1Score}!");
                Console.Read();
                Console.WriteLine($"{(singlePlayer ? "The bot" : "Player 2")} lost with a score of {p2Score}");
                Console.Read();
                Statistics.threeOrMore.player1Wins++;
            }
            else
            {
                Console.WriteLine($"{(singlePlayer ? "The bot" : "Player 2")} won with a score of {p2Score}!");
                Console.Read();
                Console.WriteLine($"Player 1 lost with a score of {p1Score}.");
                Console.Read();
                Statistics.threeOrMore.player2Wins++;
            }

            Console.WriteLine("Returning to menu...");
            Console.ReadLine();
        }
    }
}
