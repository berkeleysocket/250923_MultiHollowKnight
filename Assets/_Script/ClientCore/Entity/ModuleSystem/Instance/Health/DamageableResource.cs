using System;
using UnityEngine;

namespace Ksy.Agent.Module.HealthSystem
{
    public abstract class DamageableResource : MonoBehaviour
    {
        public event Action<DamageData> OnHit;
        public event Action<DamageResultData> OnHurt;

        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }
        public bool isDamageable { get; private set; }
        
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
                _value = Mathf.Clamp(_value + value, MinValue, MaxValue);
            }
        }

        private int _value;

        public void Initialize(int maxValue, int minValue, int startValue)
        {
            this.MaxValue = maxValue;
            this.MinValue = minValue;
            this.Value = startValue;
        }
        public int GetValue()
        {
            return Value;
        }
        public virtual int GetDamage(DamageData damageData)
        {
            OnHit?.Invoke(damageData);

            if (!isDamageable) return Value;
            if (IsBroken) return MinValue;

            Value -= damageData.damageValue;

            DamageResultData hurtData = new DamageResultData(damageData.giver, damageData, Value);
            OnHurt?.Invoke(hurtData);

            return Value;
        }
        public virtual void GetKillDamage()
        {
            global::Agent giver = null;
            AttackType attackType = AttackType.System;
            DamageFlag damageType = DamageFlag.Kill;
            int damage = Value;

            DamageData damageData = DamageData.Create(giver, attackType, damageType, damage);

            GetDamage(damageData);
        }
    }
}
