using UnityEngine;

public abstract class ItemDataSO : ScriptableObject
{
    [field: SerializeField] public Item ItemPrefab { get; private set; }
}
