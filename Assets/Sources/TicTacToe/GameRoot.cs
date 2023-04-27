using System;
using TicTacToe.Models.Commands;
using TicTacToe.Models.Gameplay;
using TicTacToe.Presenters;
using TicTacToe.Views;
using TicTacToe.Views.Factory;
using UnityEngine;

namespace TicTacToe
{
    public class GameRoot : MonoBehaviour
    {
        public const int ScoreAmounts = 2;
        
        [Header("Views")]
        [SerializeField] private SidedBoardView _boardView;
        [SerializeField] private TextView[] _scoreViews;
        [SerializeField] private ButtonView _resetButton;
        
        [Header("Views.Factories")]
        [SerializeField] private SidedTileViewFactory _tileViewFactory;
        
        [Header("Start Settings")]
        [SerializeField, Range(3, 4)] private int _boardWidth = 3;
        [SerializeField] private GameSide _startSide = GameSide.Circle;
        
        private IBoard _board;
        private IScoreCounter _scoreCounter;
        private ISideDeterminator _determinator;
        
        private BoardPresenter _boardPresenter;
        private ScorePresenter _scorePresenter;
        private CommandButtonPresenter _resetButtonPresenter;

        private void Awake()
        {
            InitializeBoard();
            InitializeScore();
            InitializeButtons();
        }

        private void InitializeBoard()
        {
            _determinator = new SideDeterminator(_startSide);

            _board = new Board(_boardWidth);
            _boardView.Init(_tileViewFactory, _boardWidth);
            _boardPresenter = new BoardPresenter(_board, _boardView, _determinator);
        }

        private void InitializeScore()
        {
            _scoreCounter = new ScoreCounter(ScoreAmounts);
            _scorePresenter = new ScorePresenter(_scoreCounter, _scoreViews);
        }

        private void InitializeButtons()
        {
            _resetButtonPresenter = new CommandButtonPresenter(new RestartCommand(_board, _scoreCounter), _resetButton);
        }

        private void OnEnable()
        {
            _boardPresenter.Activate();
            _scorePresenter.Activate();
            _resetButtonPresenter.Activate();
            
            _board.Finished += OnFinished;
        }

        private void OnDisable()
        {
            _boardPresenter.Deactivate();
            _scorePresenter.Deactivate();
            _resetButtonPresenter.Deactivate();
            
            _board.Finished -= OnFinished;
        }
        
        private void OnFinished(BoardResult result, GameSide side)
        {
            switch (result)
            {
                case BoardResult.StillGoing:
                    return;
                case BoardResult.GameWon:
                    _scoreCounter.TryGrantScore((int) side); // TODO AWFUL CONVERSION
                    break;
                case BoardResult.Tie:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, "Board Result is out of range! Something is terribly wrong!");
            }

            _board.Reset();
        }
    }
}