using UnityEngine;

namespace Corp_Kaktus.Scripts.EnemyAi.States
{
    public class DrawState : EnemyBaseState
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Context = animator.GetComponent<EnemyAiController>();
            Context.CreateDraw();
        }
    }
}