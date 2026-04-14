using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.HealthSystem
{
    [CreateAssetMenu(fileName = "DamageableResourceData", menuName = "SO/ModuleSystem/DamageableResource/DamageableResourceData", order = 0)]
    public class DamageableResourceSO : ScriptableObject
    {
        [field: SerializeField] public int MaxValue { get; private set; }
        [field: SerializeField] public int MinValue { get; private set; }
        [field: SerializeField] public int StartValue { get; private set; }
    }
}
