using Godot;
using System;

public class InkMeter : Control, HasComponents
{

    [Export]
    int inkUseToDashPerFrame = 5;
    [Export]
    int baseInk = 100;


    int ink = 100;

    TextureProgress inkAmount;


    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        base._Process(delta);

    }

    public void GetComponents()
    {
        inkAmount = (TextureProgress)GetNode("Ink");
    }

    public int DecreaseInkNormally()
    {
        ink -= inkUseToDashPerFrame;
        return ink;
    }

    public int DecreaseInkByValue(int value)
    {
        ink -= value;
        return ink;
    }

    public int RefillInkToFull()
    {
        while (true)
        {
            ink += 6;
            if (ink >= baseInk)
            {
                ink = baseInk;
                break;
            }
        }
        return ink;
    }

    public int RefilInkByValue(int value)
    {
        ink += value;
        return ink;
    }

    

    public int Ink { get => ink; }
}
