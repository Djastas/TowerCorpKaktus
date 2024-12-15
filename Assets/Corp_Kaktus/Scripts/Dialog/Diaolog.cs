using System;
using System.Collections.Generic;
using UnityEngine;

namespace _main.Scripts.UI.Dialog
{
    [Serializable]
    public class Dialog
    {
        public List<Phrase> phrases;
    }
    
    [Serializable]
    public class Phrase
    {
        [TextArea(4, 10)]
        public string value;
        public float timeBetweenChar = 0.05f;
        public float timeBetweenNextPhrase = 1f;
    }
}