using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class TileViewFactory : MonoBehaviour, ITileViewFactory
    {
        [SerializeField] private TileView _prefab;
        [SerializeField] private Transform _parent;

        public ITileView Create(int index)
        {
            var view = Instantiate(_prefab, _parent);
            view.gameObject.name = "Tile: " + index;
            
            view.Init(index);
            
            return view;
        }
    }
}