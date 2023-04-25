using System;
using TicTacToe.Models.Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Views
{
    public class TileView : MonoBehaviour, ITileView
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        private int _index;

        public event Action<int> Clicked;

        public void Init(int index)
            => _index = index;

        public void ChangeSide(TileSide sign)
        {
            if (sign == TileSide.Indeterminate)
            {
                _text.text = "";
                return;
            }
            
            var convertedSign = sign.ToString("G");
            _text.text = convertedSign;
        }

        public void Activate()
            => _button.onClick.AddListener(OnClick);
        
        public void Deactivate()
            => _button.onClick.RemoveListener(OnClick);
        
        private void OnClick()
            => Clicked?.Invoke(_index);
    }
}