using UnityEngine;

namespace Ksy.Entity.Compo
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        private Rigidbody2D _rb;

        [SerializeField] private float speed = 3f;
        [HideInInspector] public Vector2 MoveDir = Vector2.zero;

        #region Unity Event
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            Debug.Assert(_rb != null, "<color=red>_rb is null!!</color>");
        }
        void FixedUpdate()
        {
            Move();
        }
        #endregion
        public void Move()
        {
            _rb.linearVelocity = MoveDir * speed;
        }
        public void SetMoveDir(Vector2 dir)
        {
            MoveDir = dir.normalized;
        }
    }
}
