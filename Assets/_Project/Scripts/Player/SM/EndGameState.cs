using Statics;

namespace _Project.Scripts.Player.SM
{
    public class EndGameState : PlayerBaseState
    {
        public EndGameState(PlayerStateMachine machine, string name) : base(machine, name)
        {
        }

        public override void Enter()
        {
            StaticEvents.OnGameEnded?.Invoke();
            Machine.Animation.SetDanceAnim();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}