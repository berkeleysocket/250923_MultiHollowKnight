using UnityEngine;
using UnityEngine.InputSystem;

namespace Ksy.AgentSystem.ModuleSystem
{
    [CreateAssetMenu(fileName = "PlayerInput", menuName = "SO/Input/Player", order = 0)]
    public class PlayerInput : AgentInput
    {
        [SerializeField] private InputActionAsset input;

        private InputAction _move;
        private InputAction _jump;

        public override void Initialize()
        {
            _move = input.FindAction("Move");
            _jump = input.FindAction("Jump");

            _move.performed += CallMoveEvent;
            _move.canceled += CallMoveEvent;
            _jump.started += CallJumpEvent;

            _move.Enable();
            _jump.Enable();
        }
        private void OnDestroy()
        {
            _move.performed -= CallMoveEvent;
            _jump.started -= CallJumpEvent;
        }
    }
}
