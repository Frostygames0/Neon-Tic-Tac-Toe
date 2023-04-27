namespace TicTacToe.Models.Commands
{
    // TODO re do it as some Restarter class with observer pattern 
    public class RestartCommand : ICommand
    {
        private readonly IResettable[] _resettables;

        public RestartCommand(params IResettable[] resettables)
            => _resettables = resettables;

        public void Execute()
        {
            foreach (var resettable in _resettables)
            {
                resettable.Reset();
            }
        }
    }
}