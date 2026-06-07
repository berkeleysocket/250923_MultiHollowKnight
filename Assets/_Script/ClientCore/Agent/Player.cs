using Ksy.AgentSystem.ModuleSystem;
using UnityEngine.SceneManagement;

namespace Ksy.AgentSystem
{
    public class Player : Agent
    {
        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
            input.OnMoveKeyPressed += GetModule<MovementModule>().Move;
        }
    }
}

