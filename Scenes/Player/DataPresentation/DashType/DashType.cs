using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class DashType : RigidBody2D
{
    protected Tako tako;

    protected Vector2 destination = new Vector2();
    protected Vector2 velocity = new Vector2();
    protected Vector2 direction = new Vector2();

    protected float minDashSpeed = 50;
    protected float dashSpeed;
    protected float speedAddPerFrame = 10;

    public DashType() 
    {
        dashSpeed = minDashSpeed;
        tako = SceneManager.Tako;
    }
    public abstract void Dash(Vector2 touchPosition);
    public abstract void Process();

    protected void ResetDashProperties()
    {
        velocity = new Vector2();
        direction = new Vector2();
        destination = new Vector2();
        dashSpeed = minDashSpeed;
    }

    protected void FindDirection(Vector2 touchPosition)
    {    
        destination = Coordinator.GetGlobalTouchPosition(touchPosition);
        direction = destination - tako.GlobalPosition;
    }

    

    public Vector2 Velocity { get => velocity; }
}
