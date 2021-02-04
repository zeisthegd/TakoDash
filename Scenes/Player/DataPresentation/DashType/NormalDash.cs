using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NormalDash : DashType
{
    

    public NormalDash():base() 
    {
        
    }
    public override void Dash(Vector2 touchPosition)
    {
        FindDirection(touchPosition);
        velocity = direction.Normalized() * dashSpeed;
        tako.ApplyImpulse(Vector2.Zero, velocity);
        ResetDashProperties();
    }

    public override void Process()
    {
        IncreaseDashSpeed();
    }

    private void IncreaseDashSpeed()
    {
         dashSpeed += speedAddPerFrame;
    }
}
