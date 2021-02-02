using Godot;
using System;

public class InkMeter : Control, HasComponents
{

    [Export]
    int inkUseToDashPerFrame = 5;
    [Export]
    int baseInk = 100;

    Tako tako;

    bool screenTouched;
    int remainInk = 100;

    TextureProgress inkAmount;
    Tween inkTween;


    public override void _Ready()
    {
        GetComponents();
        GetTako();
    }

    private void GetTako()
    {
        tako = (Tako)SceneManager.CurrentScene.GetNode("Tako");
        tako.PlayerMovement.Connect(nameof(PlayerMovement.TouchScreenEvent), this, nameof(SetScreenTouch));
    }

    private void SetScreenTouch()
    {
        this.screenTouched = tako.PlayerMovement.ScreenTouched;
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        UpdateRemainingInk();
        if (Input.IsActionJustPressed("refill_ink"))
            RefillInkToFull();
    }

    private void UpdateRemainingInk()
    {
        if (screenTouched)
        {
            DecreaseInkNormally();
            UpdateInkMeter();
        }
    }

    public void GetComponents()
    {
        inkAmount = (TextureProgress)GetNode("Ink");
        inkTween = (Tween)GetNode("InkTween");
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

    

    public int Ink { get => remainInk; }
}
