using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerStateMachine
{
    Tako tako;

    #region States

    PlayerState currentState;

    PlayerState playerIdlingState;
    PlayerState playerChargingState;
    PlayerState playerDashingState;


    #endregion

    public PlayerStateMachine(Tako tako)
    {
        this.tako = tako;

        playerIdlingState = new PlayerIdlingState(this);
        playerDashingState = new PlayerDashingState(this);

        currentState = playerIdlingState;
    }

    public void Process()
    {
        currentState.Process();
    }

    public void AttackAnimationFinished()
    {
        currentState.ChangeToIdling();
    }


    internal PlayerState CurrentState {set => currentState = value; }
    internal PlayerState PlayerDashingState { get => playerDashingState; }
    internal PlayerState PlayerIdlingState { get => playerIdlingState; }

    public Tako Dae { get => tako;}
    

}
