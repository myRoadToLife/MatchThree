using System;
using System.Collections.Generic;
using Levels;
using UnityEngine;

namespace Menu.Levels
{
    [CreateAssetMenu(fileName = "LevelSequenceConfig", menuName = "Configs/LevelSequenceConfig")]
    public class LevelSequenceConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levelSequence = new();

        public List<LevelConfig> LevelSequence => _levelSequence;

        private void OnValidate()
        {
            if (_levelSequence.Count != 5)
                throw new ArgumentOutOfRangeException(
                    "_levelSequence.Count", "_levelSequence.Count must be 5");
        }
    }
}