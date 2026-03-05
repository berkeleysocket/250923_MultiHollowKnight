using UnityEngine;

namespace Ksy.Entity.Module
{
    public class EM_AnimatorX : MonoBehaviour
    {
        private Animator _animator;

        public void Init(Animator animator)
        {
            this._animator = animator;
        }

        public void SetState(EntityAnimationState state)
        {
            if (state == EntityAnimationState.Idle)
                _animator.SetBool("isIdle", true);
            if (state == EntityAnimationState.Walk)
                _animator.SetBool("isWalking", true);
        }
    }

    public enum EntityAnimationState
    {
        None = 0,
        Idle,
        Walk
    }
}

