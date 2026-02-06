using UnityEngine;

namespace Game.Tiles
{
    public enum TileType
    {
        Normal,
        Blank,
        Jelly,
    }

    [CreateAssetMenu(fileName = "Tile Config", menuName = "Configs/Tile Config")]
    public class TileConfig : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private TileType _tileType;
        [SerializeField] private bool _isInteractable;

        public Sprite Sprite => _sprite;
        public TileType TileType => _tileType;
        public bool IsInteractable => _isInteractable;
    }
}