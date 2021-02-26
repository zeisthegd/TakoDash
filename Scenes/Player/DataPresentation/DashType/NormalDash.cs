using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NormalDash : DashType
{
    protected float minDashSpeed = 50;
    protected float dashSpeed;
    protected float speedAddPerFrame = 100;

    public NormalDash() : base()
    {
        dashSpeed = minDashSpeed;
    }


    public override void Process()
    {
        IncreaseDashSpeed();
        GD.Print(dashSpeed);
    }

    public override void ExecuteDashAlgo(Vector2 touchPosition)
    {
        FindDirection(touchPosition);
        velocity = direction.Normalized() * dashSpeed;
        tako.ApplyImpulse(Vector2.Zero, velocity);
    }

    protected override void ResetDashProperties()
    {
        base.ResetDashProperties();
        dashSpeed = minDashSpeed;
    }

    public float IncreaseDashSpeed()
    {
        if(tako.PlayerMovement.ScreenTouched)
            dashSpeed += speedAddPerFrame;
        return dashSpeed;
    }
}
