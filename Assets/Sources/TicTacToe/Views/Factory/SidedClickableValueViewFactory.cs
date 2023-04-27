using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class SidedClickableValueViewFactory : ClickableValueViewFactory<GameSide>
    {
        [SerializeField] private SidedClickableValueView _prefab;

        protected override ClickableValueView<GameSide> Prefab => _prefab;
    }
}