using System;
using System.Linq;

namespace TicTacToe.Models.Gameplay
{
    public class Board : IBoard
    {
        private readonly Tile[] _tiles;
        
        private BoardResult _result;
        
        public event Action<BoardResult, GameSide> Finished;
        public event Action<int, GameSide> TileUpdated;

        public Board(int width)
        {
            _tiles = new Tile[width * width];
            _result = BoardResult.StillGoing;

            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new Tile();
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
            
            TileUpdated?.Invoke(index, tile.Side);
            
            CheckFinishingConditions();
            return true;
        }

        public void Reset()
        {
            for(int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i].Reset();
                TileUpdated?.Invoke(i, GameSide.Indeterminate);
            }

            _result = BoardResult.StillGoing;
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
                        _tiles[tup.Item3].Side == GameSide.Circle)
                        return (BoardResult.GameWon, GameSide.Circle);
                    if (_tiles[tup.Item1].Side == _tiles[tup.Item2].Side &&
                        _tiles[tup.Item2].Side == _tiles[tup.Item3].Side &&
                        _tiles[tup.Item3].Side == GameSide.Cross)
                        return (BoardResult.GameWon, GameSide.Cross);
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

        private class Tile : IResettable
        {
            public GameSide Side { get; private set; } = GameSide.Indeterminate;

            public bool TryPlace(GameSide side)
            {
                if (Side != GameSide.Indeterminate)
                    return false;

                Side = side;
                return true;
            }
            
            public void Reset()
            {
                Side = GameSide.Indeterminate;
            }
        }
    }
}