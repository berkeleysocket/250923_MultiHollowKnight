using System;
using UnityEngine;

public interface IMovable
{
    public event Action OnMove;
    public void Move(Vector2 direction);
    public void SetDestination(Vector2 position);
}
