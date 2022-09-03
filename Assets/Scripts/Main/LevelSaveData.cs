using UnityEngine;

namespace Main
{
    public struct LevelSaveData : IMapSaveData
    {
        public Vector2 coord;
        public Vector2 Coord => coord;

        
    }
}