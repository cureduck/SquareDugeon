using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Managers;
using PersistData;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Main
{
    public delegate Attack AttackModifier(Attack attack);
    
    public struct SkillSaveData
    {
        public string Id;
        public Skill Target => SkillManager.Instance.Skills[Id];

        public int CurrentLevel;
        public int Counter1;
        public int Counter2;

        [NonSerialized] private SkillSlot slot;


        public void EnSlot(SkillSlot slot)
        {
            this.slot = slot;
        }


        public static SkillSaveData Empty => new SkillSaveData{Id =  string.Empty};

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Id);
        }


        public void OnEquip()
        {
            foreach (var pi in typeof(SkillSaveData).GetMethods())
            {
                var msg = pi.GetCustomAttribute<SkillEffectAttribute>();
                if ((msg == null)||(msg.id != Target.Id)) continue;

                switch (msg.timing)
                {
                    case Timing.PlayerAttack:
                        var f = (Func<Attack, Attack>) pi.CreateDelegate(typeof(Func<Attack, Attack>), this);
                        BattleManager.Instance.PlayerAttackModifier.AddLast(f);
                        break;
                    case Timing.PlayerImpact:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        public void OnUnEquip()
        {
            foreach (var pi in typeof(SkillSaveData).GetMethods())
            {
                var msg = pi.GetCustomAttribute<SkillEffectAttribute>();
                if ((msg == null)||(msg.id != Target.Id)) continue;

                switch (msg.timing)
                {
                    case Timing.PlayerAttack:
                        

                        //var f = Delegate.CreateDelegate(typeof(Func<Attack, Attack>), pi);

                        var f = (Func<Attack, Attack>) pi.CreateDelegate(typeof(Func<Attack, Attack>), this);
                        BattleManager.Instance.PlayerAttackModifier.Remove(f);
                        break;
                    case Timing.PlayerImpact:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        
        
        
        [SkillEffect("Furious", Timing.PlayerAttack)]
        public Attack Furious(Attack attack)
        {
            GameManager.Instance.GamePlayerData.status.CurHp += 1;
            Activate?.Invoke();
            return attack;
        }

        [ShowInInspector] public event Action Activate;
    }




    public class SkillEffectAttribute : Attribute
    {


        public SkillEffectAttribute(string id, Timing timing)
        {
            this.id = id;
            this.timing = timing;
        }

        public string id;
        public Timing timing;
    }
}