using DataDriver.scripts.resources;
using Godot;

[GlobalClass]
public partial class WeaponResource : Resource, IResourceInit<WeaponResource>
{
    [Export] BulletResource Bullet;

    public WeaponResource Copy()
    {
        return (WeaponResource)Duplicate();
    }
}