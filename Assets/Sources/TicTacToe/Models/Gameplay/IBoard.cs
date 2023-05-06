using System;
using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public interface IBoard : IResettable
    {
        event Action<BoardResult, GameSide> Finished;
        event Action<int, GameSide> TileUpdated;
        
        bool TryMove(int index, GameSide side);
    }   
    
    public enum BoardResult
    {
        StillGoing,
        GameWon,
        Tie
    }
}