namespace TicTacToe.Models.Commands
{
    // I wanted much simpler implementation of command pattern, so I've created my own Command (instead of using ICommand)
    public interface ICommand
    {
        void Execute();
    }
}