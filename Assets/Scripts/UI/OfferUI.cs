using System;
using Main;
using Managers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OfferUI : MonoBehaviour
    {
        private Offer _offer;

        public Offer Offer
        {
            get => _offer;
            set
            {
                _offer = value;
                Load();
            }
        }
        public Image Icon;
        public TMP_Text Count;
        public TMP_Text DisplayName;
        public TMP_Text Description;
        
        public Sprite[] Icons;
        
        public void Chosen()
        {
            Offer.TakeOn(GameManager.Instance.GamePlayerData);
        }

        private void Start()
        {
            var btn = GetComponent<Button>();
        }

        public void Load()
        {
            Count.enabled = true;
            Description.enabled = false;
            switch (Offer.Kind)
            {
                case Offer.OfferKind.MaxHp:
                    DisplayName.text = "生命";
                    Count.text = Offer.Modify.MaxHp.ToString();
                    break;
                case Offer.OfferKind.CurHp:
                    DisplayName.text = "恢复";
                    Count.text = Offer.Modify.CurHp.ToString();
                    break;
                case Offer.OfferKind.Atk:
                    DisplayName.text = "攻击";
                    Count.text = Offer.Modify.Atk.ToString();
                    break;
                case Offer.OfferKind.Def:
                    DisplayName.text = "防御";
                    Count.text = Offer.Modify.Def.ToString();
                    break;
                case Offer.OfferKind.Piercing:
                    DisplayName.text = "穿刺";
                    Count.text = Offer.Modify.Piercing.ToString();
                    break;
                case Offer.OfferKind.Skill:
                    DisplayName.text = Offer.Skill.Target.DisplayName;
                    Count.enabled = false;
                    Description.enabled = true;
                    Description.text = Offer.Skill.Target.Description;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}