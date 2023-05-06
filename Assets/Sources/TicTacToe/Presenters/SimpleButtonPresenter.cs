using System;
using TicTacToe.Shared;
using UnityEngine.UI;

namespace TicTacToe.Presenters
{
    public class SimpleButtonPresenter : IActivatable
    {
        private readonly Action _onClick;
        private readonly Button _view;
        
        public SimpleButtonPresenter(Button view, Action onClick)
        {
            _onClick = onClick;
            _view = view;
        }
        
        public void Activate()
            => _view.onClick.AddListener(OnPressed);

        public void Deactivate()
            => _view.onClick.RemoveListener(OnPressed);

        private void OnPressed()
            => _onClick?.Invoke();
    }
}