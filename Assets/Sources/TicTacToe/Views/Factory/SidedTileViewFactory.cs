using UnityEngine;

namespace TicTacToe.Views.Factory
{
    public class SidedTileViewFactory : TileViewFactory<GameSide>
    {
        [SerializeField] private SidedTileView _prefab;

        protected override TileView<GameSide> Prefab => _prefab;
    }
}