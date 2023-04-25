namespace TicTacToe.Models.Gameplay
{
    public class WinningCombinationsDetector : IWinningCombinationsDetector
    {
        public TileSide DetectWinningSide(ITile[] tiles)
        {
            return TileSide.Indeterminate;
        }
    }
}