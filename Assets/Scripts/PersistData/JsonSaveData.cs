using System;
using System.IO;
using Main;
using Sirenix.OdinInspector;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace PersistData
{
    [Serializable]
    public abstract class JsonSaveData
    {
        protected void Save(string path)
        {
            var f = JsonUtility.ToJson(this);
            File.WriteAllText(path, f);
            Debug.Log(f);
        }

        
        protected static T Load<T>(string path) where T: JsonSaveData
        {
            var f = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(f);
        }
    }
}