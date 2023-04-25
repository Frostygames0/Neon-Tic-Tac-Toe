using System;

namespace TicTacToe.Views
{
    public interface IClickableView<TOutput> : IManuallyActivated
    {
        event Action<TOutput> Clicked;
    }
}