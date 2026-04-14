using UnityEngine;

namespace Ksy.AgentSystem.ModuleSystem.RenderSystem
{
    [CreateAssetMenu(fileName = "Animation Param", menuName = "SO/ModuleSystem/Renderer/Animation Param")]
    public class AnimParamSO : ScriptableObject
    {
        [field: SerializeField] public string ParamName { get; private set; }
        [field: SerializeField] public int ParamHash { get; private set; }

        private void OnValidate()
        {
            if(ParamName != null)
                ParamHash = Animator.StringToHash(ParamName);
        }
    }
}

