using Godot;
using System;

public class Tako : RigidBody2D, HasComponents
{
    Sprite spriteSheet;
    AnimationPlayer animationPlayer;
    Hurtbox hurtBox;
    PlayerMovement playerMovement;
    PlayerStateMachine playerStateMachine;

    public override void _Ready()
    {
        GetComponents();
        InitializePlayer();
    }
    public override void _Process(float delta)
    {
        playerStateMachine.Process();
        playerMovement._Process(delta);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        playerMovement._Input(@event);
        
    }

    public void GetComponents()
    {
        hurtBox = (Hurtbox)GetNode("Hurtbox");
        spriteSheet = (Sprite)GetNode("Sprite");
        animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        
    }

    private void InitializePlayer()
    {
        playerStateMachine = new PlayerStateMachine(this);
        playerMovement = new PlayerMovement(this);
    }

    #region Properties
    public AnimationPlayer AnimationPlayer { get => animationPlayer; }
    #endregion

    #region Signals

    private void _on_Hurtbox_area_entered(Area2D area)
    {
        
    }
    #endregion
}





