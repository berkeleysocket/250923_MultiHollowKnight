using UnityEngine;

[RequireComponent(typeof(PlayerController),typeof(PlayerMovement),typeof(PlayerAnimator))]
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Player : Entity
{
    public PlayerController ControlCompo { get; private set; }
    public PlayerAnimator AnimatorCompo { get; private set; }
    public PlayerMovement MoveCompo { get; private set; }
    public BoxCollider2D Colider { get; private set; }
    public Rigidbody2D RigidBody { get; private set; }

    [field:Header("Player Status")]
    [field:SerializeField] public float MoveSpeed { get; private set; } = 3f;

    private void Awake()
    {
        Colider = GetComponent<BoxCollider2D>();

        AnimatorCompo = GetComponent<PlayerAnimator>();
        ControlCompo = GetComponent<PlayerController>();
        MoveCompo = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        MoveCompo.Moved += AnimatorCompo.Moved_Handler;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.name}");
    }
}
