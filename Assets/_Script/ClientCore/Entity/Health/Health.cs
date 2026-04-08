using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public class Health : DamageableResource, IRrecoverable
    {
        public event Action<RecoverData> OnRecovered;
        private RecoverData _recoverEventAtgs = new RecoverData();

        public int GetHeal(int healVaule)
        {
            if (value >= maxValue) return maxValue;

            value += healVaule;
            OnRecovered.Invoke();   

            return value;
        }
    }
}

