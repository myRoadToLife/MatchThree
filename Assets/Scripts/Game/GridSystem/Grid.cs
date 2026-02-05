using Game.Tiles;
using UnityEngine;

namespace Game.GridSystem
{
    public class Grid
    {
        public Tile[,] GameGrid { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Vector2Int CurrentPosition { get; private set; }
        public Vector2Int TargetPosition { get; private set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            GameGrid = new Tile[width, height];
        }

        public Vector2Int SetCurrentPosition(Vector2Int value) => CurrentPosition = value;
        public Vector2Int SetTargetPosition(Vector2Int value) => TargetPosition = value;

        public Vector3 GridToWorld(int x, int y) => new Vector3(x, y, 0);

        public Vector2Int WorldToGreed(Vector3 worldPosition)
        {
            var x = Mathf.FloorToInt(worldPosition.x);
            var y = Mathf.FloorToInt(worldPosition.y);
            return new Vector2Int(x, y);
        }

        public void SetValue(int x, int y, Tile tile)
        {
            if (IsValidPosition(x, y))
                GameGrid[x, y] = tile;
        }

        public void SetValue(Vector3 worldPosition, Tile tile)
        {
            var worldToGreed = WorldToGreed(worldPosition);
            SetValue(worldToGreed.x, worldToGreed.y, tile);
        }

        public Tile GetValue(int x, int y) => IsValidPosition(y, x) ? GameGrid[x, y] : null;

        public Tile GetValue(Vector3 worldPosition)
        {
            var worldToGreed = WorldToGreed(worldPosition);
            return GetValue(worldToGreed.x, worldToGreed.y);
        }

        public bool IsValidPosition(int x, int y) => x >= 0 && x < Width && y >= 0 && y < Height;
    }
}