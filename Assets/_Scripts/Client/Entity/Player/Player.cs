using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class Player : Entity
    {
        public Controller Controller { get; private set; }
        public Movement Movement { get; private set; }
        public RendererX Randerer { get; private set; }
        public AnimationPlayer Animation { get; private set; }

        private void Awake()
        {
            Controller = GetComponent<Controller>();
            Movement = GetComponent<Movement>();

            Animation = GetComponentInChildren<AnimationPlayer>();
            Randerer = GetComponentInChildren<RendererX>();

            DebugX.Assert(Movement != null, "movement is null!", false);

            DebugX.Assert(Animation != null, "aniPlayer is null!", false);
            DebugX.Assert(Randerer != null, "randerer is null!", false);

            if (Movement != null && Controller != null)
                Controller.Input_Dir.OnChangedValue += Movement.SetMoveDir;

            if (Animation != null && Controller != null)
                Controller.Input_Dir.OnChangedValue += (dir) =>
                {
                    AniParmType parmT = AniParmType.IsMove;
                    bool isMove = dir != Vector2.zero;

                    Animation.SetAnimation(parmT, isMove);
                };

            if (Randerer != null && Controller != null)
                Controller.Input_Dir.OnChangedValue += Randerer.FilpX;
        }
    }
}
