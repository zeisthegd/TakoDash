using Godot;
using System;

//Class này được sử dụng để chuyển đổi các Scene, thay đổi màn chơi
public class SceneManager : Node
{
    static Tako tako;
    static DynamicMusic dynamicMusic;
    static PlayingUI playingUI;

    public override void _Ready()
    {
        GetRootAndCurrentScene();
        GetTako();
    }

    public void GotoScene(string path)
    {
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void DeferredGotoScene(string path)
    {
        CurrentScene.Free();
        var nextScene = (PackedScene)GD.Load(path);
        CurrentScene = nextScene.Instance();
        GetTree().Root.AddChild(CurrentScene);
        GetTree().CurrentScene = CurrentScene;
    }

    private void GetRootAndCurrentScene()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
    }

    private Tako GetTako()
    {
        try
        {
            tako = (Tako)CurrentScene.GetNode("Tako");
        }
        catch (Exception ex)
        {
            GD.Print(ex.Message);
            GD.Print("Tako is not spawned in this Scene!");
        }
        return tako;
    }


    public static Node CurrentScene { get; set; }
    public static DynamicMusic MainMusicPlayer { get => dynamicMusic; }
    public static PlayingUI PlayingUI { get => playingUI; }
    public static Tako Tako { get => tako; }
}