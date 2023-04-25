namespace TicTacToe.Views.Factory
{
    public interface ITileViewFactory
    {
        ITileView Create(int index);
    }
}