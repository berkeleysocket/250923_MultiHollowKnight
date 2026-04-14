using System;
using TMPro;
using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public class HealthModule : DamageableResource, IRrecoverable, IModule
    {
        [SerializeField] private TMP_Text hpText;
        public event Action<RecoverResultData> OnRecovered;

        public void Initialize(ModuleOwner owner)
        {
            Initialize();
            OnHurt += UpdateHpText;
        }
        public void Recover(RecoverData recover)
        {
            Entity giver = recover.giver;
            int recoverValue = recover.recoverValue;

            this.Value += recoverValue;

            RecoverResultData resultData = RecoverResultData.Create(giver, Value, recoverValue);
            OnRecovered.Invoke(resultData);   
        }

        #region UnityLifeCycle
        private void OnDestroy()
        {
            OnHurt -= UpdateHpText;
        }
        #endregion
        private void UpdateHpText(DamageResultData hurtData)
        {
            hpText.text = $"HP : {hurtData.resourceValue}";
        }
        [ContextMenu("Hurt")]
        private void Hurt()
        {
            GetDamage(DamageData.Create(null, AttackType.Normal, DamageFlag.Normal, 1));
        }    
    }
}

