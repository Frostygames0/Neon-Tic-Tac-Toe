namespace TicTacToe.Models.Gameplay
{
    public class SideDeterminant : ISideDeterminator
    {
        private TileSide _side;

        private bool _firstTimeChosen;

        public SideDeterminant(TileSide startSide)
            => _side = startSide;

        public TileSide Determine()
        {
            if (!_firstTimeChosen)
            {
                _firstTimeChosen = true;
                return _side;
            }

            var changedSide = _side == TileSide.X ? TileSide.O : TileSide.X;
            return _side = changedSide;
        }
    }
}