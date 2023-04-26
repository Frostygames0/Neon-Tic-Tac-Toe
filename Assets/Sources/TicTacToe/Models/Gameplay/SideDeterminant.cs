namespace TicTacToe.Models.Gameplay
{
    public class SideDeterminant : ISideDeterminator
    {
        private GameSide _side;

        private bool _firstTimeChosen;

        public SideDeterminant(GameSide startSide)
            => _side = startSide;

        public GameSide Determine()
        {
            if (!_firstTimeChosen)
            {
                _firstTimeChosen = true;
                return _side;
            }

            var changedSide = _side == GameSide.X ? GameSide.O : GameSide.X;
            return _side = changedSide;
        }
    }
}