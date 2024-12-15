using System;
using Corp_Kaktus.Scripts.Utils;
using UnityEngine;

namespace Corp_Kaktus.Scripts.TrashSystem
{
    [RequireComponent(typeof(CheckVisibility))]
    public class EyeController : MonoBehaviour
    {
        public WatcherController watcher;
        
        private CheckVisibility _checkVisibility;
        private void Start()
        {
            _checkVisibility = GetComponent<CheckVisibility>();
            _checkVisibility.onStartSee.AddListener(OnStartSee);
            _checkVisibility.onEndSee.AddListener(OnEndSee);
        }
        private void OnStartSee(Vector3 pos)
        {
            watcher.lastViewPlayerPosition = pos;
        }
        private void OnEndSee(Vector3 pos)
        {
            watcher.lastViewPlayerPosition = pos;
        }
    }
}
