using Godot;

namespace DataDriver.scripts.units;

public partial class Unit : CharacterBody2D
{
    [Export] public StatsResource Stats;
    [Export] public SoulResource Soul;
    [Export] public WeaponResource[] Weapons;
    [Export] public Faction Faction;
    
    public override void _Ready()
    {
        ResourceInit();
    }

    void ResourceInit()
    {
        Stats = Stats.Copy();
        Soul = Soul.Copy(); 
    }
}