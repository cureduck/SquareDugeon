using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public abstract class ReactElement<T> : SerializedMonoBehaviour, IReact where T: IMapSaveData
    {
        public T Save;
        
        public virtual void Start()
        {
            transform.position = Save.Coord;
            SetLocalScale();
        }

        public abstract void OnFocus();
        
        public IMapSaveData GetData()
        {
            return Save;
        }

        protected abstract void SetLocalScale();
    }
}
