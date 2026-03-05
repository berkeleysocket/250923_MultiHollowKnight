using Ksy.Utility;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Ksy.Entity.Module
{
    public class EM_Movement : MonoBehaviour
    {
        public event Action<Vector2> OnMove;
        
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
        public void SetMoveDirection(Vector2 dir)
        {
            OnMove?.Invoke(dir);
            MoveDir = dir.normalized;
        }
        void Move()
        {
            if(_rb != null)
            {
                DebugX.Log("Move");
                _rb.linearVelocity = MoveDir * speed;
            }
        }
        #endregion
    }
}
