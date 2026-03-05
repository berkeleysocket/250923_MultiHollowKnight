using Ksy.Entity.Module;
using Ksy.Utility;

using UnityEngine;

namespace Ksy.Entity
{
    public abstract class Entity : MonoBehaviour
    {
        [SerializeField] private EM_ControllerSO controller;
        [SerializeField] private EM_MovementSO Movement;
        [SerializeField] private EM_RendererXSO Randerer;

        private void Awake()
        {
            //if (Movement != null && Controller != null)
            //    Controller.MoveDir.OnChangedValue += Movement.SetDirection;

            //if (Randerer != null && Controller != null)
            //    Controller.MoveDir.OnChangedValue += Randerer.FilpX;
        }
    }
}