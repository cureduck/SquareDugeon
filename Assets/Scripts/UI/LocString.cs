using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LocString : MonoBehaviour
    {
        private TMP_Text _text;
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.text = TranslateManager.Instance[name];
        }
    }
}