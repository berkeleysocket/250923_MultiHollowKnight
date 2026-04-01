using System;
using UnityEngine;

namespace Ksy.Agent.Module.HealthSystem
{
    public abstract class DamageableResource : MonoBehaviour
    {
        protected bool isBrocked
        {
            get
            {
                return value <= minValue;
            }
        }
        protected bool isDamageable;
        protected int maxValue;
        protected int minValue;
        protected int value;
        public event Action OnHit;
        public event Action OnHurt;

        public void Initialize(int maxValue, int minValue, int startValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.value = startValue;
        }
        //public int GetValue() => _value;
        public int GetValue()
        {
            return value;
        }
        public virtual int GetDamage(int damageValue)
        {
            OnHit?.Invoke();

            if (!isDamageable) return value;
            if (isBrocked) return minValue;

            value -= damageValue;
            OnHurt?.Invoke();

            return value;
        }
    }
}
