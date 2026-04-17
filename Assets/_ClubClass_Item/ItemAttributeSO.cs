using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAttribute", menuName = "SO/Item/ItemAttribute", order = 0)]
public class ItemAttributeSO : ScriptableObject
{
    [field: SerializeField] public ItemAttributeType AttributeType { get; private set; }
    [field: SerializeField] public float Duration { get; private set; } = 0f;
    [field: SerializeField] public float Value { get; private set; } = 0f;
}
public enum ItemAttributeType : byte
{
    None = 0,
    AttackPowerUp,
    Recover,
    SpeedUp
}

