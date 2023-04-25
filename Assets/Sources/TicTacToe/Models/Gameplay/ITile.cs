using System;

namespace TicTacToe.Models.Gameplay
{
    public interface ITile
    {
        TileSide Side { get; }
        event Action<int, TileSide> SideChanged;
        
        bool TryPlaceSign(TileSide sign);

        void Reset();
    }
    
    public enum TileSide
    {
        X,
        O,
        Indeterminate
    }
}