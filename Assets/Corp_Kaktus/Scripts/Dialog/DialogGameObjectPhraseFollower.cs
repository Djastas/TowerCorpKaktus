using System.Collections.Generic;
using _main.Scripts.UI.Dialog;
using UnityEngine;

namespace Corp_Kaktus.Scripts.Dialog
{
    [RequireComponent(typeof(DialogController))]
    public class DialogGameObjectPhraseFollower : MonoBehaviour
    {
        [SerializeField] private List<GameObject> gameObjects;
        
        
        private void Start()
        {
            GetComponent<DialogController>().onPhraseIndexChanged.AddListener(OnPhraseChanged);
        }

        private void OnPhraseChanged(int index)
        {
            foreach (var go in gameObjects)
            {
                go.SetActive(false);
            }

            if (gameObjects.Count > index)
            {
                gameObjects[index].SetActive(true);
            }
           
        }
        
        
    }
}