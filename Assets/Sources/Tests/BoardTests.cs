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
        
        [TestCase(0, TileSide.X)]
        public void PlaceCorrectSideTest(int index, TileSide side)
            => Assert.True(_board.TryPlaceSide(index, side));
        
        [TestCase(0, TileSide.O)]
        public void PlaceToAlreadyOccupiedTest(int index, TileSide side)
            => Assert.False(_board.TryPlaceSide(index, side));
        
        [TestCase(1)]
        public void PlaceIndeterminateTest(int index)
            => Assert.False(_board.TryPlaceSide(index, TileSide.Indeterminate));
        
        [TestCase(TileSide.X)]
        public void PlaceOutOfRangeTest(TileSide side)
            => Assert.False(_board.TryPlaceSide(_width * _width, side));
        
        #endregion
    }
}
