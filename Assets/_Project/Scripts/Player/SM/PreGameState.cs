using Statics;

namespace _Project.Scripts.Player.SM
{
    public class PreGameState : PlayerBaseState
    {
        public PreGameState(PlayerStateMachine machine, string name) : base(machine, name)
        {
        }

        public override void Enter()
        {
            StaticEvents.OnTappedToPlay += SetInGameState;
        }

        private void SetInGameState()
        {
            Machine.ChangeState(Machine.InGameState);
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            StaticEvents.OnTappedToPlay -= SetInGameState;
        }
    }
}