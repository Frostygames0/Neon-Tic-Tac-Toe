using NUnit.Framework;
using TicTacToe.Models.Gameplay;

namespace TicTacToe.Tests.Models
{
    [TestFixture(GameSide.Circle)]
    public class SideDeterminatorTests
    {
        private readonly GameSide _startSide;
        private ISideDeterminator _sideDeterminator;

        public SideDeterminatorTests(GameSide startSide)
        {
            _startSide = startSide;
        }
        
        [SetUp]
        public void SetUp()
        {
            _sideDeterminator = new SideDeterminator(_startSide);
        }
        
        [Test]
        public void Determine_FirstTimeGivesStartSide_ReturnsTrue()
        {
            var determined = _sideDeterminator.Determine();
            
            Assert.True(determined == _startSide);
        }
        
        [Test]
        public void Determine_SecondTimeReversesSide_ReturnsTrue()
        {
            _sideDeterminator.Determine();

            var determinedSecond = _sideDeterminator.Determine();
            
            Assert.True(determinedSecond != _startSide && determinedSecond != GameSide.Indeterminate);
        }
    }
}