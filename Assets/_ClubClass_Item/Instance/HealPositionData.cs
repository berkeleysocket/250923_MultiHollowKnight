using UnityEngine;

[CreateAssetMenu(fileName = "HealPositionData", menuName = "SO/ItemData/HealPositionData", order = 0)]
public class HealPositionData : ItemDataSO
{
    [field: SerializeField] public int recoverValue { get; private set; }
}
