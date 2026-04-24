using Ksy.AgentSystem.ModuleSystem.RenderSystem;
using UnityEngine;

namespace Ksy.AgentSystem.FSM
{
    public abstract class AgentState
    {
        protected Agent _agent;
        protected readonly int _stateClipHash;

        protected AgentRenderer _renderer;

        public AgentState(Agent agent, int stateClipHash)
        {
            this._agent = agent;
            this._stateClipHash = stateClipHash;
            this._renderer = agent.GetModule<AgentRenderer>();
        }

        public virtual void Enter(float transitionDuration, int layerIndex = 0)
        {
            _renderer.PlayClip(_stateClipHash, transitionDuration, layerIndex, 0f);
        }

        public virtual void Update()
        {

        }
        
        public virtual void Exit()
        {

        }
    }
}