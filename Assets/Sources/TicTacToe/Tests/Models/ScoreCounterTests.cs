using NUnit.Framework;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;

namespace TicTacToe.Tests.Models
{
    public class ScoreCounterTests
    {
        private IScoreCounter _scoreCounter;

        [SetUp]
        public void SetUp()
        {
            _scoreCounter = new ScoreCounter();
        }
        
        [Test]
        public void GrantScore_GrantsScore_ReturnsTrue([ValueSource(typeof(TestsData), nameof(TestsData.GameSideCases))] GameSide side)
        {
            var correctSide = false;
            var scoreRaised = false;
            
            _scoreCounter.ScoreUpdated += (sid, score) =>
            {
                correctSide = sid == side;
                scoreRaised = score > 0;
            };
            
            _scoreCounter.TryGrantScore(side);

            Assert.True(correctSide);
            Assert.True(scoreRaised);
        }
    }
}