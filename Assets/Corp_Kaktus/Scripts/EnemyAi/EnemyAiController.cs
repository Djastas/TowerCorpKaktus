using System.Collections.Generic;
using Corp_Kaktus.Scripts.Utils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Corp_Kaktus.Scripts.EnemyAi
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CheckVisibility))]
    public class EnemyAiController : MonoBehaviour
    {
        [Header("Draw")] [SerializeField] private List<Transform> drawSpawns;
        [SerializeField] private GameObject drawPrefab;

        [Header("Navigation")] public NavMeshAgent navigation;
        public float targetCollisionThreshold = 1f;


        private Animator animator;
        public Transform drawSpawnTemp;

        private void Start()
        {
            animator = GetComponent<Animator>();

            var checkVisibilityComponent = GetComponent<CheckVisibility>();
            checkVisibilityComponent.onStartSeeTransform.AddListener(OnSeePlayer);
            checkVisibilityComponent.onEndSeeTransform.AddListener(OnEndSeePlayer);
        }

        public void SetRandomDrawPosition() => drawSpawnTemp = drawSpawns[Random.Range(0, drawSpawns.Count)];
        public void CreateDraw()
        {
            Instantiate(drawPrefab, drawSpawnTemp);
            drawSpawns.Remove(drawSpawnTemp);
            Debug.Log("CreateDraw");
        }


        [HideInInspector] public UnityEvent<Transform> onSeePlayer;
        [HideInInspector] public UnityEvent<Transform> onEndSeePlayer;

        private static readonly int StartWalkToPlayer = Animator.StringToHash("StartWalkToPlayer");

        private void OnSeePlayer(Transform player)
        {
            if (onSeePlayer.GetPersistentEventCount() > 0)
            {
                onSeePlayer.Invoke(player);
            }
            else
            {
                animator.SetTrigger(StartWalkToPlayer);
            }
        }
        private void OnEndSeePlayer(Transform player)
        {
            if (onEndSeePlayer.GetPersistentEventCount() > 0)
            {
                onEndSeePlayer.Invoke(player);
            }
        }
    }
}