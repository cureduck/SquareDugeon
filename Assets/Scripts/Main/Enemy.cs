using Managers;
using PersistData;
using UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


namespace Main
{
    public class Enemy : ReactElement<EnemySaveData>, IBattle
    {

        public override void OnFocus()
        {
            EnemyStatusUI.Instance.Fighter = this;
            EnemyStatusUI.Instance.GetComponent<Toggle>().isOn = true;
        }

        protected override void SetLocalScale()
        {
            transform.localScale = new Vector3(Save.BluePrint.Height, Save.BluePrint.Width);
        }
        


        private void Die()
        {
            Destroy(gameObject);
        }

        public Status Status
        {
            get
            {
                var bp = Save.BluePrint;
                return new Status
                {
                    MaxHp = bp.Hp,
                    CurHp = Save.CurHp,
                    
                    Atk = bp.Atk,
                    Piercing = bp.Piercing,
                    Def = bp.Def,
                    
                    Critical = bp.Critical,
                    Dodge = bp.Dodge
                };
            }
        }

        public void Damaged(Attack attack)
        {
            var blue = Save.BluePrint;
            var d1 = math.max(attack.PAtk - blue.Def, 0);
            Save.CurHp -= d1;
            if (Save.CurHp <= 0)
            {
                Die();
            }
        }

        public Attack Attack()
        {
            return new Attack
            {
                PAtk = Save.BluePrint.Atk,
                MAtk = 0,
                CAtk = 0
            };
        }
    }
}