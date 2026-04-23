using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ksy.AgentSystem.ModuleSystem
{
    public abstract class AgentInput : ScriptableObject
    {
        public event Action OnAttackKeyPressed;
        public event Action<Vector2> OnMoveKeyPressed;
        public event Action OnJumpKeyPressed;
        public event Action OnDashKeyPressed;

        public abstract void Initialize(); 

        protected void CallAttackEvent(InputAction.CallbackContext callback) => OnAttackKeyPressed?.Invoke();
        protected void CallMoveEvent(InputAction.CallbackContext callback) => OnMoveKeyPressed?.Invoke(callback.ReadValue<Vector2>());
        protected void CallJumpEvent(InputAction.CallbackContext callback) => OnJumpKeyPressed?.Invoke();
        protected void CallDashEvent(InputAction.CallbackContext callback) => OnDashKeyPressed?.Invoke();
    }
}

