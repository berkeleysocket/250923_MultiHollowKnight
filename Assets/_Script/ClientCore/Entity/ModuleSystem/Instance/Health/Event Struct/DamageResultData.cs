namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct DamageResultData
    {
        public DamageResultData(Entity giver, DamageData damageData, int resourceValue)
        {
            this.giver = giver;
            this.damageData = damageData;
            this.resourceValue = resourceValue;
        }
        public static DamageResultData Create(Entity giver, DamageData damageData, int resourceValue)
        {
            DamageResultData result = new DamageResultData(giver, damageData, resourceValue);
            return result;
        }

        public readonly Entity giver;
        public readonly DamageData damageData;
        public readonly int resourceValue;
    }
}
