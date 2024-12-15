using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Corp_Kaktus.Scripts.WorldInteract
{
    public class PlayerInteractController : MonoBehaviour
    {
        [SerializeField] private List<Sprite> cursorsSprites;
        [SerializeField] private List<string> cursorsIDs;
        
        [SerializeField] private string standardCursor;
        

        [SerializeField] private Image cursorImage;
        
        [SerializeField] private bool debug;
        [SerializeField] private float lenght;
        [SerializeField] private LayerMask mask;
        
        [SerializeField] private PlayerInput playerInput;

        private void Start()
        {
            playerInput.actions.FindAction("WorldInteract").performed += Test;
        }

        public  void Test(InputAction.CallbackContext callbackContext)
        {
            CheckInteract(true); 
        }
        

        void Update()
        {
            CheckInteract();
        }
        
        private GameObject _lastInteractObject;

        private void CheckInteract(bool isInteract = false)
        {
            
            try
            {
               
                Physics.queriesHitTriggers = false;
                var ray = Physics.Raycast(transform.position, transform.forward, out var hit,lenght);

                if (!ray) return;
                

                /*
                if (_lastInteractObject)
                {
                    if (_lastInteractObject != hit.collider.gameObject)
                    {
                        if (_lastInteractObject.TryGetComponent(out InteractComponent interactComponentLast))
                        {
                            interactComponentLast.Select(true);
                        }
                    }
                   

                }

                _lastInteractObject = hit.collider.gameObject;
                */

                if (!hit.collider.TryGetComponent(out InteractComponent interactComponent))
                {
                    SetCursor(standardCursor);
                    return;
                }


                if (isInteract  )
                {
                    if (interactComponent)
                    {
                       
                            interactComponent.Interact();
                      
                     
                    }
                  
                }
                else
                {
                    interactComponent.Select(false);
                }

                SetCursor(interactComponent.cursorId);
            }
            catch (Exception e)
            {
                Debug.LogError(";plhgmkdf[pofmh[otihj");
            }
        }

        private void OnDrawGizmos()
        {
            if (!debug){return;}
            Gizmos.DrawRay(transform.position, transform.forward * 10f);
        }

        private void SetCursor(string cursorId)
        {
            try
            {
                var cursor = cursorsSprites[cursorsIDs.FindIndex(t => t == cursorId)];
                cursorImage.sprite = cursor;
            }
            catch (Exception _)
            {
                Debug.LogError($"Cant find cursor {cursorId}");
            }
            
        }
    }
    
}



