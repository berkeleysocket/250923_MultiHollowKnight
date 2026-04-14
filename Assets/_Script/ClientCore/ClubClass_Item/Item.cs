using System;
using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectable
{
    public event Action<Agent> OnCollected;
    public virtual void Collect(Agent collector)
    {
        OnCollected.Invoke(collector);
    }
}
