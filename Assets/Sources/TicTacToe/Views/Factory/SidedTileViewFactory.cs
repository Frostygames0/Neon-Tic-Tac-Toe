using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class SidedTileViewFactory : TileViewFactory<GameSide>
    {
        [SerializeField] private SidedClickableValueView _prefab;

        protected override ClickableValueView<GameSide> Prefab => _prefab;
    }
}