using System;

namespace TicTacToe.Shared
{
    public enum GameSide
    {
        Cross = 0,
        Circle = 1,
        Indeterminate = -1
    }

    public static class GameSideExtensions
    {
        // TODO Remake too
        public static string ConvertToCoolString(this GameSide side)
        {
            var signInText = "";
            
            switch (side)
            {
                case GameSide.Circle:
                    signInText = "O";
                    break;
                case GameSide.Cross:
                    signInText = "X";
                    break;
                case GameSide.Indeterminate:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, "Side is out of range! This should not happen, unless someone update Enum");
            }

            return signInText;
        }
    }
}