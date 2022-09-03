using PersistData;
using UnityEngine;

namespace Main
{
    public struct EnemySaveData : IMapSaveData
    {
        public int CurHp;
        public EnemyData BluePrint;
        public Vector2 coord;
        public Vector2 Coord => coord;
    }
}