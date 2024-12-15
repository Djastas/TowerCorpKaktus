using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Corp_Kaktus.Scripts
{
    public class Character : MonoBehaviour
    {
        protected NavMeshAgent _agent;
        
        
        [SerializeField] private float randomPointDistance;
        [SerializeField] private float findPointDistance;
        protected float positionThreshold;
        
        [SerializeField] private bool debug;
        
        protected virtual  void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        private void OnDrawGizmos()
        {
            if (!debug) { return; }
            
            Gizmos.color = new Color(0.46f, 0.79f, 0.67f, 0.39f);
            Gizmos.DrawSphere(transform.position , randomPointDistance);
            Gizmos.color = new Color(0.49f, 0.79f, 0.1f, 0.39f);

            Gizmos.DrawSphere(transform.position , randomPointDistance + findPointDistance);
          
            if (_agent )
            {
                Gizmos.color = new Color(0.79f, 0.25f, 0.31f, 0.8f);
                Gizmos.DrawSphere(_agent.destination, 0.5f);
            }
           
        }
        public void SetRandomPoint()
        {
            //Find Random Position within a sphere
            var randomPosition = UnityEngine.Random.insideUnitSphere * randomPointDistance;
            //Add this with the agent position to get random position with agent position as origin
            var randomPos = transform.position + randomPosition;

            NavMesh.SamplePosition(randomPos, out var hit, findPointDistance, NavMesh.AllAreas);
            _agent.destination = hit.position;
        }
    }
}
