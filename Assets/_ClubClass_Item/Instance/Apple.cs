using Ksy.AgentSystem.ModuleSystem.HealthSystem;
using UnityEngine;

public class Apple : Item
{
    private RecoverData _recoverData;
    private void Start()
    {
        //_recoverData.recoverValue = attributeData
    }
    public override void Collect(Agent collector)
    {
        base.Collect(collector);

        if(collector.TryGetComponent<IRrecoverable>(out IRrecoverable recoverableObj))
        {
            recoverableObj.Recover(_recoverData);
        }
    }
}
