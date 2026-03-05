using UnityEngine;

namespace Ksy.Entity.Module
{
    [CreateAssetMenu(fileName = "EM_MovementSO", menuName = "SO")]
    public class EM_MovementSO : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
        
        private Rigidbody2D _rb;
        private Vector2 MoveDir = Vector2.zero;

        public void Init(Rigidbody2D rb)
        {
            this._rb = rb;
        }

        #region Unity Event
        void FixedUpdate()
        {
            Move();
        }
        #endregion
        #region Module
        public void Stop()
        {
            MoveDir = Vector2.zero;
        }
        public void SetDirection(Vector2 dir)
        {
            MoveDir = dir.normalized;
        }
        void Move()
        {
            if(_rb != null)
                _rb.linearVelocity = MoveDir * speed;
        }
        #endregion
    }
}
