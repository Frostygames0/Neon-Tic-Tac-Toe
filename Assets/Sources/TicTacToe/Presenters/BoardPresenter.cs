using TicTacToe.Models.Gameplay;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class BoardPresenter : IManuallyActivated
    {
        private readonly IBoard _model;
        private readonly IBoardView _view;
        
        private readonly ISideDeterminator _sideDeterminator;

        public BoardPresenter(IBoard model, IBoardView view, ISideDeterminator sideDeterminator)
        {
            _model = model;
            _view = view;
            
            _sideDeterminator = sideDeterminator;
        }

        public void Activate()
        {
            _model.Activate();
            _view.Activate();
            
            _model.TileUpdated += OnTileUpdated;
            _view.TileClicked += OnTileClicked;
        }

        public void Deactivate()
        {
            _model.Deactivate();
            _view.Deactivate();
            
            _model.TileUpdated -= OnTileUpdated;
            _view.TileClicked -= OnTileClicked;
        }

        private void OnTileUpdated(int index, TileSide side)
            => _view.UpdateTileSign(index, side);

        private void OnTileClicked(int index)
            => _model.TryPlaceSide(index, side: _sideDeterminator.Determine());
    }
}