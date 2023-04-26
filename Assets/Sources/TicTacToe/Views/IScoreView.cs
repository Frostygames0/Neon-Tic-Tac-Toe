using TicTacToe.Models.Gameplay;

namespace TicTacToe.Views
{
    public interface IScoreView
    {
        void SetScore(GameSide side, int score);
    }
}