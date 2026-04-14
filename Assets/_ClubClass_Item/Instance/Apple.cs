using Ksy.AgentSystem.ModuleSystem.HealthSystem;
using UnityEngine;

public class Apple : Item
{
    private RecoverData _recoverData;
    public override void Collect(Entity collector)
    {
        base.Collect(collector);

        if(collector.TryGetComponent<IRrecoverable>(out IRrecoverable recoverableObj))
        {
            recoverableObj.Recover(_recoverData);
        }
    }
}
