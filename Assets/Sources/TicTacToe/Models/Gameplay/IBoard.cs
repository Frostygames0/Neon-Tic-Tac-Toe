using System;

namespace TicTacToe.Models.Gameplay
{
    public interface IBoard : IManuallyActivated
    {
        event Action<BoardResult, TileSide> Finished;
        event Action<int, TileSide> TileUpdated;
        
        bool TryPlaceSide(int index, TileSide side);

        void Reset();
    }   
    
    public enum BoardResult
    {
        StillGoing,
        GameWon,
        Tie
    }
}