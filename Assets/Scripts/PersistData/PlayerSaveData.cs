using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

namespace PersistData
{
    public class PlayerSaveData : JsonSaveData
    {
        public string SavePath => Application.persistentDataPath + "/1.dat";

        
        public int aa;
        public int bb;
        public int[] cc;
        
        

        public Dictionary<string, string> dd;
        
        [Button]
        public void Load()
        {
            Debug.Log(SavePath);
            var t = Load<PlayerSaveData>(SavePath);
            Debug.Log(JsonConvert.SerializeObject(t));
        }

    }
}