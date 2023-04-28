using TicTacToe.Models.Gameplay;
using TicTacToe.Views;
using TMPro;

namespace TicTacToe.Presenters
{
    public class ScorePresenter : IManuallyActivated
    {
        private readonly IScoreCounter _model;
        private readonly TMP_Text[] _views;

        private readonly IBoard _board;
        
        public ScorePresenter(IScoreCounter model, params TMP_Text[] views)
        {
            _model = model;
            _views = views;
        }
        
        public void Activate()
            => _model.ScoreUpdated += OnScoreUpdated;

        public void Deactivate()
            => _model.ScoreUpdated -= OnScoreUpdated;
        
        private void OnScoreUpdated(int side, int score)
            => _views[side].SetText(score.ToString());
    }
}