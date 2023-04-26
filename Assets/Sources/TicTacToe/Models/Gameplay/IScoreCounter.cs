using System;

namespace TicTacToe.Models.Gameplay
{
    public interface IScoreCounter
    {
        event Action<int, int> ScoreUpdated;

        void GrantScore(int side);
    }
}