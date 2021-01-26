using Godot;
using System;

public class DebugUI : CanvasLayer, HasComponents
{
	private string pathToAllQActions = "Tabs/QuickActions/All";

	//Graphics
	Button fullScreen, resolution;

	//Game
	Button pauseGame;

	//Audio


	public override void _Ready()
	{
		GetComponents();
	}

	public void GetComponents()
	{
		GetAllButtons();
	}

	private void GetButton(Button button, string path)
	{
		button = (Button)GetNode(path);

	}

	private void GetAllButtons()
	{
		GetButton(fullScreen, pathToAllQActions + "/Graphics/FullScreen");
		GetButton(pauseGame, pathToAllQActions + "/Game/PauseGame");
	}









	private void _on_PauseGame_pressed()
	{
		if (GetTree().Paused == true)
			GetTree().Paused = false;
		else GetTree().Paused = true;
	}
	private void _on_FullScreen_toggled(bool button_pressed)
	{
		OS.WindowFullscreen = !OS.WindowFullscreen;
	}

	private void _on_Resolution_pressed()
	{
		// Replace with function body.
	}
}


