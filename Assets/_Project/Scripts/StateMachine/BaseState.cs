using UnityEngine;

namespace _Project.Scripts.Units.StateMachine
{
    public abstract class BaseState
    {
        public string StateName;
        
        public virtual void TriggerEnter(Collider collider) { }
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}