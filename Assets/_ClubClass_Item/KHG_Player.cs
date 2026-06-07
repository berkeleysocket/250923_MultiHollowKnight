using Ksy.AgentSystem.ModuleSystem.HealthSystem;
using Ksy.ItemSystem;
using UnityEngine;

public class KHG_Player : MonoBehaviour
{
    public HealthModule Health { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ICollectable>(out ICollectable item))
        {
            item.Collect(this);
        }
    }
}