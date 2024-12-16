using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _main.Scripts.UI.Dialog
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private bool startDialogOnStart;
        
        public bool useDataInstance;

        public Dialog dialog;
        public DialogData dialogData;
        

        [Header("UI")]
        [SerializeField] private TMP_Text text;
        [SerializeField] private bool useEnterCounterForMaxCharacter;
        [SerializeField] [Tooltip("0 for disable")] private int maxCharacters;

        [Header("Audio")]
        [SerializeField] private bool useAudioSource;
        [SerializeField]  private AudioSource audioSource;

        [SerializeField]  private bool useRandomPitch;
        [SerializeField]  [Range(0,1)] private float maxRandomPitch;
        
        [Header("Voice settings")]
        [SerializeField]  private VoiceType voiceType;
        private bool ShowRandomVoiceType => voiceType == VoiceType.RandomVoice && useAudioSource;
        
        [SerializeField] private List<char> ignoreChar = new List<char>(){' '};
        [SerializeField] private List<AudioClip> randomSounds;
        
        [SerializeField] private bool useAudioDataInstance;
        private bool ShowAudioInstance => useAudioDataInstance && !ShowRandomVoiceType;
        
        [SerializeField] private Voice voice;
        [SerializeField]  private VoiceData voiceData;

        private Coroutine _currentCoroutine;

         public UnityEvent<int> onPhraseIndexChanged;
         public UnityEvent onEndDialog;
        
        private void Start()
        {
            if (startDialogOnStart) { StartDialog(); }
        }

        
        public void StartDialog()
        {
            if (_currentCoroutine != null) { return; }

            _currentCoroutine = StartCoroutine(Write(useDataInstance ? dialog : dialogData.dialog));
        }
        
        
        public void StopDialog()
        {
            if (_currentCoroutine == null) { return; }

            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
        
        private IEnumerator Write(Dialog writeDialog)
        {
            text.text = "";
            foreach (var phrase in writeDialog.phrases)
            {
                text.text = "";
                onPhraseIndexChanged?.Invoke(writeDialog.phrases.IndexOf(phrase));
                foreach (var character in phrase.value)
                {
                    if (useAudioSource)
                    {
                        audioSource.clip = GetSound(character);
                        if (useRandomPitch)
                        {
                            audioSource.pitch = 1 + Random.Range(-maxRandomPitch, maxRandomPitch);
                        }
                        audioSource.Play();
                    }

                    if (useEnterCounterForMaxCharacter)
                    {
                        var splintedText = text.text.Split('\n');
                        if ( maxCharacters > 0 &&  splintedText.Length >= maxCharacters)
                        {
                           var ind =  text.text.IndexOf('\n');
                           text.text = text.text.Remove(0, ind+1);
                        }
                    }
                    else
                    {
                        if ( maxCharacters > 0 && text.text.Length >= maxCharacters)
                        {
                            text.text = text.text.Remove(0, 1);
                        }
                    }
                  
                    text.text += character;
                    OnDrawCharacter(character);
                    yield return new WaitForSeconds(phrase.timeBetweenChar);
                }
                yield return new WaitForSeconds(phrase.timeBetweenNextPhrase);
                
            }
            onEndDialog?.Invoke();
            
        }

        public virtual void OnDrawCharacter(char character) { } 

        private AudioClip GetSound(char currentChar)
        {
            switch (voiceType)
            {
                case VoiceType.RandomVoice:
                    if (!ignoreChar.Contains(currentChar))
                    {
                       return randomSounds[Random.Range(0, randomSounds.Count)];
                    }
                    break;
                case VoiceType.CharVoice:
                    return GetAudioClipByVoice(currentChar,useAudioDataInstance ? voice : voiceData.voice);
                    
            }

            return null;
        }

        private AudioClip GetAudioClipByVoice(char currentChar,Voice currentVoice)
        {
            if (currentVoice.ignoredCharacters.Contains(currentChar))
            {
                return null;
            } // ignore ignored character

            CharData result = null;
            foreach (var charData in currentVoice.charData.Where(charData => charData.allowedCharacters.Contains(currentChar)))
            {
                result = charData;
            } // find for one charData we need

            if (result == null)
            {
                result = currentVoice.charData[0];
                Debug.LogWarning($"cant find voice for {currentChar}, use default", this);
            }

            return result.audioClips[Random.Range(0, result.audioClips.Count)];
        }

        private void OnValidate()
        {
            if (audioSource == null && useAudioSource)
            {
                audioSource = GetComponent<AudioSource>();
            }
        }
        
        private enum VoiceType
        {
            RandomVoice,
            CharVoice
        }
    }
}