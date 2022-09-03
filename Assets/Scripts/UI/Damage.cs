using TMPro;
using UnityEngine;

namespace UI
{
    public class Damage : MonoBehaviour
    {
        private TMP_Text _text;

        public int PD;
        public int MD;

        void Start()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = "<color=red>"+ PD+"</color>  <color=blue>"+MD+"</color>";
        }
    }
}
