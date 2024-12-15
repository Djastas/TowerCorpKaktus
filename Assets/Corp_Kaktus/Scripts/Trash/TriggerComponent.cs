using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.Scripts.Trash
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField] private string tagCheck;
        public UnityEvent onTriggerEnterEvent;
        public void OnTriggerEnter(Collider other)
        {
            if (tagCheck == "" || other.CompareTag(tagCheck))
              onTriggerEnterEvent?.Invoke();
        }
        
        public UnityEvent onTriggerExitEvent;
        public void OnTriggerExit(Collider other)
        {
            if ( tagCheck == "" || other.CompareTag(tagCheck))
               onTriggerExitEvent?.Invoke();
        }
    }
}