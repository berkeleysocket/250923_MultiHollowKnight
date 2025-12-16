using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity.Compo
{
    public class AnimationPlayer : MonoBehaviour
    {
        private Animator _animator;

        private readonly int _hash_IsMove = Animator.StringToHash("IsMove");
        private void Awake()
        {
            _animator = GetComponent<Animator>();

            DebugX.Assert(_animator != null, "_animator is null!!");
        }
        public void SetAnimation(AniParmType parmT, bool value)
        {
            int? hash = ReturnHash(parmT);

            if (hash != null)
                _animator.SetBool((int)hash, value);
        }
        private int? ReturnHash(AniParmType parm)
        {
            switch (parm)
            {
                case AniParmType.None:
                    {
                        break;
                    }
                case AniParmType.IsMove:
                    {
                        return _hash_IsMove;
                    }
                default:
                    {
                        break;
                    }
            }

            return null;
        }
    }
    public enum AniParmType
    {
        None,
        IsMove,
    }
}
