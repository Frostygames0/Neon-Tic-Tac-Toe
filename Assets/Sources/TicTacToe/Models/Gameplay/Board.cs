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

        private bool _stopped;
        
        public event Action<GameSide> Finished;
        public event Action<int, GameSide> TileUpdated;

        public Board()
        {
            _tiles = new Tile[Width * Width];
            _stopped = false;

            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new Tile();
            }
        }

        public bool TryMove(int index, GameSide side)
        {
            if (_stopped)
                return false;
            
            if (side == GameSide.Indeterminate)
                return false;

            if (CheckIfWithinBounds(index))
                return false;

            var tile = _tiles[index];
            if (!tile.TryPlace(side))
                return false;
            
            TileUpdated?.Invoke(index, tile.Side);
            
            if(CheckWinner(out GameSide winner))
                Finish(winner);
            
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

            _stopped = false;
        }

        // TODO Replace this with something better, this is utterly terrible (and not testable btw)
        private bool CheckWinner(out GameSide winner)
        {
            foreach (var tup in WinCombos)
            {
                var side1 = _tiles[tup.Item1].Side;
                var side2 = _tiles[tup.Item2].Side;
                var side3 = _tiles[tup.Item3].Side;

                if (side1 != side2 || side2 != side3) 
                    continue;
                
                if(side3 == GameSide.Indeterminate)
                    continue;

                winner = side3;
                return true;
            }

            if (_tiles.All(tile => tile.Side != GameSide.Indeterminate))
            {
                winner = GameSide.Indeterminate;
                return true;
            }

            winner = GameSide.Indeterminate;
            return false;
        }
        
        private void Finish(GameSide winner)
        {
            _stopped = true;
            Finished?.Invoke(winner);
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