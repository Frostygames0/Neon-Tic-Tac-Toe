namespace TicTacToe
{
    // An interface for any object that should be manually activated (without unity)
    public interface IManuallyActivated
    {
        void Activate();

        void Deactivate();
    }
}