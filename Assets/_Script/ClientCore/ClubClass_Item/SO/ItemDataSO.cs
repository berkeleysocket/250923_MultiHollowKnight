using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SO/ItemData", order = 0)]
public abstract class ItemDataSO : ScriptableObject
{
    [field: SerializeField] public Item Prefab { get; private set; }
}
