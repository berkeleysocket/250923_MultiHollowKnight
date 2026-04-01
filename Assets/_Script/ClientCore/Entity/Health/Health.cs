using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public class Health : DamageableResource, IRrecoverable
    {
        public event Action<int> OnRecovered;

        public int GetHeal(int healVaule)
        {
            if (value >= maxValue) return maxValue;

            value += healVaule;
            return value;
        }
    }
}

