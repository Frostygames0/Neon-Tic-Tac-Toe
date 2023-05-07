using System;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class BoardPresenter : IActivatable
    {
        private readonly IBoard _model;
        private readonly ISideDeterminator _sideDeterminator;
        
        private readonly GridClickableTextView _view;

        public BoardPresenter(IBoard model, ISideDeterminator sideDeterminator, GridClickableTextView view)
        {
            _model = model;
            _sideDeterminator = sideDeterminator;

            _view = view;
        }

        public void Activate()
        {
            _model.TileUpdated += OnTileUpdated;
            _view.Clicked += OnViewClicked;
        }

        public void Deactivate()
        {
            _model.TileUpdated -= OnTileUpdated;
            _view.Clicked -= OnViewClicked;
        }

        private void OnTileUpdated(int index, GameSide side)
        {
            var signInText = side switch
            {
                GameSide.Circle => "O",
                GameSide.Cross => "X",
                GameSide.Indeterminate => "",
                _ => throw new ArgumentOutOfRangeException(nameof(side), side, "Side is out of range! This should not happen, unless someone update Enum")
            };
            
            _view.UpdateTileText(index, signInText);
        }

        private void OnViewClicked(int index)
            => _model.TryMove(index, side: _sideDeterminator.Determine());
    }
}