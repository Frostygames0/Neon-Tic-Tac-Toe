using NUnit.Framework;
using TicTacToe.Models.Gameplay;

namespace TicTacToe.Tests.Models
{
    [TestFixture(3)]
    public class BoardTests
    {
        private readonly int _width;
        
        private IBoard _board;

        public BoardTests(int width)
        {
            _width = width;
        }
        
        [SetUp]
        public void SetUp()
        {
            _board = new Board(_width);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.TryPlaceSideCases))]
        public void TryPlaceSide_CorrectPlacing_ReturnsTrue(GameSide side)
        {
            var canPlaceCorrect = _board.TryPlaceSide(0, side);
            
            Assert.True(canPlaceCorrect);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.TryPlaceSideCases))]
        public void TryPlaceSide_OutOfBoundsPositive_ReturnsFalse(GameSide side)
        {
            var positiveNumResult = _board.TryPlaceSide(_width * _width, side);

            Assert.False(positiveNumResult);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.TryPlaceSideCases))]
        public void TryPlaceSide_OutOfBoundsNegative_ReturnsFalse(GameSide side)
        {
            var negativeNumResult = _board.TryPlaceSide(-1, side);
            
            Assert.False(negativeNumResult);
        }
        
        [Test]
        public void TryPlaceSide_Indeterminate_ReturnsFalse()
        {
            var result = _board.TryPlaceSide(0, GameSide.Indeterminate);
            
            Assert.False(result);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.TryPlaceSideCases))]
        public void Reset_CanPlaceAgain_ReturnsTrue(GameSide side)
        {
            _board.TryPlaceSide(0, GameSide.Circle);
            _board.Reset();
            
            var canBePlacedAgain = _board.TryPlaceSide(0, GameSide.Circle);
            
            Assert.True(canBePlacedAgain);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.TryPlaceSideCases))]
        public void TileUpdated_RaisesCorrectly_ReturnsTrue(GameSide side)
        {
            var correctIndex = false;
            var correctSide = false;
            
            _board.TileUpdated += (i, gameSide) =>
            {
                correctIndex= i == 0;
                correctSide = gameSide == side;
            };
            
            _board.TryPlaceSide(0, side);
            
            Assert.True(correctIndex);
            Assert.True(correctSide);
        }
        
        [TestCaseSource(typeof(BoardTestsData), nameof(BoardTestsData.FinishedWinCases))]
        public void Finished_RaisesCorrectlyForWin_ReturnsTrue(int first, int second, int third)
        {
            var correctResult = false;
            _board.Finished += (res, gameSide) =>
            {
                correctResult = res == BoardResult.GameWon;
            };

            _board.TryPlaceSide(first, GameSide.Circle);
            _board.TryPlaceSide(second, GameSide.Circle);
            _board.TryPlaceSide(third, GameSide.Circle);
            
            Assert.True(correctResult);
        }
        
        [Test]
        public void Finished_RaisesCorrectlyForTie_ReturnsTrue()
        {
            var correctResult = false;

            _board.Finished += (res, gameSide) =>
            {
                correctResult = res == BoardResult.Tie;
            };

            _board.TryPlaceSide(0, GameSide.Circle);
            _board.TryPlaceSide(1, GameSide.Circle);
            _board.TryPlaceSide(2, GameSide.Cross);
            _board.TryPlaceSide(3, GameSide.Cross);
            _board.TryPlaceSide(4, GameSide.Cross);
            _board.TryPlaceSide(5, GameSide.Circle);
            _board.TryPlaceSide(6, GameSide.Circle);
            _board.TryPlaceSide(7, GameSide.Cross);
            _board.TryPlaceSide(8, GameSide.Circle);
            
            Assert.True(correctResult);
        }
    }
}
