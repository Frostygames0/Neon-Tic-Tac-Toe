using TicTacToe.Models.Commands;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class CommandButtonPresenter : IManuallyActivated
    {
        private readonly ICommand _command;
        private readonly ButtonView _view;
        
        public CommandButtonPresenter(ICommand command, ButtonView view)
        {
            _command = command;
            _view = view;
        }


        public void Activate()
            => _view.Pressed += OnPressed;

        public void Deactivate()
            => _view.Pressed -= OnPressed;

        private void OnPressed()
            => _command.Execute();
    }
}