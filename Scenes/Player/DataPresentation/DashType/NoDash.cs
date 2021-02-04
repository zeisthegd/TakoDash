using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

class NoDash : DashType
{
    public NoDash():base()
    {}

    public override void Dash(Vector2 touchPosition)
    {
        //Play animation
    }

    public override void Process()
    {
        
    }
}
