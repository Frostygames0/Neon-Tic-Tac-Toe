using System;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe.Views
{
    public class BoardView<T> : MonoBehaviour
    {
        private ClickableValueView<T>[] _tilesViews;
        
        public event Action<int> TileClicked;

        public void Init(TileViewFactory<T> tileViewFactory, int width)
        {
            _tilesViews = new ClickableValueView<T>[width * width];
            for (int i = 0; i < _tilesViews.Length; i++)
            {
                _tilesViews[i] = tileViewFactory.Create(i);
            }
        }

        public void UpdateTileSign(int index, T value)
        {
            if (index > _tilesViews.Length || index < 0)
                return;
            _tilesViews[index].Change(value);
        }

        public void Activate()
        {
            foreach (var tile in _tilesViews)
            {
                if (tile is null)
                    throw new InvalidOperationException("Trying to activate a board view before board was even initialized or tile view factory is bad!");
                
                tile.Activate();
                tile.Clicked += OnTileClicked;
            }
        }

        public void Deactivate()
        {
            foreach (var tile in _tilesViews)
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