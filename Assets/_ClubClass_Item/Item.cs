using System;
using UnityEngine;
public abstract class Item : MonoBehaviour, ICollectable
{
    [field : SerializeField] protected ItemAttributeSO[] attributeData { get; private set; }

    public event Action<Agent> OnCollected;

    public virtual void Collect(Agent collector)
    {
        OnCollected.Invoke(collector);
    }
}
