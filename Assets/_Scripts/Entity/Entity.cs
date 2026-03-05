using Ksy.Entity.Module;
using Ksy.Utility;
using UnityEngine;

namespace Ksy.Entity
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private EM_ControllerSO controller;
        private EM_AnimatorX animator;
        private EM_RendererX randerer;
        private EM_Movement movement;

        bool hasController => controller != null;
        bool hasRanderer => randerer != null;
        bool hasMovement => movement != null;
        bool hasAnimator => animator != null;

        private void Awake()
        {
            if (TryGetComponent(out EM_Movement movement)) this.movement = movement;
            if (TryGetComponent(out EM_RendererX randerer)) this.randerer = randerer;

            if (hasAnimator)
            {
                var animator = GetComponentInChildren<Animator>();
                DebugX.Log($"sprenderer = {animator != null}");
                if (animator != null) this.animator.Init(animator);
            }
            if (hasRanderer)
            {
                var sprenderer = GetComponentInChildren<SpriteRenderer>();
                DebugX.Log($"sprenderer = {sprenderer != null}");
                if (sprenderer != null) this.randerer.Init(sprenderer);
            }
            if (hasMovement)
            {
                var rigidbody = GetComponentInChildren<Rigidbody2D>();
                DebugX.Log($"rigidbody = {rigidbody != null}");
                if (rigidbody != null) this.movement.Init(rigidbody);
            }
        }
        private void Start()
        {
            if(hasController && hasRanderer)
            {
                controller.OnPressedMoveKey += movement.SetMoveDirection;
                DebugX.Log("On Move");
            }
            if (hasMovement && hasRanderer)
            {
                movement.OnMove += randerer.FilpX;
                DebugX.Log("On Flip");
            }
            if (hasMovement && hasAnimator)
            {
                movement.OnMove += 
            }
        }
    }
}