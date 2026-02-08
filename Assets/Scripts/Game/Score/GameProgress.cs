using System;
using UnityEngine;

namespace Game.Score
{
    public class GameProgress
    {
        public event Action OnScoreChanged;
        public event Action OnMoved;

        public void LoadLevelConfig(int goalScore, int moves)
        {
            Score = 0;
            GoalScore = goalScore;
            Moves = moves;
        }

        public int Score { get; private set; }
        public int GoalScore { get; private set; }
        public int Moves { get; private set; }

        public void AddScore(int value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than 0");

            Score += value;
            OnScoreChanged?.Invoke();
        }

        public bool IsGameFinished() => Score >= GoalScore;

        public void SpendMoves()
        {
            Moves--;
            OnMoved?.Invoke();

            Debug.Log(Moves + " moves left");
        }
    }
}