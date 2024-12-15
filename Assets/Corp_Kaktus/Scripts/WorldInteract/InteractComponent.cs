using System;
using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.Scripts.WorldInteract
{
    public class InteractComponent : MonoBehaviour
    {
        public string cursorId = "standard";
        
        public UnityEvent onSelect;
        public UnityEvent onEndSelect;
        public UnityEvent onInteract;
        
        
        [SerializeField] private bool useHighlight;
        [SerializeField] private int highlightLayer;
        
        private int _tempLayer;

        public void Select(bool end)
        {
            if (end)
            {
                if (useHighlight)
                {
                    SetHighlight(false);
                }
                onEndSelect?.Invoke();
                return;
            }

            if (useHighlight)
            {
                SetHighlight(true);
            }

            onSelect?.Invoke();
        }

        private void SetHighlight(bool highlight)
        {
            if (highlight)
            {
                _tempLayer = gameObject.layer;
                gameObject.layer = highlightLayer;
            }
            else
            {
                gameObject.layer = _tempLayer;
            }
            
        }

        public void Interact()
        {
            onInteract?.Invoke();
        }
    }
}