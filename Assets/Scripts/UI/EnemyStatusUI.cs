using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace UI
{
    public class EnemyStatusUI : StatusUI<EnemyStatusUI>
    {
        public Button AttackBtn;
        public Toggle isOn;
        
        private void Start()
        {
            isOn = GetComponent<Toggle>();
        }

        protected new void Update()
        {
            if (!isOn.isOn) return;
            base.Update();
            if (Fighter != null)
            {
                AttackBtn.interactable = Fighter.Status.CurHp > 0;
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(AttackBtn.interactable);
                }
            }
        }
    }
}