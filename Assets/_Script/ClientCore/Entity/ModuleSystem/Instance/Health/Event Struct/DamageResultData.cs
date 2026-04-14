using UnityEngine;

namespace Ksy.Agent.Module.HealthSystem
{
    public readonly struct DamageResultData
    {
        public DamageResultData(global::Agent giver, DamageData damageData, int currentDamageableResourceValue)
        {
            this.giver = giver;
            this.damageData = damageData;
            this.currentDamageableResourceValue = currentDamageableResourceValue;
        }
        public readonly global::Agent giver;
        public readonly DamageData damageData;
        public readonly int currentDamageableResourceValue;
    }
}
