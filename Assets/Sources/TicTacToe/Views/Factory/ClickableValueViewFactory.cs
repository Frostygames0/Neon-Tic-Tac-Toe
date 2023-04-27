using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public abstract class ClickableValueViewFactory<T> : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        
        protected abstract ClickableValueView<T> Prefab { get; }

        public ClickableValueView<T> Create(int index)
        {
            var view = Instantiate(Prefab, _parent);
            view.gameObject.name = "Clickable View: " + index;
            
            view.Init(index);
            
            return view;
        }
    }
}