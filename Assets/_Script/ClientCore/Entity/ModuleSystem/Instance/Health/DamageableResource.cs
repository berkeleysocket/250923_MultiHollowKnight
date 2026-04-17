using System;
using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    public abstract class DamageableResource : MonoBehaviour
    {
        [SerializeField] private DamageableResourceSO data;

        public event Action<DamageData> OnHit;
        public event Action<DamageResultData> OnHurt;

        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }
        public bool isDamageable { get; private set; } = true;
        
        public bool IsBroken
        {
            get
            {
                return Value <= MinValue;
            }
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = Mathf.Clamp(value, MinValue, MaxValue);
            }
        }

        private int _value;
        
        public virtual void Initialize()
        {
            this.MaxValue = data.MaxValue;
            this.MinValue = data.MinValue;
            this.Value = data.StartValue;
        }
        public virtual void GetDamage(DamageData damageData)
        {
            int lastValue = 0;
            int calcValue = 0;
            bool isDamaged = false;

            OnHit?.Invoke(damageData);

            if (!isDamageable) return;
            if (IsBroken) return;

            lastValue = Value;
            Value -= damageData.damageValue;
            calcValue = Value;
            isDamaged = lastValue > calcValue;

            if(isDamaged)
            {
                DamageResultData hurtData = new DamageResultData(damageData.giver, damageData, Value);
                OnHurt?.Invoke(hurtData);
            }
        }
        public virtual void GetKillDamage()
        {
            Entity giver = null;
            AttackType attackType = AttackType.System;
            DamageFlag damageType = DamageFlag.Kill;
            int damage = Value;

            DamageData damageData = DamageData.Create(giver, attackType, damageType, damage);

            GetDamage(damageData);
        }
    }
}
