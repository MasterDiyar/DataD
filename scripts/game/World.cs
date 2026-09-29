using Godot;
using System;

public partial class World : Node2D
{
	[Export] public Node2D Pausable;
	public static World Instance;
	public override void _Ready()
	{
		Instance = this;
	}
}
