using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public event Action<Vector2> Moved;

    private Player _player;
    private Rigidbody2D _rb;
    private Vector2 _moveDir => _player.ControlCompo.InputDir;
    private float _moveSpeed => _player.MoveSpeed;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _rb.gravityScale = 10;
    }
    private void FixedUpdate()
    {
        Moved?.Invoke(_moveDir);
        _rb.linearVelocity = new Vector2(_moveDir.normalized.x,0) * _moveSpeed;
    }
}
