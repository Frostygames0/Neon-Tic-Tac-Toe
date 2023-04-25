using System;

namespace TicTacToe.Models.Gameplay
{
    public class Tile : ITile
    {
        private readonly int _index;
        
        public TileSide Side { get; private set; } = TileSide.Indeterminate;
        
        public event Action<int, TileSide> SideChanged;

        public Tile(int index)
            => _index = index;

        public bool TryPlaceSign(TileSide side)
        {
            if (Side != TileSide.Indeterminate)
                return false;
            
            ChangeSideAndNotify(side);
            return true;
        }

        public void Reset()
            => ChangeSideAndNotify(TileSide.Indeterminate);

        private void ChangeSideAndNotify(TileSide side)
        {
            Side = side;
            SideChanged?.Invoke(_index, Side);
        }
    }
}