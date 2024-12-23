using UnityEngine;
using UnityEngine.Animations;

namespace Corp_Kaktus.Scripts.EnemyAi.States
{
    public class WalkToDrawStateBehavior : EnemyBaseState
    {
        private static readonly int DrawTrigger = Animator.StringToHash("DrawTrigger");

        [SerializeField] private Vector3 targetPosition;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Context = animator.GetComponent<EnemyAiController>();
            Context.SetRandomDrawPosition();
            targetPosition = Context.drawSpawnTemp.position;
            Context.navigation.SetDestination(targetPosition);
        }
       

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if ((targetPosition - animator.transform.position).magnitude < Context.targetCollisionThreshold)
            {
                animator.SetTrigger(DrawTrigger);
                Debug.Log("Change");
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
