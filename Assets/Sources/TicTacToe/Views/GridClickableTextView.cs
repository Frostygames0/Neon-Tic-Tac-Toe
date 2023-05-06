using System;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe.Views
{
    public class GridClickableTextView : MonoBehaviour
    {
        private ClickableTextView[] _clickableTextViews;
        
        public event Action<int> Clicked;

        public void Init(int width, SimplePrefabFactory<ClickableTextView> factory)
        {
            _clickableTextViews = new ClickableTextView[width * width];
            
            for (int i = 0; i < _clickableTextViews.Length; i++)
            {
                var index = i; // Need this to pass it into lambda
                
                _clickableTextViews[index] = factory.Create(parent: transform);
                _clickableTextViews[index].Clicked += () => Clicked?.Invoke(index);
            }
        }

        public void UpdateTileText(int index, string value)
        {
            if (index > _clickableTextViews.Length || index < 0)
                return;
            _clickableTextViews[index].SetText(value);
        }
    }
}