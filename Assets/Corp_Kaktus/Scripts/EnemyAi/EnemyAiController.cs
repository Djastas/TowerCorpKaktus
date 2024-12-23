using System;
using System.Collections.Generic;
using Corp_Kaktus.Scripts.Utils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Corp_Kaktus.Scripts.EnemyAi
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CheckVisibility))]
    public class EnemyAiController : MonoBehaviour
    {
        [Header("Draw")] 
        [SerializeField] private List<Transform> drawSpawns;
        [SerializeField] private GameObject drawPrefab;
        [SerializeField] private List<CheckVisibility> createdDraws;

        [Header("Navigation")]
        public NavMeshAgent navigation; // todo
        public float targetCollisionThreshold = 1f;
        
        [Header("Debug")]
        public Transform drawSpawnTemp;
        
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();

            var checkVisibilityComponent = GetComponent<CheckVisibility>();
            SubscribeCheckVisibility(checkVisibilityComponent);
            
            foreach (var checkVisibility in createdDraws)
            {
                SubscribeCheckVisibility(checkVisibility);
            }
        }

        public void SetRandomDrawPosition() => drawSpawnTemp = drawSpawns[Random.Range(0, drawSpawns.Count)];
        public void CreateDraw()
        {
            Instantiate(drawPrefab, drawSpawnTemp);
            try
            {
                SubscribeCheckVisibility(drawPrefab.GetComponent<CheckVisibility>());
            }
            catch (Exception e)
            {
                Debug.LogError("CheckVisibility not contains in drawPrefab");
                Debug.LogError(e);
                throw;
            }
            
            drawSpawns.Remove(drawSpawnTemp);
            Debug.Log("CreateDraw");
        }

        private void SubscribeCheckVisibility(CheckVisibility checkVisibilityComponent)
        {
            checkVisibilityComponent.onStartSeeTransform.AddListener(OnSeePlayer);
            checkVisibilityComponent.onEndSeeTransform.AddListener(OnEndSeePlayer);
        }


        [HideInInspector] public UnityEvent<Transform> onSeePlayer;
        [HideInInspector] public UnityEvent<Transform> onEndSeePlayer;

        private static readonly int StartWalkToPlayer = Animator.StringToHash("StartWalkToPlayer");

        public Transform lastPlayer;
        private void OnSeePlayer(Transform player)
        {
            animator.SetTrigger(StartWalkToPlayer);
            lastPlayer = player;
            onSeePlayer?.Invoke(player);
        }
        private void OnEndSeePlayer(Transform player)
        {
            onEndSeePlayer.Invoke(player);
        }
    }
}