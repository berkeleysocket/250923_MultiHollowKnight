using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class EntityController : MonoBehaviour
    {
        public NotifyValue<Vector2> MoveDir { get; private set; } = new NotifyValue<Vector2>();

        [SerializeField] private EntityControllerSO contorller;

        #region Unity Engine
        private void Awake()
        {
            this.contorller.OnChangedDir += SetDir;
        }
        #endregion

        private void SetDir(Vector2 dir) => this.MoveDir.Value = dir;
    }
}