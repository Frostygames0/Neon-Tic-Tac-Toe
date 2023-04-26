using System;

namespace TicTacToe.Models.Gameplay
{
    public class ScoreCounter : IScoreCounter
    {
        private readonly int[] _scores;

        public event Action<int, int> ScoreUpdated;

        public ScoreCounter(int scoreAmounts)
        {
            _scores = new int[scoreAmounts];
        }

        public void GrantScore(int side)
        {
            if (side >= _scores.Length || side < 0)
                throw new IndexOutOfRangeException("tile side out of range what?");

            _scores[side] += 1;
            ScoreUpdated?.Invoke(side, _scores[side]);
        }
    }
}