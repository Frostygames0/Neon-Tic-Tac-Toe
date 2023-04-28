using System;

namespace TicTacToe.Views
{
    public interface IClickableTextView : IManuallyActivated
    {
        event Action<int> Clicked;

        void ChangeText(string text);
    }
}