using Godot;

namespace DataDriver.scripts.bullets;

public readonly record struct BulletStruct(
    BulletResource BulletResource,
    float Damage, 
    float Angle,
    Vector2 GlobalPosition,
    Vector2 GlobalScale
    );