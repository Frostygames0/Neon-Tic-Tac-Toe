using System;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;
using TMPro;

namespace TicTacToe.Presenters
{
    public class ScorePresenter : IActivatable
    {
        private readonly IScoreCounter _model;
        private readonly TMP_Text[] _views;

        private readonly IBoard _board;
        
        public ScorePresenter(IScoreCounter model, TMP_Text[] views)
        {
            _model = model;
            _views = views;
        }
        
        public void Activate()
            => _model.ScoreUpdated += OnScoreUpdated;

        public void Deactivate()
            => _model.ScoreUpdated -= OnScoreUpdated;

        private void OnScoreUpdated(GameSide side, int score)
        {
            if (side == GameSide.Indeterminate)
                throw new InvalidOperationException("Trying to update score for Indeterminate side!");

            int numericSide = (int) side;
            if (numericSide > _views.Length || numericSide < 0)
                throw new InvalidOperationException("Trying to update score for invalid GameSide!");
            
            _views[numericSide].SetText(score.ToString());
        }
    }
}