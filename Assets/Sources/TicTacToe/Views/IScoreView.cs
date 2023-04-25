using TicTacToe.Models.Gameplay;

namespace TicTacToe.Views
{
    public interface IScoreView
    {
        void SetScore(TileSide side, int score);
    }
}