using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public interface IRrecoverable
    {
        public event Action<int> OnRecovered;
        public int GetHeal(int healValue);
    }
}