using System;
using System.Collections.Generic;
using UnityEngine;

namespace _main.Scripts.UI.Dialog
{
    [Serializable]
    public class Voice
    {
        public List<CharData> charData;
        public string ignoredCharacters;
    }

    [Serializable]
    public class CharData
    {
        public List<AudioClip> audioClips;
        public string allowedCharacters;
    }
}