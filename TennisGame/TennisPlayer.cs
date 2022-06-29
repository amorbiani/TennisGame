using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    internal class TennisPlayer
    {
        public string Name { get; set; }
        public int CurrentScore { get; set; }

        public ScoreType CurrentScoreType { get; set; }
        public int TotalWins { get; set; }
        public bool IsPlaying { get; set; }

        public TennisPlayer()
        {
            Name = "unknown";
            CurrentScore = 0;
            CurrentScoreType = ScoreType.Love;
            TotalWins = 0;
            IsPlaying = false;
        }

        public TennisPlayer(string name)
        {
            Name = name;
            CurrentScore = 0;
            CurrentScoreType = ScoreType.Love;
            TotalWins = 0;
            IsPlaying = false;
        }

        public void StartMatch()
        {
            CurrentScore = 0;
            CurrentScoreType = ScoreType.Love;
            IsPlaying = true;
        }
    }
}
