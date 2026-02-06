using UnityEngine;

namespace Game.Tiles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        public TileConfig TileConfig { get; private set; }
        public bool IsInteractable { get; private set; }
        public bool IsMatched { get; private set; }

        public void SetTileConfig(TileConfig config)
        {
            TileConfig = config;
            IsInteractable = config.IsInteractable;
            IsMatched = false;
            GetComponent<SpriteRenderer>().sprite = config.Sprite;
        }

        public bool SetMatch(bool value) => IsMatched = value;
    }
}