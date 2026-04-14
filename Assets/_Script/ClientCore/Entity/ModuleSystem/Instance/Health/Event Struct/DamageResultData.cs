namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct DamageResultData
    {
        public DamageResultData(Agent giver, DamageData damageData, int resourceValue)
        {
            this.giver = giver;
            this.damageData = damageData;
            this.resourceValue = resourceValue;
        }
        public static DamageResultData Create(Agent giver, DamageData damageData, int resourceValue)
        {
            DamageResultData result = new DamageResultData(giver, damageData, resourceValue);
            return result;
        }

        public readonly Agent giver;
        public readonly DamageData damageData;
        public readonly int resourceValue;
    }
}
