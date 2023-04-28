using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class ClickableTextViewFactory : MonoBehaviour, IClickableTextViewFactory
    {
        [SerializeField] private ClickableTextView _prefab;
        [SerializeField] private Transform _parent;

        public IClickableTextView Create(int index)
        {
            var view = Instantiate(_prefab, _parent);
            
            view.Init(index);
            view.gameObject.name = "Clickable Text View: " + index;
            
            return view;
        }
    }
}