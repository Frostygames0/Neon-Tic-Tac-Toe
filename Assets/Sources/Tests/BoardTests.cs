using NUnit.Framework;
using TicTacToe.Models.Gameplay;
using TicTacToe.Models.Gameplay.Factory;

namespace TicTacToe.Tests
{
    public class BoardTests
    {
        private IBoard _board;
        private int _width;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _width = 3;
            var tileFactory = new TileFactory();
            
            _board = new Board(tileFactory, _width);
        }

        #region SignPlacing
        
        [TestCase(0, GameSide.X)]
        public void PlaceCorrectSideTest(int index, GameSide side)
            => Assert.True(_board.TryPlaceSide(index, side));
        
        [TestCase(0, GameSide.O)]
        public void PlaceToAlreadyOccupiedTest(int index, GameSide side)
            => Assert.False(_board.TryPlaceSide(index, side));
        
        [TestCase(1)]
        public void PlaceIndeterminateTest(int index)
            => Assert.False(_board.TryPlaceSide(index, GameSide.Indeterminate));
        
        [TestCase(GameSide.X)]
        public void PlaceOutOfRangeTest(GameSide side)
            => Assert.False(_board.TryPlaceSide(_width * _width, side));
        
        #endregion
    }
}
