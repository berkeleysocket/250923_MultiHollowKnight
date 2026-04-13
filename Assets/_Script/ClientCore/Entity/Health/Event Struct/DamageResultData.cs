using UnityEngine;

namespace Ksy.Agent.Module.HealthSystem
{
    public readonly struct DamageResultData
    {
        public DamageResultData(Entity giver, DamageData damageData, int currentDamageableResourceValue)
        {
            this.giver = giver;
            this.damageData = damageData;
            this.currentDamageableResourceValue = currentDamageableResourceValue;
        }
        public readonly Entity giver;
        public readonly DamageData damageData;
        public readonly int currentDamageableResourceValue;
    }
}
