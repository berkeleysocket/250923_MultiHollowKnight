using System;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public interface IRrecoverable
    {
        public event Action<RecoverResultData> OnRecovered;
        public void Recover(RecoverData recover);
    }
}