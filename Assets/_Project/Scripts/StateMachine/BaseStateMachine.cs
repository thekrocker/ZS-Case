using _Project.Scripts.Units.StateMachine;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour 
{
    protected BaseState CurrentState;

    // Shows state log on object
    [TextArea(10,15)]
    [SerializeField] private string stateLog;
    
    protected virtual void Awake()
    {
        InitStates();
    }

    protected virtual void Start()
    {
        CurrentState = GetInitialState();
        CurrentState.Enter();
        stateLog += $"{CurrentState.StateName}";
    }

    protected virtual void Update()
    {
        CurrentState.Update();
    }

    public abstract BaseState GetInitialState();
    public abstract void InitStates();

    public void ChangeState(BaseState target)
    {
        if (target == CurrentState) return;
        target.Exit();
        CurrentState = target;
        CurrentState.Enter();
        stateLog += $"{CurrentState.StateName}";
    }
}