using System;
using System.Collections.Generic;
using System.Linq;
using Main;
using Managers;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace PersistData
{
    
    [CreateAssetMenu(menuName = "Data", fileName = "PlayerData")]
    public class PlayerData : SerializedScriptableObject, IBattle
    {
        public event Action StatusUpdated;

        public PlayerSaveData PlayerSaveData;
        
        public Status status;
        public Status Status
        {
            get => status;
            set => status = value;
        }

        public Skills Skills;
        
        public void Damaged(Attack attack)
        {
            var d1 = math.max(attack.PAtk - status.Def, 0);
            status.CurHp -= d1;
        }

        public Attack Attack()
        {
            return new Attack
            {
                PAtk = status.Atk,
                CAtk = 0
            };
        }


        public bool SkillFull => Skills.All(svd => svd.IsEmpty());

        public bool EquipSkill(SkillSaveData skill)
        {
            for (var i = 0; i < Skills.Count; i++)
            {
                if (!Skills[i].IsEmpty()) continue;
                Skills[i] = skill;
                Skills[i].OnEquip();
                StatusUpdated?.Invoke();
                return true;
            }
            return false;
        }
    }
}