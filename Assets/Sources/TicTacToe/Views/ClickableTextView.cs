﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public class ClickableTextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;
        
        public event Action Clicked;
        
        public void SetText(string text)
            => _text.SetText(text);

        public void OnEnable()
            => _button.onClick.AddListener(OnClick);

        public void OnDisable()
            => _button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
            => Clicked?.Invoke();
    }
}