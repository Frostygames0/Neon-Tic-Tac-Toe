using System;
using System.Linq;
using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public class Board : IBoard
    {
        public const int Width = 3;
        public static readonly (int, int, int)[] WinCombos = {
            (0, 1, 2), (3, 4, 5), (6, 7, 8),
            (0, 3, 6), (1, 4, 7), (2, 5, 8),
            (0, 4, 8), (2, 4, 6)
        };
        
        private readonly Tile[] _tiles;

        private BoardResult _result;
        
        public event Action<BoardResult, GameSide> Finished;
        public event Action<int, GameSide> TileUpdated;

        public Board()
        {
            _tiles = new Tile[Width * Width];
            _result = BoardResult.StillGoing;

            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new Tile();
            }
        }

        public bool TryMove(int index, GameSide side)
        {
            if (_result != BoardResult.StillGoing)
                return false;
            
            if (side == GameSide.Indeterminate)
                return false;

            if (CheckIfWithinBounds(index))
                return false;

            var tile = _tiles[index];
            if (!tile.TryPlace(side))
                return false;
            
            TileUpdated?.Invoke(index, tile.Side);
            CheckFinishingConditions();
            return true;
        }

        private bool CheckIfWithinBounds(int index)
        {
            return index >= _tiles.Length || index < 0;
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

        // TODO Replace this with something better, this is utterly terrible
        private void CheckFinishingConditions()
        {
            foreach (var tup in WinCombos)
            {
                if (_tiles[tup.Item1].Side == _tiles[tup.Item2].Side &&
                    _tiles[tup.Item2].Side == _tiles[tup.Item3].Side &&
                    _tiles[tup.Item3].Side == GameSide.Circle)
                    Finish(BoardResult.GameWon, GameSide.Circle);
                if (_tiles[tup.Item1].Side == _tiles[tup.Item2].Side &&
                    _tiles[tup.Item2].Side == _tiles[tup.Item3].Side &&
                    _tiles[tup.Item3].Side == GameSide.Cross)
                    Finish(BoardResult.GameWon, GameSide.Cross);
            }
                
            if(_tiles.All(tile => tile.Side != GameSide.Indeterminate))
                Finish(BoardResult.Tie, GameSide.Indeterminate);
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