using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class Player : Entity
    {
        public Controller _controller { get; private set; }
        public Movement _movement { get; private set; }
        public RendererX _randerer { get; private set; }
        public AnimationPlayer _aniPlayer { get; private set; }

        private void Awake()
        {
            _controller = GetComponent<Controller>();
            _movement = GetComponent<Movement>();

            _aniPlayer = GetComponentInChildren<AnimationPlayer>();
            _randerer = GetComponentInChildren<RendererX>();

            Debug.Assert(_movement != null, "<color=red>_movement is null!!</color>");

            Debug.Assert(_aniPlayer != null, "<color=red>_aniPlayer is null!!</color>");
            Debug.Assert(_randerer != null, "<color=red>_randerer is null!!</color>");

            if (_movement != null && _controller != null)
                _controller.MoveDir.OnChangedValue += _movement.SetMoveDir;

            if (_aniPlayer != null && _controller != null)
                _controller.MoveDir.OnChangedValue += (dir) =>
                {
                    AniParmType parmT = AniParmType.IsMove;
                    bool isMove = dir != Vector2.zero;

                    _aniPlayer.SetAnimation(parmT, isMove);
                };

            if (_randerer != null && _controller != null)
                _controller.MoveDir.OnChangedValue += _randerer.FilpX;
        }
    }
}
