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
            => _view.UpdateTileText(index, side.ConvertToCoolString());
        
        private void OnViewClicked(int index)
            => _model.TryMove(index, side: _sideDeterminator.Determine());
    }
}