using System;
using TicTacToe.Models.Gameplay;

namespace TicTacToe.Views
{
    public interface IBoardView : IManuallyActivated
    {
        event Action<int> TileClicked;
        
        void UpdateTileSign(int index, TileSide sign);
    }
}