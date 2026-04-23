using Ksy.Utility;
using System;
using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem
{
    public class MovementModule : MonoBehaviour, IModule, IMovable
    {
        public event Action OnMove;
        private Transform ownerTransform
        {
            get
            {
                if (ownerTransform == null)
                    _transform = _owner.transform;
                return _transform;
            }
        }

        private ModuleOwner _owner;
        private Transform _transform;
        private Rigidbody2D _body;
        private float _speed = 5f;

        #region IModule
        public void Initialize(ModuleOwner owner)
        {
            this._owner = owner;
            this._transform = _owner.transform;
            this._body = owner.GetComponent<Rigidbody2D>();
        }
        #endregion
        #region IMovable
        public void Move(Vector2 direction)
        {
            OnMove?.Invoke();

            CustomLog.Log("Move");
            _body.linearVelocity = direction * _speed;
        }
        public void SetDestination(Vector2 position)
        {
            Vector2 direction = position - (Vector2)ownerTransform.position;
            Move(direction);
        }
        #endregion

    }
}
