
using DataDriver.scripts.resources;
using Godot;

[GlobalClass]

public partial class StatsResource : Resource, IResourceInit<StatsResource>
{
    
    [Export] public float MaxHp, MaxMeleeArmor, MaxRangedArmor, MaxMagicArmor, MaxStrength, MaxSpeed ,MaxMana, MaxCritChance, MaxCritDamage;
    public float Hp;
    public float Speed;
    
    
    public StatsResource Copy()
    {
        return (StatsResource)Duplicate();
    }
}