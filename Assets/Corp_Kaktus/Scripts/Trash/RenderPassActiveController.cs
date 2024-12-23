using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Corp_Kaktus.Scripts.Trash
{
    
    public class RenderPassActiveController : MonoBehaviour
    {
        [SerializeField] private bool active;
        [SerializeField] private List<GameObject> controlObjects;

        private void Switch()
        {
            active = !active;
            UpdateState();
        }

        private void UpdateState()
        {
            foreach (var controlObject in controlObjects)
            {
                controlObject.SetActive(active);
            }
        }

        [MenuItem("Tools/RenderPass/SwitchActive %w")]
        private static void SwitchStatic()
        {
           FindObjectOfType<RenderPassActiveController>().Switch();
        }
    }
}