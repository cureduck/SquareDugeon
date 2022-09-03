using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace Main
{
    public interface IBattle
    {
        Status Status {get;}
        
        void Damaged(Attack attack);
        Attack Attack();
    }

    
    public struct Status
    {
        public int MaxHp;
        public int CurHp;
        public int Atk;
        public int Def;
        public int Piercing;

        public int Dodge;
        public int Critical;
        
        
        public static Status operator+(Status s1, Status s2)
        {
            return new Status
            {
                Atk = s1.Atk + s2.Atk,
                Critical = s1.Critical + s2.Critical,
                Dodge = s1.Dodge + s2.Dodge,
                CurHp = s1.CurHp + s2.CurHp +s2.MaxHp,
                Def = s1.Def + s2.Def,
                MaxHp = s1.MaxHp + s2.MaxHp,
                Piercing = s1.Piercing + s2.Piercing
            };
        }
    }
}