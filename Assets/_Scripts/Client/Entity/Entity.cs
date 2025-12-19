using Ksy.Entity.Compo;
using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity
{
    public class Entity : MonoBehaviour
    {
        public EntityController Controller { get; private set; }
        public Movement Movement { get; private set; }
        public RendererX Randerer { get; private set; }

        private void Awake()
        {
            Controller = GetComponentInChildren<EntityController>(false);
            Movement = GetComponentInChildren<Movement>(false);
            Randerer = GetComponentInChildren<RendererX>(false);

            DebugX.Assert(Controller != null, "Controller is null!", false);
            DebugX.Assert(Movement != null, "Movement is null!", false);
            DebugX.Assert(Randerer != null, "Randerer is null!", false);

            if (Movement != null && Controller != null)
                Controller.Input_Dir.OnChangedValue += Movement.SetMoveDir;

            if (Randerer != null && Controller != null)
                Controller.Input_Dir.OnChangedValue += Randerer.FilpX;
        }
    }
}