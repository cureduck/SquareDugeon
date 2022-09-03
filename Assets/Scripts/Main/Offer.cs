using PersistData;

namespace Main
{
    public struct Offer
    {
        public OfferKind Kind;
        public Status Modify;
        public SkillSaveData Skill;

        public void TakeOn(PlayerData player)
        {
            player.status += Modify;
            if (!Skill.IsEmpty())
            {
                player.EquipSkill(Skill);
            }
        }
        
        public enum OfferKind
        {
            MaxHp,
            CurHp,
            Atk,
            Def,
            Piercing,
            Skill
        }
    }
}