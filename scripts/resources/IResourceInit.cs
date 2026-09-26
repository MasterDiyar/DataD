using Godot;

namespace DataDriver.scripts.resources;

public interface IResourceInit<T> where T : Resource
{
    T Copy();
}