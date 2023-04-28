using TicTacToe.Models.Gameplay;
using TicTacToe.Views;

namespace TicTacToe.Presenters
{
    public class BoardPresenter : IManuallyActivated
    {
        private readonly IBoard _model;
        private readonly BoardView _view;
        
        private readonly ISideDeterminator _sideDeterminator;

        public BoardPresenter(IBoard model, BoardView view, ISideDeterminator sideDeterminator)
        {
            _model = model;
            _view = view;
            
            _sideDeterminator = sideDeterminator;
        }

        public void Activate()
        {
            _view.Activate();
            
            _model.TileUpdated += OnTileUpdated;
            _view.TileClicked += OnTileClicked;
        }

        public void Deactivate()
        {
            _view.Deactivate();
            
            _model.TileUpdated -= OnTileUpdated;
            _view.TileClicked -= OnTileClicked;
        }

        private void OnTileUpdated(int index, GameSide side)
            => _view.UpdateTileText(index, side.ConvertToCoolString());
        

        private void OnTileClicked(int index)
            => _model.TryPlaceSide(index, side: _sideDeterminator.Determine());
    }
}