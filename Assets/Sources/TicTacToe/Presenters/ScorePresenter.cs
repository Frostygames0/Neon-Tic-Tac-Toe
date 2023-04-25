using TicTacToe.Models.Gameplay;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class ScorePresenter : IManuallyActivated
    {
        private readonly IScoreCounter _model;
        private readonly IScoreView _view;

        private readonly IBoard _board;
        
        public ScorePresenter(IScoreCounter model, IScoreView view)
        {
            _model = model;
            _view = view;
        }
        
        public void Activate()
            => _model.ScoreUpdated += OnScoreUpdated;

        public void Deactivate()
            => _model.ScoreUpdated -= OnScoreUpdated;
        
        private void OnScoreUpdated(TileSide side, int score)
            => _view.SetScore(side, score);
    }
}