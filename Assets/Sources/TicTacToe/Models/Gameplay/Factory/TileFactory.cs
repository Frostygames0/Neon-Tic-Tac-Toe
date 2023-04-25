namespace TicTacToe.Models.Gameplay.Factory
{
    public class TileFactory : ITileFactory
    {
        public ITile Create(int index)
        {
            return new Tile(index);
        }
    }
}