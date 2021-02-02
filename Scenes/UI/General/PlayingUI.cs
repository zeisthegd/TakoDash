using Godot;
using System;

public class PlayingUI : CanvasLayer, HasComponents
{
    InkMeter inkMeter;
    

    

    public override void _Ready()
    {
        GetComponents();
    }

    public void GetComponents()
    {
        inkMeter = (InkMeter)GetNode("InkMeter");
       
    }


    public InkMeter InkMeter { get => inkMeter;}
}
