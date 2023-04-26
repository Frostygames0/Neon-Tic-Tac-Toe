using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public abstract class TileViewFactory<T> : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        
        protected abstract TileView<T> Prefab { get; }

        public TileView<T> Create(int index)
        {
            var view = Instantiate(Prefab, _parent);
            view.gameObject.name = "Tile: " + index;
            
            view.Init(index);
            
            return view;
        }
    }
}