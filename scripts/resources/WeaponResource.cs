using DataDriver.scripts.bullets;
using DataDriver.scripts.player;
using DataDriver.scripts.resources;
using Godot;

[GlobalClass]
public partial class WeaponResource : Resource, IResourceInit<WeaponResource>
{
    [Export] BulletResource Bullet;
    [Export] public float Damage;
    [Export] public float AttackSpeed;

    public bool CanShoot => _canShoot;

    protected bool _canShoot = true;
    public WeaponResource Copy()
    {
        return (WeaponResource)Duplicate();
    }

    public virtual void Shoot(Vector2 pos,float angle)
    {
        if (!_canShoot) return;
        _canShoot = false;
        var bullet = Bullet.BulletResourceScene.Instantiate<Bullet>();
        
        bullet.Rotation = angle;
        bullet.GlobalPosition = pos;
    }

    public virtual void Spawn(Bullet bullet)
    {
        World.Instance.Pausable.AddChild(bullet);
    }

    public void Link(PlayerController player)
    {
        player.Attacked += Shoot;
    }
}