using System.Collections;
using NUnit.Framework;

namespace TicTacToe.Tests.Models
{
    public static class BoardTestsData
    {
        public static IEnumerable TryPlaceSideCases
        {
            get
            {
                yield return new TestCaseData(GameSide.Circle).SetName("Circle");
                yield return new TestCaseData(GameSide.Cross).SetName("Cross");
            }
        }

        public static IEnumerable FinishedWinCases
        {
            get
            {
                yield return new TestCaseData(0, 1, 2).SetName("First Row");
                yield return new TestCaseData(3, 4, 5).SetName("Second Row");
                yield return new TestCaseData(6, 7, 8).SetName("Third Row");
                yield return new TestCaseData(0, 3, 6).SetName("First Column");
                yield return new TestCaseData(1, 4, 7).SetName("Second Column");
                yield return new TestCaseData(2, 5, 8).SetName("Third Column");
                yield return new TestCaseData(0, 4, 8).SetName("Left-Up Right-Down Diagonal");
                yield return new TestCaseData(6, 4, 2).SetName("Left-Down Right-Up Diagonal");
            }
        }
    }
}