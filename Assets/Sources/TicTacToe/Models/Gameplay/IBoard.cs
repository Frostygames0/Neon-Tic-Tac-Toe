using System;
using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public interface IBoard : IResettable
    {
        event Action<GameSide> Finished;
        event Action<int, GameSide> TileUpdated;
        
        bool TryMove(int index, GameSide side);
    }
}