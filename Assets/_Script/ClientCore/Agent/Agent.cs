using Ksy.AgentSystem.ModuleSystem;

using UnityEngine;

public abstract class Agent : ModuleOwner
{
    [SerializeField] protected AgentInput input;

    protected override void Awake()
    {
        base.Awake();
        input.Initialize();
    }
}
