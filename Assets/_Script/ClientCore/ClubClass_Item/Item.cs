using System;
using UnityEngine;

public abstract class Item : MonoBehaviour, ICollectable
{
    public event Action<Entity> OnCollected;
    public virtual void Collect(Entity collector)
    {
        OnCollected.Invoke(collector);
    }
}
