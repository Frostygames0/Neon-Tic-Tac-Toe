using System;

namespace TicTacToe.Models.Gameplay
{
    public class ScoreCounter : IScoreCounter
    {
        private readonly int[] _scores;

        public int ScoreAmounts => _scores.Length;
        
        public event Action<int, int> ScoreUpdated;

        public ScoreCounter(int scoreAmounts)
        {
            _scores = new int[scoreAmounts];
        }

        public bool TryGrantScore(int score)
        {
            if (score >= ScoreAmounts || score < 0)
                return false;

            _scores[score] += 1;
            ScoreUpdated?.Invoke(score, _scores[score]);
            return true;
        }
    }
}