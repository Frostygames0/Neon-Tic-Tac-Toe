using TicTacToe.Models.Gameplay;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class ScorePresenter : IManuallyActivated
    {
        private readonly IScoreCounter _model;
        private readonly TextView[] _views;

        private readonly IBoard _board;
        
        public ScorePresenter(IScoreCounter model, params TextView[] views)
        {
            _model = model;
            _views = views;
        }
        
        public void Activate()
            => _model.ScoreUpdated += OnScoreUpdated;

        public void Deactivate()
            => _model.ScoreUpdated -= OnScoreUpdated;
        
        private void OnScoreUpdated(int side, int score)
            => _views[side].ChangeText(score.ToString());
    }
}