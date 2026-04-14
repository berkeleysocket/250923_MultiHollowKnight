using Ksy.Utility;
using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.RenderSystem
{
    [RequireComponent(typeof(Animator))]
    public class AgentRenderModule : MonoBehaviour, IModule
    {
        public Animator Animator { get; private set; }
        private ModuleOwner _owner;
        public void Initialize(ModuleOwner owner)
        {
            this._owner = owner;
            Animator = GetComponent<Animator>();

            CustomLog.Assert(Animator != null, $"{gameObject.name}'s Animator is null");
        }
        public void PlayerClip(int clipHash, float crossFadeDuration = 0, int layerMask = 0, float normalizedTime = 0)
        {
            //애니메이션을 전환시키는 함수
            //crossFadeDuration : 실제 시간으로 몇 초 동안 섞을 것인가.
            //normalizedTime : 전체 애니메이션의 몇 %동안 섞을 것인가.
            Animator.CrossFadeInFixedTime(clipHash, crossFadeDuration, layerMask, normalizedTime);
        }
    }
}

