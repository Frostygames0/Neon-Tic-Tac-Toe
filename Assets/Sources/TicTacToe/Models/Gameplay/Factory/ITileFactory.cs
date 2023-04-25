namespace TicTacToe.Models.Gameplay.Factory
{
    public interface ITileFactory
    {
        ITile Create(int index);
    }
}