namespace TicTacToe.Views
{
    public class SidedTileView : TileView<GameSide>
    {
        protected override string UpdateValue(GameSide value)
        {
            if (value == GameSide.Indeterminate)
                return "";
            
            var convertedSign = value.ToString("G");
            return convertedSign;
        }
    }
}