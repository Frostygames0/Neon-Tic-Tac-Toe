using TicTacToe.Models.Gameplay;
using TMPro;
using UnityEngine;

namespace TicTacToe.Views
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text _text;

        private int[] _scores = new int[2];
        
        public void SetScore(GameSide side, int score)
        {
            var previousScore = _text.text;
            var aboba = previousScore.Split(':');

            var numSide = (int) side;
        }
    }
}