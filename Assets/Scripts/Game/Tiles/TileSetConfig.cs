using System.Collections.Generic;
using UnityEngine;

namespace Game.Tiles
{
    [CreateAssetMenu(fileName = "TileSetConfigs", menuName = "Configs/TileSetConfig")]
    public class TileSetConfig : ScriptableObject
    {
        [SerializeField] private List<TileConfig> _set = new();

        public List<TileConfig> Set => _set;
    }
}