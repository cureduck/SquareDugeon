#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using PersistData;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    public class EnemyTable
    {
        [TableList(IsReadOnly = true, AlwaysExpanded = true), ShowInInspector]
        private readonly List<EnemyWrapper> allEnemies;

        public EnemyData this[int index] => allEnemies[index].EnemyData;

        public EnemyTable(IEnumerable<EnemyData> enemies)
        {
            this.allEnemies = enemies.Select(x => new EnemyWrapper(x)).ToList();
        }
        
        private class EnemyWrapper
        {
            public EnemyData EnemyData { get; }

            public EnemyWrapper(EnemyData data)
            {
                this.EnemyData = data;
            }
            
            [TableColumnWidth(50, false)]
            [ShowInInspector, PreviewField(45, ObjectFieldAlignment.Center)]
            public Texture Icon { get { return this.EnemyData.Icon; } set { this.EnemyData.Icon = value; EditorUtility.SetDirty(this.EnemyData); } }
            
        }
    }
}

#endif