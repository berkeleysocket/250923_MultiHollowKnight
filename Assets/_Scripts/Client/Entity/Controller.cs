using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private PlayerInput inputAction;

        private void Awake()
        {
            inputAction.OnChangedPlayerPos += (pos) => MoveDir.Value = pos;
        }

        public NotifyValue<Vector2> MoveDir { get; private set; } = new NotifyValue<Vector2>();
    }
}

