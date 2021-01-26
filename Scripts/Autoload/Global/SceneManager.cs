using Godot;
using System;

//Class này được sử dụng để chuyển đổi các Scene, thay đổi màn chơi
public class SceneManager : Node
{
    static DynamicMusic dynamicMusic;
    static PlayingUI playingUI;

    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
        dynamicMusic = (DynamicMusic)GetTree().Root.GetNode("DynamicMusic");
    }

    public void GotoScene(string path)
    {
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void ReloadScene(Node scene)
    {
        
    }

    public void DeferredGotoScene(string path)
    {
        CurrentScene.Free();
        var nextScene = (PackedScene)GD.Load(path);
        CurrentScene = nextScene.Instance();
        GetTree().Root.AddChild(CurrentScene);
        GetTree().CurrentScene = CurrentScene;
    }


    public static Node CurrentScene { get; set; }
    public static DynamicMusic MainMusicPlayer { get => dynamicMusic;}
    public static PlayingUI PlayingUI { get => playingUI;}
}