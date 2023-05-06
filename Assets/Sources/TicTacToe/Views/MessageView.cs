using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public class MessageView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _message;
        [SerializeField] private Button _button;
        
        public event Action Clicked;

        public void Show(string message)
        {
            _message.SetText(message);
            gameObject.SetActive(true);
        }

        public void Hide()
            => gameObject.SetActive(false);

        private void OnEnable()
            => _button.onClick.AddListener(OnClick);

        private void OnDisable()
            => _button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
            => Clicked?.Invoke();
    }
}