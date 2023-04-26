using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public abstract class TileView<T> : MonoBehaviour, IManuallyActivated
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private int _index;

        public event Action<int> Clicked;

        public void Init(int index)
            => _index = index;

        public void Change(T value)
        {
            var updated = UpdateValue(value);
            _text.SetText(updated);
        }

        protected abstract string UpdateValue(T value);

        public void Activate()
            => _button.onClick.AddListener(OnClick);
        
        public void Deactivate()
            => _button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
            => Clicked?.Invoke(_index);
    }
}