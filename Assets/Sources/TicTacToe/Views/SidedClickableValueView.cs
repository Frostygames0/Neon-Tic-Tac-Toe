using System;

namespace TicTacToe.Views
{
    public class SidedClickableValueView : ClickableValueView<GameSide>
    {
        protected override string UpdateValue(GameSide value)
        {
            return value switch
            {
                GameSide.Circle => "O",
                GameSide.Cross => "X",
                GameSide.Indeterminate => "",
                _ => throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Somehow you've managed to go out of range for GameSide, an enum...")
            };
        }
    }
}