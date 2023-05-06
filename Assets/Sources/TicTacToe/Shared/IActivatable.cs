namespace TicTacToe.Shared
{
    // An interface for any object that should be manually activated (without unity)
    public interface IActivatable
    {
        void Activate();

        void Deactivate();
    }
}