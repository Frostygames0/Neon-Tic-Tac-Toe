using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Models.Gameplay;
using TicTacToe.Shared;

namespace TicTacToe.Tests.Models
{
    public static class TestsData
    {
        public static IEnumerable GameSideCases
        {
            get
            {
                yield return GameSide.Circle;
                yield return GameSide.Cross;
            }
        }

        public static IEnumerable<TestCaseData> WinningCombosCases =>
            Board.WinCombos.Select((tuple, _) => new TestCaseData(tuple.Item1, tuple.Item2, tuple.Item3));
    }
}