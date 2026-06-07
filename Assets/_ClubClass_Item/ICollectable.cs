using System;

namespace Ksy.ItemSystem
{
    public interface ICollectable
    {
        public event Action<ICollectable> OnCollected;
        public void Collect(KHG_Player collector);
    }
}