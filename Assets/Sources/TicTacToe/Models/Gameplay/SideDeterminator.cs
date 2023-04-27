namespace TicTacToe.Models.Gameplay
{
    public class SideDeterminator : ISideDeterminator
    {
        private readonly GameSide _startSide;
        private GameSide _side;

        private bool _firstTimeChosen;

        public SideDeterminator(GameSide startSide)
        {
            _startSide = startSide;
            _side = _startSide;
        }

        public GameSide Determine()
        {
            if (!_firstTimeChosen)
            {
                _firstTimeChosen = true;
                return _side;
            }

            var changedSide = _side == GameSide.Cross ? GameSide.Circle : GameSide.Cross;
            return _side = changedSide;
        }

        public void Reset()
        {
            _side = _startSide;
            _firstTimeChosen = false;
        }
    }
}