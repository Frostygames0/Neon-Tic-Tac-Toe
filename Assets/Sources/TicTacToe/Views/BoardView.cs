using System;
using TicTacToe.Models.Gameplay;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe.Views
{
    public class BoardView : MonoBehaviour, IBoardView
    {
        private ITileView[] _tilesViews;
        
        public event Action<int> TileClicked;

        public void Init(ITileViewFactory tileViewFactory, int width)
        {
            _tilesViews = new ITileView[width * width];
            for (int i = 0; i < _tilesViews.Length; i++)
            {
                _tilesViews[i] = tileViewFactory.Create(i);
            }
        }

        public void UpdateTileSign(int index, TileSide sign)
        {
            if (index > _tilesViews.Length || index < 0)
                return;
            _tilesViews[index].ChangeSide(sign);
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
                
                tile.Clicked -= OnTileClicked;
                tile.Deactivate();
            }
        }
        
        private void OnTileClicked(int index)
            => TileClicked?.Invoke(index);
    }
}