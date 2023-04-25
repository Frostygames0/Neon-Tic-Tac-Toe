namespace TicTacToe.Models.Gameplay
{
    public interface IWinningCombinationsDetector
    {
        TileSide DetectWinningSide(ITile[] tiles);
    }
}