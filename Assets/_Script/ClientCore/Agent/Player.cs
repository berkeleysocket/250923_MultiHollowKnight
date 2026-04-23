using Ksy.AgentSystem.ModuleSystem;

namespace Ksy.AgentSystem
{
    public class Player : Agent
    {
        protected override void Awake()
        {
            base.Awake();
            input.OnMoveKeyPressed += GetModule<MovementModule>().Move;
        }
    }
}

