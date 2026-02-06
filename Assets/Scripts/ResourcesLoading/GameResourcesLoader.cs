using Game.Tiles;
using UnityEngine;

namespace ResourcesLoading
{
    public class GameResourcesLoader : MonoBehaviour
    {
       [SerializeField] private GameObject _tilePrefab;
       [SerializeField] private GameObject _blankTilePrefab;
       [SerializeField] private TileConfig _blankConfig;
       [SerializeField] private TileSetConfig _tileSetConfig;

       public GameObject TilePrefab => _tilePrefab;
       public GameObject BlankTilePrefab => _blankTilePrefab;
       public TileConfig BlankConfig => _blankConfig;
       public TileSetConfig TileSetConfig => _tileSetConfig;
    }
}