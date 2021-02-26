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


    public override void ExecuteDashAlgo(Vector2 touchPosition)
    {
        throw new NotImplementedException();
    }

    public override void Process()
    {
        
    }
}
