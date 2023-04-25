using System;

namespace TicTacToe.Models.Gameplay
{
    public class ScoreCounter : IScoreCounter
    {
        public const int ScoreCount = 2;
        
        private readonly int[] _scores = new int[ScoreCount];
        
        public event Action<TileSide, int> ScoreUpdated;
        
        public void GrantScore(TileSide side)
        {
            if (side == TileSide.Indeterminate)
                throw new ArgumentOutOfRangeException(nameof(side),"You can't grant victory to the indeterminate side!");

            var sideNum = (int) side;

            if (sideNum >= _scores.Length || sideNum < 0)
                throw new IndexOutOfRangeException("tile side out of range what?");

            _scores[sideNum] += 1;
            ScoreUpdated?.Invoke(side, _scores[sideNum]);
        }
    }
}