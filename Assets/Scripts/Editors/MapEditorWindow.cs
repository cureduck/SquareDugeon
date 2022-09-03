#if UNITY_EDITOR

using System.Linq;
using Managers;
using PersistData;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Demos.RPGEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;


namespace Editors
{
    public class MapEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("Tools/Editor/All")]
        private static void Open()
        {
            var window = GetWindow<MapEditorWindow>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 500);
        }
        
        
        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true);
            tree.DefaultMenuStyle.IconSize = 28f;
            tree.Config.DrawSearchToolbar = true;
            
            tree.Add("Add New", new CreateNewEnemy());
            
            EnemyOverView.Instance.UpdateEnemyOverview();
            tree.Add("Enemies", new EnemyTable(EnemyOverView.Instance.AllEnemies));
            tree.AddAllAssetsAtPath("Enemies", "GameData", typeof(EnemyData), true);

            tree.EnumerateTree().AddIcons<EnemyData>(x => x.Icon);
            return tree;
        }
        
        
        public class CreateNewEnemy
        {
            public CreateNewEnemy()
            {
                enemyData = ScriptableObject.CreateInstance<EnemyData>();
                enemyData.Id = "New Enemy Data";
            }
            
            [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
            public EnemyData enemyData;

            [Button("Add New Enemy SO")]
            private void CreateNewData()
            {
                AssetDatabase.CreateAsset(enemyData, "Assets/GameData/" + enemyData.Id+".asset");

                enemyData = ScriptableObject.CreateInstance<EnemyData>();
                enemyData.Id = "NewEnemy";
            }
        }


        protected override void OnBeginDrawEditors()
        {
            //base.OnBeginDrawEditors();
            var selected = MenuTree.Selection.FirstOrDefault();
            var toolbarHeight = MenuTree.Config.SearchToolbarHeight;

            SirenixEditorGUI.BeginHorizontalToolbar(toolbarHeight);
            {
                if (selected != null)
                {
                    GUILayout.Label(selected.Name);
                }

                if (SirenixEditorGUI.ToolbarButton("Delete Current"))
                {
                    var asset = MenuTree.Selection.SelectedValue as EnemyData;
                    var path = AssetDatabase.GetAssetPath(asset);
                    AssetDatabase.DeleteAsset(path);
                    AssetDatabase.SaveAssets();
                }
                
                SirenixEditorGUI.EndHorizontalToolbar();
            }
        }
    }
}

#endif