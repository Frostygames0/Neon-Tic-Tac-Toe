using NUnit.Framework;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;

namespace TicTacToe.Tests.Models
{
    public class SideDeterminatorTests
    {
        private ISideDeterminator _sideDeterminator;

        [SetUp]
        public void SetUp()
        {
            _sideDeterminator = new SideDeterminator(GameSide.Cross);
        }
        
        [Test]
        public void Determine_FirstTimeGivesStartSide_ReturnsTrue()
        {
            var determined = _sideDeterminator.Determine();
            
            Assert.True(determined == GameSide.Cross);
        }
        
        [Test]
        public void Determine_SecondTimeReversesSide_ReturnsTrue()
        {
            _sideDeterminator.Determine();

            var determinedSecond = _sideDeterminator.Determine();
            
            Assert.True(determinedSecond != GameSide.Cross && determinedSecond != GameSide.Indeterminate);
        }
    }
}