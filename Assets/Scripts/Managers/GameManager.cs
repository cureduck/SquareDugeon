using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Main;
using PersistData;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    [ExecuteAlways]
    public class GameManager : Singleton<GameManager>
    {
        public PlayerData StartPlayerData;
        public PlayerData SavePlayerData;
        
        public PlayerData GamePlayerData;

        public MapData OriginMapData;
        public MapData SaveMapData;

        public GameObject map;
        
        
        public event Action StatusUpdated;


        [ShowInInspector, ReadOnly] private Dictionary<string, GameObject> Prefabs;


        protected override void Awake()
        {
            base.Awake();
            Prefabs = new Dictionary<string, GameObject>();
            
            foreach (var go in Resources.LoadAll<GameObject>("Prefabs"))
            {
                Prefabs.Add(go.name, go);
            }

            GamePlayerData.StatusUpdated += () => StatusUpdated?.Invoke();
        }

        public void LoadMap(MapData mapData)
        {
            foreach (Transform child in map.transform)
            {
                Destroy(child.gameObject);
            }
            foreach (var square in mapData.Floors[mapData.CurrentFloor])
            {
                CreateSquare(square);
            }
        }


        [Button]
        public void LoadGame()
        {
            //GamePlayerData = (PlayerData) SavePlayerData.Clone();
            Tools.AutoMapping(SavePlayerData, GamePlayerData);
            
            LoadMap(SaveMapData);
            
            StatusUpdated?.Invoke();
        }
        
        
        [Button]
        public void StartNewGame()
        {
            LoadMap(OriginMapData);
            Tools.AutoMapping(StartPlayerData, GamePlayerData);
            StatusUpdated?.Invoke();
        }
        
        
        [Button]
        public void SaveData()
        {
            //var save = new LinkedList<SaveData>();
            var elements = map.GetComponentsInChildren<IReact>();

            var save = Array.ConvertAll(elements, input => input.GetData());

            /*if (SaveMapData.Floors.Length <= CurrentFloor)
            {
                var temp = new LinkedList<SaveData>[CurrentFloor];
                for (var i = 0; i < SaveMapData.Floors.Length; i++)
                {
                    temp[i] = SaveMapData.Floors[i];
                }

                SaveMapData.Floors = temp;
            }*/
            
            SaveMapData.Floors[SaveMapData.CurrentFloor] = save;

            Tools.AutoMapping(GamePlayerData, SavePlayerData);
        }


        public void LoadSkills()
        {
            
        }
        
        
        

        
        
        
        [Button]
        private void CreateSquare(IMapSaveData saveData)
        {
            switch (saveData)
            {
                case EnemySaveData data:
                {
                    var p = Instantiate(Prefabs["Enemy"], map.transform);
                    p.GetComponent<Enemy>().Save = (EnemySaveData) data;
                    break;
                }
                case ShopSaveData data1:
                {
                    var p = Instantiate(Prefabs["Shop"], map.transform);
                    p.GetComponent<Shop>().Save = (ShopSaveData) data1;
                    break;
                }
                case LevelSaveData data2:
                {
                    var p = Instantiate(Prefabs["Level"], map.transform);
                    p.GetComponent<Level>().Save = (LevelSaveData) data2;
                    break;
                }
            }
        }

        public void GoUpstairs()
        {
            SaveData();
            SaveMapData.CurrentFloor += 1;
            LoadMap(SaveMapData);
        }

        

    }
}