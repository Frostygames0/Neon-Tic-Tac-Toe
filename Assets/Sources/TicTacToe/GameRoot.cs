using TicTacToe.Models.Gameplay;
using TicTacToe.Presenters;
using TicTacToe.Shared;
using TicTacToe.Views;
using TicTacToe.Views.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    // TODO Decompose this class, it's too big
    public class GameRoot : MonoBehaviour
    {
        [Header("Gameplay Views")]
        [SerializeField] private GridClickableTextView _gridClickableTextView;
        [SerializeField] private TMP_Text[] _scoreViews;
        
        [Header("UI Views")]
        [SerializeField] private MessageView _messageView;
        [SerializeField] private Button _restartButton;

        [Header("View Factories")] 
        [SerializeField] private ClickableTextViewFactory _clickableTextViewFactory;

        [Header("Start Settings")]
        [SerializeField] private GameSide _startSide = GameSide.Circle;

        private IBoard _board;
        private IScoreCounter _scoreCounter;
        private ISideDeterminator _determinator;

        private BoardPresenter _boardPresenter;
        private ScorePresenter _scorePresenter;

        private SimpleButtonPresenter _restartButtonPresenter;
        private MessagePresenter _messagePresenter;

        private void Awake()
        {
            InitializeBoard();
            InitializeScore();
            InitializeGeneralUI();
        }

        private void InitializeBoard()
        {
            _determinator = new SideDeterminator(_startSide);

            _board = new Board();
            _gridClickableTextView.Init(Board.Width, _clickableTextViewFactory);
            _boardPresenter = new BoardPresenter(_board, _determinator, _gridClickableTextView);
        }

        private void InitializeScore()
        {
            _scoreCounter = new ScoreCounter();
            _scorePresenter = new ScorePresenter(_scoreCounter, _scoreViews);
        }

        private void InitializeGeneralUI()
        {
            _restartButtonPresenter = new SimpleButtonPresenter(_restartButton, Restart);
            _messagePresenter = new MessagePresenter(_messageView);
        }

        private void OnEnable()
        {
            _boardPresenter.Activate();
            _scorePresenter.Activate();
            _restartButtonPresenter.Activate();
            _messagePresenter.Activate();

            _board.Finished += OnFinished;
        }

        private void OnDisable()
        {
            _boardPresenter.Deactivate();
            _scorePresenter.Deactivate();
            _restartButtonPresenter.Deactivate();
            _messagePresenter.Deactivate();

            _board.Finished -= OnFinished;
        }
        
        private void PrepareForNewRound()
        {
            _board.Reset();
            _determinator.Reset();
        }

        private void Restart()
        {
            PrepareForNewRound();
            _scoreCounter.Reset();
        }
        
        private void OnFinished(GameSide side)
        {
            _scoreCounter.TryGrantScore(side);

            var message = side == GameSide.Indeterminate ? "Tie!" : $"{side:G} has won!";
            _messagePresenter.Show(message, PrepareForNewRound);
        }
    }
}