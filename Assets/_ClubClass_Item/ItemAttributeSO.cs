using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAttribute", menuName = "SO/Item/ItemAttribute", order = 0)]
public class ItemAttributeSO : ScriptableObject
{
    //Default Settings
    [field: SerializeField] public ItemAttribute attributeFlag { get; private set; }
    [field: SerializeField] public float duration { get; private set; } = 0f;

    //AttackPowerUp
    [field: SerializeField] public int attackPowerUpValue { get; private set; } = 0;

    //Recover
    [field: SerializeField] public int recoverValue { get; private set; } = 0;

    //SpeedUp
    [field: SerializeField] public float speedUpValue { get; private set; } = 0f;
}

[Flags]
public enum ItemAttribute : byte
{
    None = 0000,
    AttackPowerUp = 0001,
    Recover = 0010,
    SpeedUp = 0100
}

