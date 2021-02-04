using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

interface HasTouchHandling
{
    void HandleTouchInput(InputEvent @event);
    void TouchAndHoldScreen(InputEventScreenTouch touchEvent);
    void ReleaseTouch(InputEventScreenTouch touchEvent);
   
}
