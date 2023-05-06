using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class SimplePrefabFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;

        public T Create(Transform parent)
        {
            var view = Instantiate(_prefab, parent);
            return view;
        }
    }
}