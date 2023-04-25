using System;

namespace TicTacToe.Models.Gameplay
{
    public interface IScoreCounter
    {
        event Action<TileSide, int> ScoreUpdated;

        void GrantScore(TileSide side);
    }
}