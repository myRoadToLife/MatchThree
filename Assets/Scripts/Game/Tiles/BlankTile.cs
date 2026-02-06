using System;
using UnityEngine;

namespace Game.Tiles
{
    [Serializable]
    public class BlankTile
    {
        [SerializeField] private int _xPos;
        [SerializeField] private int _yPos;

        public int XPos => _xPos;

        public int YPos => _yPos;
    }
}