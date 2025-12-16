using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] private PlayerInput inputAction;

        private void Awake()
        {
            inputAction.OnChangedPlayerPos += (pos) => Input_Dir.Value = pos;
        }

        public NotifyValue<Vector2> Input_Dir { get; private set; } = new NotifyValue<Vector2>();
    }
}

