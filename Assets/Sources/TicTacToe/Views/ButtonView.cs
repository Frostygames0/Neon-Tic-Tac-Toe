using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action Pressed;

        private void OnEnable()
            => _button.onClick.AddListener(OnClicked);

        private void OnDisable()
            => _button.onClick.RemoveListener(OnClicked);

        private void OnClicked()
            => Pressed?.Invoke();
    }
}