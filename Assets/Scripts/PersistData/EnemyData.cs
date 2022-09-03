using Sirenix.OdinInspector;
using UnityEngine;

namespace PersistData
{
    [CreateAssetMenu(fileName = "enemy", menuName = "data/enemy")]
    public class EnemyData : SerializedScriptableObject
    {
        public Texture Icon;
        public string Id;

        public int Width;
        public int Height;
        
        public int Hp;
        public int Atk;
        public int Def;

        public int Dodge;
        public int Critical;
        public int Piercing;
    }
}