using System;

public interface ICollectable 
{
    public event Action<Entity> OnCollected;
    public void Collect(Entity collector);
}
