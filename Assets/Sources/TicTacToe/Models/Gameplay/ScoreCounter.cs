using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Shared;

namespace TicTacToe.Models.Gameplay
{
    public class ScoreCounter : IScoreCounter
    {
        private readonly IDictionary<GameSide, int> _scores;
        
        public event Action<GameSide, int> ScoreUpdated;

        public ScoreCounter()
        {
            _scores = new Dictionary<GameSide, int>();
            
            foreach (GameSide side in Enum.GetValues(typeof(GameSide)))
            {
                if (side == GameSide.Indeterminate)
                    continue;
                
                _scores.Add(side, 0);
            }
        }

        public bool TryGrantScore(GameSide side)
        {
            if (!_scores.ContainsKey(side))
                return false;

            UpdateScoreAndRaise(side, _scores[side] + 1);
            return true;
        }

        public void Reset()
        {
            foreach (var side in _scores.Keys.ToList())
            {
                UpdateScoreAndRaise(side, 0);
            }
        }

        private void UpdateScoreAndRaise(GameSide side, int score)
        {
            _scores[side] = score;
            ScoreUpdated?.Invoke(side, _scores[side]);
        }
    }
}