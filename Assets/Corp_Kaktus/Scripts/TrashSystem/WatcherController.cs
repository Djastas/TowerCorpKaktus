using UnityEngine;

namespace Corp_Kaktus.Scripts.TrashSystem
{
    public class WatcherController : Character
    {
        public Vector3 lastViewPlayerPosition;
        
        protected override void Start()
        {
            base.Start();
            SetRandomPoint();
        }

        private void Update()
        {
            if (lastViewPlayerPosition != Vector3.zero)
            {
                _agent.destination = lastViewPlayerPosition;
                lastViewPlayerPosition = Vector3.zero;
            }
            if ((transform.position - _agent.destination).magnitude <= positionThreshold)
            {
                SetRandomPoint();
            }
        }

     

        
    }
}