using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    internal class TennisMatch
    {
        private const short WIN_POINTS = 4;
        private const short ADVANTAGE_POINTS = 2;
        public TennisPlayer Player1 { get; set; }
        public TennisPlayer Player2 { get; set; }
        public bool IsRunning { get; set; }
        public TennisMatch()
        {
            Player1 = null;
            Player2 = null;
            IsRunning = false;
        }

        public TennisMatch(TennisPlayer player1, TennisPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
            IsRunning = false;
        }

        // Method for showing menu and options
        public void Menu()
        {
            int option = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("------------------");
                Console.WriteLine();

                Console.WriteLine("SELECT OPTION");
                Console.WriteLine();

                Console.WriteLine("1) Start New Game: ");
                Console.WriteLine("2) View Score: ");
                Console.WriteLine("9) Exit: ");
                int.TryParse(Console.ReadLine(), out option);

                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        StartNewGame();
                        break;
                    case 2:
                        ViewScore();
                        break;
                    case 9:
                        Console.WriteLine("Thanks for playing. See you next time!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }

            } while (option != 9);
        }

        // Method for starting a new game
        private void StartNewGame()
        {
            ViewScore();

            IsRunning = true;

            // Reset statistics
            Player1.StartMatch();
            Player2.StartMatch();

            do
            {
                AssignPoint();
                CheckScore();
            } while (IsRunning);
        }

        // Method for assigning points to players
        private void AssignPoint()
        {
            int playerWhoScored = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Which Player has Scored?");
                Console.WriteLine($"1) {Player1.Name}");
                Console.WriteLine($"2) {Player2.Name}");
                int.TryParse(Console.ReadLine(), out playerWhoScored);

            } while (playerWhoScored != 1 && playerWhoScored != 2);

            if (playerWhoScored == 1) Player1.CurrentScore++;
            if (playerWhoScored == 2) Player2.CurrentScore++;
        }

        // Method for assigning score type to players
        private void AssignScoreType()
        {
            if (Player1.CurrentScore < 4 && IsRunning) Player1.CurrentScoreType = (ScoreType)Player1.CurrentScore;
            if (Player2.CurrentScore < 4 && IsRunning) Player2.CurrentScoreType = (ScoreType)Player2.CurrentScore;

            if (Player1.CurrentScore < 4 && Player2.CurrentScore < 4 || !IsRunning) return;

            if (Player1.CurrentScore > Player2.CurrentScore)
            {
                Player1.CurrentScoreType = ScoreType.Advantage;
                Player2.CurrentScoreType = ScoreType.Disadvantage;
            }
            if (Player2.CurrentScore > Player1.CurrentScore)
            {
                Player2.CurrentScoreType = ScoreType.Advantage;
                Player1.CurrentScoreType = ScoreType.Disadvantage;
            }
            if (Player1.CurrentScore == Player2.CurrentScore)
            {
                Player1.CurrentScoreType = ScoreType.Deuce;
                Player2.CurrentScoreType = ScoreType.Deuce;
            }
        }

        // Method for updating and showing score 
        private void CheckScore()
        {
            Console.WriteLine();
            Console.WriteLine("Current Score:");
            Console.WriteLine();

            CheckWinner();

            AssignScoreType();

            Console.WriteLine($"{Player1.Name}: {Player1.CurrentScoreType} ({Player1.CurrentScore})");
            Console.WriteLine($"{Player2.Name}: {Player2.CurrentScoreType} ({Player2.CurrentScore})");
        }

        // Method for checking if there is a winner
        private void CheckWinner()
        {
            if (Player1.CurrentScore >= WIN_POINTS && (Player1.CurrentScore - Player2.CurrentScore) >= ADVANTAGE_POINTS)
            {
                Console.WriteLine($"{Player1.Name} HAS WON!");
                Player1.CurrentScoreType = ScoreType.Win;
                Player2.CurrentScoreType = ScoreType.Lose;

                Player1.TotalWins++;
                IsRunning = false;
            }
            if (Player2.CurrentScore >= WIN_POINTS && (Player2.CurrentScore - Player1.CurrentScore) >= ADVANTAGE_POINTS)
            {
                Console.WriteLine($"{Player2.Name} HAS WON!");
                Player2.CurrentScoreType = ScoreType.Win;
                Player1.CurrentScoreType = ScoreType.Lose;

                Player2.TotalWins++;
                IsRunning = false;
            }
        }

        // Method for viewing total score
        private void ViewScore()
        {
            Console.WriteLine($"TOTAL WINS - {Player1.Name}: {Player1.TotalWins}, {Player2.Name}: {Player2.TotalWins} ");
        }
    }
}
