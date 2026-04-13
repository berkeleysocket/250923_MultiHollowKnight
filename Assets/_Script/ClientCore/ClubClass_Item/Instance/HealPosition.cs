using Ksy.Agent.Module.HealthSystem;

public class HealPosition : Item
{
    private RecoverData _recoverData;
    public override void Collect(Entity collector)
    {
        base.Collect(collector);

        if(TryGetComponent<IRrecoverable>(out IRrecoverable recoverableObj))
        {
            recoverableObj.Recover(_recoverData);
        }
    }
}
