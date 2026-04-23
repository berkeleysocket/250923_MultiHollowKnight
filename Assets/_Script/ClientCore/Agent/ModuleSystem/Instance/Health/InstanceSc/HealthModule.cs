using System;
using TMPro;
using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public class HealthModule : DamageableResource, IRrecoverable, IModule
    {
        public event Action<RecoverResultData> OnRecovered;

        public void Initialize(ModuleOwner owner)
        {
            Initialize();
        }
        public void Recover(RecoverData recover)
        {
            Agent giver = recover.giver;
            int recoverValue = recover.recoverValue;

            this.Value += recoverValue;

            RecoverResultData resultData = RecoverResultData.Create(giver, Value, recoverValue);
            OnRecovered.Invoke(resultData);   
        }

        [ContextMenu("Hurt")]
        private void Hurt()
        {
            GetDamage(DamageData.Create(null, AttackType.Normal, DamageFlag.Normal, 1));
        }    
    }
}

