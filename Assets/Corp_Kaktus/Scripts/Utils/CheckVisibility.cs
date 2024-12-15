using UnityEngine;
using UnityEngine.Events;

namespace Corp_Kaktus.Scripts.Utils
{
    public class CheckVisibility : MonoBehaviour
    {
        public GameObject checkGameObject;
        public LayerMask layerMask;
        public float maxDistance;
        public bool isCheck = true;
        [Space]
        public UnityEvent<Vector3> onStartSee;
        public UnityEvent<Vector3> onEndSee;
        
        
        public bool CheckResult {get; private set;}

        [SerializeField] private bool debug;
        

        private void Update()
        {
            if (!isCheck)
            {
                return;
            }

            Physics.Raycast(transform.position, checkGameObject.transform.position-transform.position, out var hit,maxDistance, layerMask);
            var result = (hit.collider && hit.collider.gameObject == checkGameObject);

            if (CheckResult == result)
            {
                return;
            }

            (result ? onStartSee : onEndSee)?.Invoke(hit.point);
            CheckResult = result;
        }

        private void OnDrawGizmos()
        {
            if (!debug) { return; }
            
            Gizmos.color = CheckResult ? new Color(0.25f, 0.66f, 0.3f) : new Color(0.66f, 0.23f, 0.2f);
            Gizmos.DrawRay(transform.position , (checkGameObject.transform.position - transform.position).normalized * maxDistance);
        }
    }
}
