using System;
using TicTacToe.Shared;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class MessagePresenter : IActivatable
    {
        private readonly MessageView _view;
        private Action _onClick;
        
        public MessagePresenter(MessageView view)
        {
            _view = view;
        }

        public void Show(string message, Action onClick)
        {
            _onClick = onClick;
            _view.Show(message);
        }

        public void Activate()
            => _view.Clicked += OnClicked;
        
        public void Deactivate()
            => _view.Clicked -= OnClicked;
        
        private void OnClicked()
        {
            _onClick?.Invoke();
            _view.Hide();
        }
    }
}