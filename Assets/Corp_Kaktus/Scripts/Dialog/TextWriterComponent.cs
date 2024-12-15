using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Component
{
    public class TextWriterComponent : MonoBehaviour
    {
        // todo change to new class in every scene
        
        [SerializeField] private float waitBetweenCharts;
        [SerializeField] private TMP_Text text;
        [SerializeField] private bool er;
        public string massage;
        [Multiline] [TextArea(3,10)]public string massageER;
        [SerializeField] private bool loadTextOnAwake;
        [SerializeField] private string id;
        [SerializeField] private bool startWriteOnStart = true;
        [SerializeField] private bool isdf;
        [SerializeField] private int _lineCount = 999999999;

        // [SerializeField] private List<AudioClip> audioClips;
        private AudioSource audioSource;
        private Coroutine _currentCoroutine;
        private string _finishText;

        private void Awake()
        {
            FilterText();
            audioSource = GetComponent<AudioSource>();
            if (!loadTextOnAwake) return;
            massage = PlayerPrefs.GetString(id);
            FilterText();

        }

        private void FilterText()
        {
            _finishText = !er
                ? massage.Replace("\n",
                    Environment.NewLine)
                : massageER.Replace("\n",
                    Environment.NewLine);
        }

        public void OnEnable()
        {
            if (startWriteOnStart)
            {
                if (_currentCoroutine == null)
                {
                    _currentCoroutine = StartCoroutine(Writing());
                    FilterText();
                }
            }
        }
    


public void StartWriting()
        {if (_currentCoroutine == null)
            {
                _currentCoroutine = StartCoroutine(Writing());
                FilterText();
            }
        }

        IEnumerator Writing()
        {
            FilterText();
            text.text = "";
            var t = "";
            foreach (var t1 in _finishText)
            {
                if (text.textInfo.lineCount >= _lineCount && isdf)
                {
                    text.text = text.text.Remove(0,text.textInfo.lineInfo[0].characterCount);
                    t = text.text;
                }
                
                    // audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
                // audioSource.Play();
                t += t1;
                text.text = t;
                yield return new WaitForSeconds(waitBetweenCharts);
            }
            
        }
        
        
    }
}
