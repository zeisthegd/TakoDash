using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerMovement : RigidBody2D, HasTouchHandling
{
    #region Fields

    private Tako tako;
    private Vector2 touchPosition;
    private bool screenTouched = false;

    DashType dashType;

    #endregion
    public PlayerMovement(){}
    public PlayerMovement(Tako tako)
    {
        this.tako = tako;      
        dashType = new NormalDash();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        HandleTouchInput(@event);
    }


    public override void _Process(float delta)
    {
        base._Process(delta);
        dashType.Process();
    }

    public void HandleTouchInput(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touchEvent)
        {
            TouchAndHoldScreen(touchEvent);
            ReleaseTouch(touchEvent);
        }
    }

    public void TouchAndHoldScreen(InputEventScreenTouch touchEvent)
    {
        if (touchEvent.Pressed)
        {
            touchPosition = touchEvent.Position;
            tako.LookAt(Coordinator.GetGlobalTouchPosition(touchPosition));
            screenTouched = true;
        }
    }

    public void ReleaseTouch(InputEventScreenTouch touchEvent)
    {
        if (touchEvent.Pressed == false)
        {
            touchPosition = touchEvent.Position;
            dashType.Dash(touchPosition);
            screenTouched = false;
        }
    }

    public void HaveInk()
    {
        dashType.Enabled = true;
    }

    public void OutOfInk()
    {
        if(screenTouched)
            touchPosition = Coordinator.GetGlobalTouchPosition(tako.GetGlobalMousePosition());
        dashType.Dash(touchPosition);
        dashType.Enabled = false;
    }



    #region Properties

    
    public bool ScreenTouched { get => screenTouched; set => screenTouched = value; }

    #endregion

}

