namespace TicTacToe.Views
{
    public interface IClickableTextView<TOutput> : IClickableView<TOutput>
    {
        void SetText(string text);
    }
}