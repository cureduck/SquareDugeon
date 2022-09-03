using System;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Main
{
    public class Skill
    {
        public string Id;
        public string DisplayName;
        public string Description;

        public bool Positive;

        public Texture Icon;
        public int Rarity;
        
        public Status Modifier;
        
#if UNITY_EDITOR
        [Button]
        public void Remove()
        {
            SkillManager.Instance.Skills.Remove(Id);
        }
#endif
    }
}