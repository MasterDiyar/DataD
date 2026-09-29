using DataDriver.scripts.units;
using Godot;

namespace DataDriver.scripts.player;

public partial class PlayerController : Unit
{
    [Signal]
    public delegate void AttackedEventHandler(Vector2 pos ,float angle);
    
    [Export] private float Acceleration = 100f;
    private float CurrentSpeed;
    public override void _PhysicsProcess(double delta)
    {
        float dt  = (float)delta;
        Vector2 inputDir = Input.GetVector("a", "d", "w", "s");
        if (inputDir.LengthSquared() < .001f) {
            Velocity = Vector2.Zero;
            CurrentSpeed = 0;
        } else {
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, Stats.MaxSpeed, Acceleration*dt);
            Velocity = inputDir * CurrentSpeed;
        }
        if (Input.IsActionPressed("lm")) {EmitSignalAttacked(GlobalPosition, (GlobalPosition-GetGlobalMousePosition()).Angle());}
        MoveAndSlide();
    }


}