using System;

namespace TicTacToe.Models.Gameplay
{
    public interface IScoreCounter : IResettable
    {
        public int ScoreAmounts { get; }
        
        event Action<int, int> ScoreUpdated;

        bool TryGrantScore(int side);
    }
}