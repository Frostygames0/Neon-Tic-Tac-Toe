using TicTacToe.Models.Gameplay;
using TicTacToe.Models.Gameplay.Factory;
using TicTacToe.Presenters;
using TicTacToe.Views;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe.Root
{
    public class GameRoot : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private BoardView _boardView;
        [SerializeField] private ScoreView _scoreView;
        
        [Header("Views.Factories")]
        [SerializeField] private TileViewFactory _tileViewFactory;
        
        [Header("Start Settings")]
        [SerializeField, Range(3, 4)] private int _boardWidth = 3;
        [SerializeField] private TileSide _startSide = TileSide.O;
        
        private ITileFactory _tileFactory;

        private IBoard _board;
        private IScoreCounter _scoreCounter;
        private ISideDeterminator _determinator;
        
        private BoardPresenter _boardPresenter;
        private ScorePresenter _scorePresenter;

        private void Awake()
        {
            InitializeBoard();
            InitializeScore();
        }

        private void InitializeBoard()
        {
            _determinator = new SideDeterminant(_startSide);
            _tileFactory = new TileFactory();
            
            _board = new Board(_tileFactory, _boardWidth);
            _boardView.Init(_tileViewFactory, _boardWidth);
            _boardPresenter = new BoardPresenter(_board, _boardView, _determinator);
        }

        private void InitializeScore()
        {
            _scoreCounter = new ScoreCounter();
            _scorePresenter = new ScorePresenter(_scoreCounter, _scoreView);
        }

        private void OnEnable()
        {
            _boardPresenter.Activate();
            _scorePresenter.Activate();
            
            _board.Finished += OnFinished;
        }

        private void OnDisable()
        {
            _boardPresenter.Deactivate();
            _scorePresenter.Deactivate();
            
            _board.Finished -= OnFinished;
        }
        
        private void OnFinished(BoardResult result, TileSide side)
        {
            switch (result)
            {
                case BoardResult.GameWon:
                    _scoreCounter.GrantScore(side);
                    _board.Reset();
                    break;
                
                case BoardResult.StillGoing:
                case BoardResult.Tie:
                default:
                    break;
            }
        }
    }
}