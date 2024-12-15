using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tower.Runtime.Core.Phone
{
    public class PhoneStateController : MonoBehaviour
    {
        public bool phoneIsOpen;
        
        [SerializeField] private Animator phoneStateAnimator;
        [SerializeField] private string stateAnimatorName;
        
        [SerializeField] private PlayerInput playerInput;

        private void Start()
        {
            
            playerInput.actions.FindAction("PhoneInteract").started += _ => { SwitchPhoneState(); };
        }

        [ContextMenu("Switch state")]
        public void SwitchPhoneState()
        {
            phoneIsOpen = !phoneIsOpen;
            phoneStateAnimator.SetBool(stateAnimatorName, phoneIsOpen);
            Cursor.lockState = phoneIsOpen ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}