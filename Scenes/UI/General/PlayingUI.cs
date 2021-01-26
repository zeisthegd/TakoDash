using Godot;
using System;

public class PlayingUI : CanvasLayer
{
    InkMeter inkMeter;

    

    public override void _Ready()
    {
        inkMeter = (InkMeter)GetNode("InkMeter");
    }

    public InkMeter InkMeter { get => inkMeter;}
}
