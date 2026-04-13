using System;

namespace Ksy.Agent.Module.HealthSystem
{
    [Flags]
    public enum DamageFlag : byte
    {
        Normal = 0000,
        Critical = 0001,
        Kill = 0010
    }
}