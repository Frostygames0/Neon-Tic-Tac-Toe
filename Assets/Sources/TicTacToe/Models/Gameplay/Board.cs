using System;
using System.Linq;
using TicTacToe.Models.Gameplay.Factory;

namespace TicTacToe.Models.Gameplay
{
    public class Board : IBoard
    {
        private readonly ITile[] _tiles;
        
        private BoardResult _result;
        
        public event Action<BoardResult, GameSide> Finished;
        public event Action<int, GameSide> TileUpdated;

        public Board(ITileFactory tileFactory, int width)
        {
            _tiles = new ITile[width * width];
            _result = BoardResult.StillGoing;

            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = tileFactory.Create(i);
            }
        }

        public bool TryPlaceSide(int index, GameSide side)
        {
            if (_result != BoardResult.StillGoing)
                return false;
            
            if (side == GameSide.Indeterminate)
                return false;

            if (index >= _tiles.Length || index < 0)
                return false;

            var tile = _tiles[index];
            if (!tile.TryPlace(side))
                return false;
            
            CheckFinishingConditions();
            return true;
        }

        public void Reset()
        {
            foreach (var tile in _tiles)
            {
                tile.Reset();
            }

            _result = BoardResult.StillGoing;
        }
        
        public void Activate()
        {
            foreach (var tile in _tiles)
            {
                tile.SideChanged += OnSideChanged;
            }
        }

        public void Deactivate()
        {
            foreach (var tile in _tiles)
            {
                tile.SideChanged -= OnSideChanged;
            }
        }

        // TODO EXTREMELY TERRIBLE, ABSOLUTELY DISGUSTING
        private void CheckFinishingConditions()
        {
            var aboba = CheckWinner();
            Finish(aboba.Item1, aboba.Item2);

            (BoardResult, GameSide) CheckWinner()
            {
                var winningCombos = new[]
                {
                    (0, 1, 2), (3, 4, 5), (6, 7, 8),
                    (0, 3, 6), (1, 4, 7), (2, 5, 8),
                    (0, 4, 8), (2, 4, 6)
                };
                
                foreach (var tup in winningCombos)
                {
                    if (_tiles[tup.Item1].Side == _tiles[tup.Item2].Side &&
                        _tiles[tup.Item2].Side == _tiles[tup.Item3].Side &&
                        _tiles[tup.Item3].Side == GameSide.O)
                        return (BoardResult.GameWon, GameSide.O);
                    if (_tiles[tup.Item1].Side == _tiles[tup.Item2].Side &&
                        _tiles[tup.Item2].Side == _tiles[tup.Item3].Side &&
                        _tiles[tup.Item3].Side == GameSide.X)
                        return (BoardResult.GameWon, GameSide.X);
                }

                return _tiles.All(tile => tile.Side != GameSide.Indeterminate) ? (BoardResult.Tie, GameSide.Indeterminate) : (BoardResult.StillGoing, GameSide.Indeterminate);
            }
        }

        private void Finish(BoardResult result, GameSide winner)
        {
            if (result == BoardResult.StillGoing)
                return;
            
            _result = result;
            Finished?.Invoke(_result, winner);
        }

        private void OnSideChanged(int index, GameSide newSide)
            => TileUpdated?.Invoke(index, newSide);
    }
}