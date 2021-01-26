using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class PlayerDashingState : PlayerState
{
    public PlayerDashingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Process()
    {
        HandleKeyPressInput();
        PlayAnimation();      
        ChangeToOtherStates();
    }



    public override void ChangeToOtherStates()
    {
        
    }

    public override void PlayAnimation()
    {
        base.PlayAnimation();
        
    }

}

