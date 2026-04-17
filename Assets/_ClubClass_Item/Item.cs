using System;
using UnityEngine;
public abstract class Item : Entity, ICollectable
{
    [field : SerializeField] protected ItemAttributeSO[] attributeData { get; private set; }

    public event Action<Entity> OnCollected;

    public virtual void Collect(Entity collector)
    {
        OnCollected.Invoke(collector);
    }
}
