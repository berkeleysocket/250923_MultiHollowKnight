namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct DamageData
    {
        public DamageData(Agent giver, AttackType attackType, DamageFlag damageFlag, int damageValue)
        {
            this.giver = giver;
            this.attackType = attackType;
            this.damageFlag = damageFlag;
            this.damageValue = damageValue;
        }

        public static DamageData Create(Agent giver, AttackType attackType, DamageFlag damageFlag, int damageValue)
        {
            DamageData result = new DamageData(giver, attackType, damageFlag, damageValue);
            return result;
        }

        public readonly Agent giver;
        public readonly AttackType attackType;
        public readonly DamageFlag damageFlag;
        public readonly int damageValue;
    }
}
