using Godot;

namespace DataDriver.scripts.bullets;

public partial class Bullet : Area2D
{
    [Export] public CollisionShape2D CollisionShape;
    
    private float _speed;
    private float _damage;
    private float _pierce;
    private float _lifeTimeTimer;
    
    public override void _Ready()
    {
        AreaEntered += OnAreaEntered;
        BodyEntered += OnBodyEntered;
    }
    
    public void Init(BulletStruct data)
    {
        var res = data.BulletResource;
        _speed = res.InitialSpeed;
        _lifeTimeTimer = res.LifeTime;
        _pierce = res.Pierce;
        _damage = data.Damage;

        GlobalPosition = data.GlobalPosition;
        GlobalScale = data.GlobalScale;
        GlobalRotation = data.Angle;

        if (CollisionShape != null && res.AreaShape != null)
            CollisionShape.Shape = res.AreaShape;
    }
    
    public override void _Process(double delta)
    {
        float dt = (float)delta;

        _lifeTimeTimer -= dt;
        if (_lifeTimeTimer <= 0f) {
            QueueFree();
            return;
        }
        Vector2 direction = Vector2.FromAngle(Rotation);
        Position += direction * _speed * dt;
    }

    private void OnAreaEntered(Area2D area)
    {
        HandleHit(area);
    }

    private void OnBodyEntered(Node2D body)
    {
        HandleHit(body);
    }

    private void HandleHit(Node target)
    {
        // Здесь твоя логика нанесения урона _damage цели
        // target.TakeDamage(_damage);

        // Pierce == -1: бесконечное пробитие, живет до конца таймаута
        if (_pierce < 0) return;

        _pierce--;
        if (_pierce <= 0)
        {
            QueueFree();
        }
    }
}