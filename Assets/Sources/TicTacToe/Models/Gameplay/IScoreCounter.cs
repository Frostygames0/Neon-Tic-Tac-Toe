using System;
using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public interface IScoreCounter : IResettable
    {
        event Action<GameSide, int> ScoreUpdated;

        bool TryGrantScore(GameSide side);
    }
}