using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class EntityController : MonoBehaviour
    {
        [SerializeField] private EntityControllerSO listener;

        private void Awake()
        {
            listener.OnChangedDir += (dir)=> Dir = dir;
        }

        public Vector2 Dir { get; private set; }
    }
}