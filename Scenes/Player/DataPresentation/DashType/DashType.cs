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

    

    private bool enabled = true;

    public DashType() 
    {
        tako = SceneManager.Tako;
    }

    public void Dash(Vector2 touchPosition)
    {
        if (Enabled)
            ExecuteDashAlgo(touchPosition);
         ResetDashProperties();
    }

    public abstract void ExecuteDashAlgo(Vector2 touchPosition);
    public abstract void Process();

    protected virtual void ResetDashProperties()
    {
        velocity = new Vector2();
        direction = new Vector2();
        destination = new Vector2();
    }

    protected void FindDirection(Vector2 touchPosition)
    {    
        destination = Coordinator.GetGlobalTouchPosition(touchPosition);
        direction = destination - tako.GlobalPosition;
    }

    public Vector2 Velocity { get => velocity; }
    public bool Enabled { get => enabled; set => enabled = value; }
}
