using TicTacToe.Models.Commands;
using TicTacToe.Views;
using UnityEngine.UI;

namespace TicTacToe.Presenters
{
    public class CommandButtonPresenter : IManuallyActivated
    {
        private readonly ICommand _command;
        private readonly Button _view;
        
        public CommandButtonPresenter(ICommand command, Button view)
        {
            _command = command;
            _view = view;
        }


        public void Activate()
            => _view.onClick.AddListener(OnPressed);

        public void Deactivate()
            => _view.onClick.RemoveListener(OnPressed);

        private void OnPressed()
            => _command.Execute();
    }
}