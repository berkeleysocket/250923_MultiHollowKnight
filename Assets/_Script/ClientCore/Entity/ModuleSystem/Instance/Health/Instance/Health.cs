using System;

namespace Ksy.Agent.Module.HealthSystem
{
    public class Health : DamageableResource, IRrecoverable
    {
        public event Action<RecoverResultData> OnRecovered;

        public void Recover(RecoverData recover)
        {
            global::Agent giver = recover.giver;
            int recoverValue = recover.recoverValue;

            this.Value += recoverValue;

            RecoverResultData resultData = RecoverResultData.Create(giver, recoverValue);
            OnRecovered.Invoke(resultData);   
        }
    }
}

