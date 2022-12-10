using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Player.SM;
using _Project.Scripts.Units.StateMachine;
using UnityEngine;

public abstract class PlayerBaseState : BaseState
{
    protected PlayerStateMachine Machine;
    
    public PlayerBaseState(PlayerStateMachine machine, string name)
    {
        Machine = machine;
        StateName = name;
    }
}
