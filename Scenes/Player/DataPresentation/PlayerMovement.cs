using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerMovement : RigidBody2D
{
    #region Fields

    private Tako tako;
    private Vector2 destination = new Vector2();
    private Vector2 velocity = new Vector2();
    private Vector2 direction = new Vector2();
    private float minDashSpeed = 50;

    private float dashSpeed;
    private float speedAddPerFrame = 100;

    private bool screenTouched = false;

    #endregion

    #region Signals
    [Signal]
    public delegate void TouchScreenEvent();

    

    #endregion


    public PlayerMovement()
    {

    }
    public PlayerMovement(Tako tako)
    {
        this.tako = tako;
        dashSpeed = minDashSpeed;
    }

    public override void _Input(InputEvent @event)
    {
        base._UnhandledInput(@event);
        HandleTouchInput(@event);
    }


    public override void _Process(float delta)
    {
        base._Process(delta);
        IncreaseDashSpeed();
        RotateTako();
    }

    private void RotateTako()
    {
        if(screenTouched)
        {
            tako.LookAt(tako.GetGlobalMousePosition());
            tako.RotationDegrees += 90;
        }
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
            screenTouched = true;
            EmitSignal(nameof(TouchScreenEvent));
            tako.LookAt(GetGlobalTouchPosition(touchEvent.Position));
        }
    }

    public void ReleaseTouch(InputEventScreenTouch touchEvent)
    {
        if (!touchEvent.Pressed)
        {                       
            FindDirection(touchEvent.Position);
            TakoDash();
            EmitSignal(nameof(TouchScreenEvent));
        }
    }

    public void TakoDash()
    {
        CompletelyStopTheBody();
        velocity = new Vector2();
        velocity = direction.Normalized() * dashSpeed;
        tako.ApplyImpulse(Vector2.Zero, velocity);

        ResetDashProperties();
    }

    private void IncreaseDashSpeed()
    {
        if(screenTouched)
            dashSpeed += speedAddPerFrame;
    }

    private void FindDirection(Vector2 touchPosition)
    {
        destination = GetGlobalTouchPosition(touchPosition);
        direction = destination - tako.GlobalPosition;
    }

    private void CompletelyStopTheBody()
    {
        tako.LinearVelocity = Vector2.Zero;
    }

    private void ResetDashProperties()
    {
        velocity = new Vector2();
        direction = new Vector2();
        destination = new Vector2();
        screenTouched = false;
        dashSpeed = minDashSpeed;
    }

    public Vector2 GetGlobalTouchPosition(Vector2 touchEventPosition)
    {
       Vector2 globalTouchPos = tako.GetCanvasTransform().AffineInverse().Xform(touchEventPosition);
       return globalTouchPos;
    }

    #region Properties

    public Vector2 Velocity { get => velocity; }
    public bool ScreenTouched { get => screenTouched; set => screenTouched = value; }

    #endregion

}

