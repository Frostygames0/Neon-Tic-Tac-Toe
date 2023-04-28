using System;

namespace TicTacToe.Views
{
    public interface IBoardView
    {
        event Action<int> TileClicked;
        
        void UpdateTileText(int index, string value);
    }
}