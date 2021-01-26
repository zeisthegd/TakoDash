using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

abstract class PlayerState
{
    protected PlayerStateMachine playerStateMachine;

    protected PlayerState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }

    public abstract void Process();

    public virtual void HandleKeyPressInput()
    {
        
    }
    

    public abstract void ChangeToOtherStates();

    public virtual void PlayAnimation()
    {
        
    }
    public void ChangeToIdling()
    {
        playerStateMachine.CurrentState = playerStateMachine.PlayerIdlingState;
    }

    // public void ChangeToCharging()
    // {
    //     playerStateMachine.CurrentState = playerStateMachine.PlayerChargingState;
    // }
    public void ChangeToDashing()
    {
        playerStateMachine.CurrentState = playerStateMachine.PlayerDashingState;
    }
}
