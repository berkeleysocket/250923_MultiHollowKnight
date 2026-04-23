using System;

public interface ICollectable 
{
    public event Action<Agent> OnCollected;
    public void Collect(Agent collector);
}
