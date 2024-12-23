using UnityEngine;

namespace Corp_Kaktus.Scripts.EnemyAi.States
{
    public class WalkToPlayerState : EnemyBaseState
    {
        [SerializeField] private float playerLostTime = 5f;
        
        private static readonly int EndWalkToPlayer = Animator.StringToHash("EndWalkToPlayer");
        
        [SerializeField] private float playerLostTimer;
        [SerializeField] private Transform player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Context = animator.GetComponent<EnemyAiController>();
            player = Context.lastPlayer;
            playerLostTimer = playerLostTime;
            Context.onSeePlayer.AddListener(OnStartSeePlayer);
            Context.onEndSeePlayer.AddListener(OnEndSeePlayer);
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = null;
            Context.onSeePlayer.RemoveListener(OnStartSeePlayer);
            Context.onEndSeePlayer.RemoveListener(OnEndSeePlayer);
        }
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (playerLostTimer <= 0)
            {
                animator.SetTrigger(EndWalkToPlayer);
                return;
            }

            if (player)
            {
                // if player exist, set target
                Context.navigation.SetDestination(player.position);
                
                playerLostTimer = playerLostTime;
            }
            else
            {
                // if player not exist, run timer
                playerLostTimer -= Time.deltaTime;
            }
        }
        
        private void OnEndSeePlayer(Transform arg0) => player = null;
        private void OnStartSeePlayer(Transform arg0) => player = arg0;
    }
}