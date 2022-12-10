using System;
using _Project.Scripts.Units.StateMachine;
using Player;
using UnityEngine;

namespace _Project.Scripts.Player.SM
{
    public class PlayerStateMachine : BaseStateMachine
    {
        #region States

        public PreGameState PreGameState { get; private set; }
        public InGameState InGameState { get; private set; }
        public EndGameState EndGameState { get; private set; }

        #endregion
        
        [field: SerializeField] public PlayerMovement Movement { get; private set; }
        [field: SerializeField] public PlayerAnimation Animation { get; private set; }

        public override BaseState GetInitialState()
        {
            return PreGameState;
        }

        public override void InitStates()
        {
            PreGameState = new PreGameState(this, "Pre-Game State");
            InGameState = new InGameState(this, "In-Game State");
            EndGameState = new EndGameState(this, "End-Game State");
        }

        private void OnTriggerEnter(Collider other)
        {
            CurrentState.TriggerEnter(other);
        }
    }
}