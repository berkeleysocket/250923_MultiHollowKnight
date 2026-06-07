using Ksy.AgentSystem.ModuleSystem.HealthSystem;
using Ksy.ItemSystem;
using System;
using UnityEngine;

public class HealPack : MonoBehaviour, ICollectable
{
    [SerializeField] int healAmount = 5;

    public event Action<ICollectable> OnCollected;

    public void Collect(KHG_Player collector)
    {
        var health = collector.Health;
        bool hasHealth = health != null;

        if (hasHealth)
        {
            RecoverData data = new RecoverData(null, healAmount);
            health.Recover(data);
        }
    }
}
