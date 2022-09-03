using System;
using Main;
using Managers;
using PersistData;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine.SceneManagement;


namespace UI
{
    public class StatusUI<T> : Singleton<StatusUI<T>> where T : StatusUI<T>
    {
        public Image HpFill;

        public TMP_Text Hp;
        public TMP_Text Sp;
        public TMP_Text Atk;
        public TMP_Text Piercing;
        public TMP_Text Def;
        public TMP_Text Critical;
        public TMP_Text Dodge;

        public IBattle Fighter;
        



        protected void UpdateStatus(IBattle data)
        {
            Hp.text = data.Status.CurHp.ToString() + "/" + data.Status.MaxHp.ToString();
            Piercing.text = data.Status.Piercing.ToString();
            Def.text = data.Status.Def.ToString();
            Critical.text = data.Status.Critical.ToString();
            Dodge.text = data.Status.Dodge.ToString();


            HpFill.fillAmount = (float) data.Status.CurHp / data.Status.MaxHp;
            Atk.text = data.Status.Atk.ToString();
        }


        protected void Update()
        {
            if (Fighter != null)
            {
                UpdateStatus(Fighter);
            }
        }
    }
}