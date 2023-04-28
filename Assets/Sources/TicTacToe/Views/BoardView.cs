using System;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe.Views
{
    public class BoardView : MonoBehaviour, IBoardView
    {
        private IClickableTextView[] _clickableTextViews;
        
        public event Action<int> TileClicked;

        public void Init(int width, IClickableTextViewFactory factory)
        {
            _clickableTextViews = new IClickableTextView[width * width];
            
            for (int i = 0; i < _clickableTextViews.Length; i++)
            {
                _clickableTextViews[i] = factory.Create(i);
            }
        }

        public void UpdateTileText(int index, string value)
        {
            if (index > _clickableTextViews.Length || index < 0)
                return;
            _clickableTextViews[index].ChangeText(value);
        }

        public void Activate()
        {
            foreach (var tile in _clickableTextViews)
            {
                if (tile is null)
                    throw new InvalidOperationException("Trying to activate a board view before board was even initialized or tile view factory is bad!");
                
                tile.Activate();
                tile.Clicked += OnTileClicked;
            }
        }

        public void Deactivate()
        {
            foreach (var tile in _clickableTextViews)
            {
                if (tile is null)
                    throw new InvalidOperationException("Trying to activate a board view before board was even initialized or tile view factory is bad!");
                
                tile.Deactivate();
                tile.Clicked -= OnTileClicked;
            }
        }
        
        private void OnTileClicked(int index)
            => TileClicked?.Invoke(index);
    }
}