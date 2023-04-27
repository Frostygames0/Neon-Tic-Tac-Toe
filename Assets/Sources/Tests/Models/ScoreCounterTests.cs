using NUnit.Framework;
using TicTacToe.Models.Gameplay;

namespace TicTacToe.Tests.Models
{
    [TestFixture(2)]
    public class ScoreCounterTests
    {
        private readonly int _scoreAmounts;
        
        private IScoreCounter _scoreCounter;

        public ScoreCounterTests(int scoreAmounts)
        {
            _scoreAmounts = scoreAmounts;
        }
        
        [SetUp]
        public void SetUp()
        {
            _scoreCounter = new ScoreCounter(_scoreAmounts);
        }
        
        [TestCase(0)]
        public void GrantScore_GrantsScore_ReturnsTrue(int index)
        {
            _scoreCounter.ScoreUpdated += (ind, score) =>
            {
                Assert.True(ind == index);
                Assert.True(score >= 1);
                Assert.Pass();
            };
            
            _scoreCounter.TryGrantScore(index);
            
            Assert.Fail();
        }
        
        [Test]
        public void GrantScore_OutOfBoundsPositive_ReturnsFalse()
        {
            var positiveNumResult = _scoreCounter.TryGrantScore(_scoreAmounts);
            
            Assert.False(positiveNumResult);
        }
        
        [Test]
        public void GrantScore_OutOfBoundsNegative_ReturnsFalse()
        {
            var negativeNumResult = _scoreCounter.TryGrantScore(-1);
            
            Assert.False(negativeNumResult);
        }
    }
}