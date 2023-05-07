using NUnit.Framework;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;

namespace TicTacToe.Tests.Models
{
    public class BoardTests
    {
        private const int Length = 8;
        
        private IBoard _board;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }
        
        [Test]
        public void TryPlaceSide_CorrectPlacing_ReturnsTrue([Range(0, Length)] int index, [ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            var canPlaceCorrect = _board.TryMove(index, side);
            
            Assert.True(canPlaceCorrect);
        }
        
        [Test]
        public void TryPlaceSide_OutOfBoundsPositive_ReturnsFalse([ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            var positiveNumResult = _board.TryMove(Length + 1, side);

            Assert.False(positiveNumResult);
        }
        
        [Test]
        public void TryPlaceSide_OutOfBoundsNegative_ReturnsFalse([ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            var negativeNumResult = _board.TryMove(-1, side);
            
            Assert.False(negativeNumResult);
        }
        
        [Test]
        public void TryPlaceSide_Indeterminate_ReturnsFalse([Range(0, Length)] int index)
        {
            var result = _board.TryMove(index, GameSide.Indeterminate);
            
            Assert.False(result);
        }
        
        [Test]
        public void Reset_CanPlaceAgain_ReturnsTrue([Range(0, Length)] int index, [ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            _board.TryMove(index, GameSide.Circle);
            _board.Reset();
            
            var canBePlacedAgain = _board.TryMove(index, GameSide.Circle);
            
            Assert.True(canBePlacedAgain);
        }
        
        [Test]
        public void TileUpdated_RaisesCorrectly_ReturnsTrue([Range(0, 8)] int index, [ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            var correctIndex = false;
            var correctSide = false;
            
            _board.TileUpdated += (i, gameSide) =>
            {
                correctIndex = i == index;
                correctSide = gameSide == side;
            };
            
            _board.TryMove(index, side);
            
            Assert.True(correctIndex);
            Assert.True(correctSide);
        }
        
        [TestCaseSource(typeof(TestsData), nameof(TestsData.WinningCombosCases))]
        public void Finished_RaisesCorrectlyForWin_ReturnsTrue(int first, int second, int third)
        {
            var correctSide = false;
            _board.Finished += (side) => correctSide = side == GameSide.Circle;

            _board.TryMove(first, GameSide.Circle);
            _board.TryMove(second, GameSide.Circle);
            _board.TryMove(third, GameSide.Circle);
            
            Assert.True(correctSide);
        }
        
        [Test]
        public void Finished_RaisesCorrectlyForTie_ReturnsTrue()
        {
            var correctSide = false;

            _board.Finished += (side) => correctSide = side == GameSide.Indeterminate;

            _board.TryMove(0, GameSide.Circle);
            _board.TryMove(1, GameSide.Circle);
            _board.TryMove(2, GameSide.Cross);
            _board.TryMove(3, GameSide.Cross);
            _board.TryMove(4, GameSide.Cross);
            _board.TryMove(5, GameSide.Circle);
            _board.TryMove(6, GameSide.Circle);
            _board.TryMove(7, GameSide.Cross);
            _board.TryMove(8, GameSide.Circle);
            
            Assert.True(correctSide);
        }
    }
}
