using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public class ClickableTextView : MonoBehaviour, IClickableTextView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        private int _index;
        
        public event Action<int> Clicked;

        public void Init(int index)
            => _index = index;

        public void ChangeText(string text)
            => _text.SetText(text);

        public void Activate()
            => _button.onClick.AddListener(OnClick);

        public void Deactivate()
            => _button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
            => Clicked?.Invoke(_index);
    }
}