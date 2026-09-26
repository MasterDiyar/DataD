using DataDriver.scripts.resources;
using Godot;

[GlobalClass]
public partial class BulletResource : Resource, IResourceInit<BulletResource>
{
    [Export] public PackedScene BulletResourceScene;
    [Export] public float InitialSpeed;
    [Export] public Shape2D AreaShape;
    [Export] public float Pierce = 1; // if Pierce = 0 it queuefree if Pierce -1 it should stay till timeout
    [Export] public float LifeTime = 1;

    public BulletResource Copy()
    {
        return (BulletResource)Duplicate();
    }
}