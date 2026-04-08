using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public interface IRrecoverable
    {
        public event Action<RecoverData> OnRecovered;
        public int GetHeal(int healValue);
    }
}