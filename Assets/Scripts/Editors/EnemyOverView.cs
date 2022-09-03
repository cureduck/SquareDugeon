using System.Linq;
using PersistData;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    public class EnemyOverView : GlobalConfig<EnemyOverView>
    {
        [ReadOnly] [ListDrawerSettings(Expanded = true)]
        public EnemyData[] AllEnemies;
        
#if UNITY_EDITOR
        [Button(ButtonSizes.Medium), PropertyOrder(-1)]
        public void UpdateEnemyOverview()
        {
            this.AllEnemies = AssetDatabase.FindAssets("t:EnemyData")
                .Select(guid => AssetDatabase.LoadAssetAtPath<EnemyData>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray();
        }

#endif
    }
}