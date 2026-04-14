using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public readonly struct DamageResultData
    {
        public DamageResultData(global::Agent giver, DamageData damageData, int currentDamageableResourceValue)
        {
            this.giver = giver;
            this.damageData = damageData;
            this.resourceValue = currentDamageableResourceValue;
        }
        public readonly global::Agent giver;
        public readonly DamageData damageData;
        public readonly int resourceValue;
    }
}
