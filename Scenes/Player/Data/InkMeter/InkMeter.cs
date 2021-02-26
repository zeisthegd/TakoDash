using Godot;
using System;

public class InkMeter : Control, HasComponents, HasTouchHandling
{

    [Export]
    int inkUseToDashPerFrame = 10;
    [Export]
    int baseInk = 100;
    
    Tako tako;

    bool screenTouched;
    int remainInk = 100;

    TextureProgress inkAmount;
    Tween inkTween;

    [Signal]
    public delegate void OutOfInk();
    [Signal]
    public delegate void HaveInk();

    public override void _Ready()
    {
        GetComponents();
        GetTako();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        HandleTouchInput(@event);
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        UpdateRemainingInk();
        if (Input.IsActionJustPressed("refill_ink"))
            RefillInkToFull();
    }

    

    public void GetComponents()
    {
        inkAmount = (TextureProgress)GetNode("Ink");
        inkTween = (Tween)GetNode("InkTween");
    }

    public void HandleTouchInput(InputEvent @event)
    {
        if(@event is InputEventScreenTouch touchEvent)
        {
            TouchAndHoldScreen(touchEvent);
            ReleaseTouch(touchEvent);
        }
    }

    public void TouchAndHoldScreen(InputEventScreenTouch touchEvent)
    {
        if(touchEvent.Pressed)
        {
            screenTouched = true;
        }
        
    }

    public void ReleaseTouch(InputEventScreenTouch touchEvent)
    {
        if (!touchEvent.Pressed)
        {
            screenTouched = false;
        }
    }

    private void UpdateRemainingInk()
    {
        if (screenTouched)
        {
            DecreaseInkNormally();
            UpdateInkMeter();
        }
    }

    

    public int DecreaseInkNormally()
    {
        remainInk -= inkUseToDashPerFrame;
        return remainInk;
    }

    public int DecreaseInkByValue(int value)
    {
        remainInk -= value;
        return remainInk;
    }

    public int RefillInkToFull()
    {
        remainInk = baseInk;
        inkTween.InterpolateProperty(inkAmount, "value", inkAmount.Value, baseInk, 0.04F, Tween.TransitionType.Sine, Tween.EaseType.In);
        inkTween.Start();
        return remainInk;
    }

    private void UpdateInkMeter()
    {
        inkTween.InterpolateProperty(inkAmount, "value", inkAmount.Value, remainInk, 0.001F,Tween.TransitionType.Sine,Tween.EaseType.InOut);
        inkTween.Start();

    }

    public int RefilInkByValue(int value)
    {
        remainInk += value;
        return remainInk;
    }

    private void GetTako()
    {
        tako = SceneManager.Tako;
        Connect(nameof(OutOfInk), tako.PlayerMovement, nameof(tako.PlayerMovement.OutOfInk));
        Connect(nameof(HaveInk), tako.PlayerMovement, nameof(tako.PlayerMovement.HaveInk));
    }

    public void OnInkValueChanged(float value)
    {
        if (value <= 0)
        {
            value = 0;
            EmitSignal(nameof(OutOfInk));
        }
        else EmitSignal(nameof(HaveInk));

    }


    public int Ink { get => remainInk; }
}
