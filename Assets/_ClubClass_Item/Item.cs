using System;
using UnityEngine;
public abstract class Item : Entity, ICollectable
{
    [SerializeField] private ItemAttributeSO attribute;

    public event Action<Entity> OnCollected;

    public virtual void Collect(Entity collector)
    {
        OnCollected.Invoke(collector);
    }
}
