using DataDriver.scripts.resources;
using Godot;

[GlobalClass]
public partial class SoulResource : Resource, IResourceInit<SoulResource>
{
    [Export] public StatsResource InitialAmplifier;

    public SoulResource Copy()
    {
        return (SoulResource)Duplicate();
    }
}