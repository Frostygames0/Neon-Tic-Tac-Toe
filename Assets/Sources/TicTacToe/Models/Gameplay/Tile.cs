using System;

namespace TicTacToe.Models.Gameplay
{
    public class Tile : ITile
    {
        private readonly int _index;
        
        public GameSide Side { get; private set; } = GameSide.Indeterminate;
        
        public event Action<int, GameSide> SideChanged;

        public Tile(int index)
            => _index = index;

        public bool TryPlace(GameSide side)
        {
            if (Side != GameSide.Indeterminate)
                return false;
            
            ChangeSideAndNotify(side);
            return true;
        }

        public void Reset()
            => ChangeSideAndNotify(GameSide.Indeterminate);

        private void ChangeSideAndNotify(GameSide side)
        {
            Side = side;
            SideChanged?.Invoke(_index, Side);
        }
    }
}