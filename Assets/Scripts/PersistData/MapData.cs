using System;
using System.Collections;
using System.Collections.Generic;
using Main;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PersistData
{
    [CreateAssetMenu(fileName = "MapData", menuName = "data/map")]
    public class MapData : SerializedScriptableObject
    {
        public int CurrentFloor;
        public IMapSaveData[][] Floors;
    }
}