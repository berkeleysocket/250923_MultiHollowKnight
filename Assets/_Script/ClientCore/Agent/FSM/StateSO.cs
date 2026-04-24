using Ksy.AgentSystem.ModuleSystem.RenderSystem;
using UnityEngine;

namespace Ksy.AgentSystem.FSM
{
    [CreateAssetMenu(fileName = "State data", menuName = "Agent/StateData", order = 20)]
    public class StateSO : ScriptableObject
    {
        public string stateName;
        public string className;
        public int assetName;
        public AnimParamSO stateParam;
    }
}

