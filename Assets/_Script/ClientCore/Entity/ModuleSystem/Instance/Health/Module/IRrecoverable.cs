using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public interface IRrecoverable
    {
        public event Action<RecoverResultData> OnRecovered;
        public void Recover(RecoverData recover);
    }
}