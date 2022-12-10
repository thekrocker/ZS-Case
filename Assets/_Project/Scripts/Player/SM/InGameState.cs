using UnityEngine;

namespace _Project.Scripts.Player.SM
{
    public class InGameState : PlayerBaseState
    {
        public InGameState(PlayerStateMachine machine, string name) : base(machine, name)
        {
        }

        public override void Enter()
        {
            Machine.Animation.SetMoveAnim(true);
        }

        public override void Update()
        {
            Machine.Movement.TryMove();
        }

        public override void TriggerEnter(Collider collider)
        {
            base.TriggerEnter(collider);
            if (collider.gameObject.CompareTag("Finish")) Machine.ChangeState(Machine.EndGameState);
        }

        public override void Exit()
        {
        }
    }
}