using System;
using TicTacToe.Models.Gameplay;

namespace TicTacToe.Views
{
    public interface ITileView : IManuallyActivated
    {
        event Action<int> Clicked;
        void ChangeSide(TileSide sign);
    }
}