using System;
using Main;
using Managers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SkillSlot : SerializedMonoBehaviour
    {
        [ShowInInspector]public int Index => transform.GetSiblingIndex();
        public SkillSaveData Skill
        {
            get
            {
                var skills = GameManager.Instance.GamePlayerData.Skills;
                return Index >= skills.Count ? SkillSaveData.Empty : skills[Index];
            }
        }

        public Image Icon;
        public TMP_Text IdText;

        private void Start()
        {
            LoadSkill();
            GameManager.Instance.StatusUpdated += LoadSkill;
        }

        private void LoadSkill()
        {
            if (!Skill.IsEmpty())
            {
                IdText.text = Skill.Target?.DisplayName;
                Skill.Activate += Activate;
            }
            else
            {
                IdText.text = string.Empty;
            }
        }

        private void Activate()
        {
            Debug.Log("Activated!");
        }
    }
}