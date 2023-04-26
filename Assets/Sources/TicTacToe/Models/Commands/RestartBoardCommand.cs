using TicTacToe.Models.Gameplay;

namespace TicTacToe.Models.Commands
{
    public class RestartBoardCommand : ICommand
    {
        private readonly IBoard _board;

        public RestartBoardCommand(IBoard board)
            => _board = board;

        public void Execute()
            => _board.Reset();
    }
}