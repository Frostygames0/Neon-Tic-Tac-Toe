using System;

namespace TicTacToe.Models.Gameplay
{
    public interface ITile : IResettable
    {
        GameSide Side { get; }
        event Action<int, GameSide> SideChanged;
        
        bool TryPlace(GameSide side);
    }
}