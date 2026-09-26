
using DataDriver.scripts.resources;
using DataDriver.scripts.units;
using DataDriver.scripts.weapon;
using Godot;

[GlobalClass]

public partial class StatsResource : Resource, IResourceInit<StatsResource>
{
    
    [Export] public float MaxHp, MaxMeleeArmor, MaxRangedArmor, MaxMagicArmor, MaxStrength, MaxSpeed ,MaxMana, MaxCritChance, MaxCritDamage;
    public float Hp;
    public float Speed;

    public bool TakeDamage(HitStruct hitStruct)
    {
        switch (hitStruct.Type) {
            case DamageType.Magic:
                Hp -= Mathf.Max(1, hitStruct.Damage-MaxMagicArmor); break;
            case DamageType.Melee:
                Hp -= Mathf.Max(1, hitStruct.Damage-MaxMeleeArmor); break;
            case DamageType.Ranged:
                Hp -= Mathf.Max(1, hitStruct.Damage-MaxRangedArmor); break;
        }

        return Hp > 0;
    }
    
    
    public StatsResource Copy()
    {
        return (StatsResource)Duplicate();
    }
}