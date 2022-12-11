using Statics;

namespace _Project.Scripts.Player.SM
{
    public class BossFightStage : PlayerBaseState
    {
        public BossFightStage(PlayerStateMachine machine, string name) : base(machine, name)
        {
        }

        public override void Enter()
        {
            StaticEvents.OnArrivedFinish?.Invoke();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}