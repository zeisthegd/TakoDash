using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class PlayerIdlingState : PlayerState
{
    public PlayerIdlingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Process()
    {
        HandleKeyPressInput();
        PlayAnimation();
        ChangeToOtherStates();

    }


    public override void PlayAnimation()
    {
        base.PlayAnimation();
      
    }

    

    public override void ChangeToOtherStates()
    {
    }
}
