using Ksy.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ksy.Agent.Module
{
    public abstract class ModuleOwner : MonoBehaviour
    {
        private Dictionary<Type, IModule> _modules = new Dictionary<Type, IModule>();

        private void Awake()
        {
            Initialize();
            InitializeComponents();
            AfterInitComponents();
        }
        private void Initialize()
        {
            _modules = GetComponentsInChildren<IModule>().ToDictionary
                (module => module.GetType(), iModule => iModule);

            CustomLog.Assert(_modules != null, $"{gameObject.name}'s Modules is not Initialized");
        }
        protected virtual void InitializeComponents()
        {
            foreach (IModule module in _modules.Values)
            {
                module.Initialize(this);
            }
        }
        protected virtual void AfterInitComponents()
        {
            foreach (IAfterModule module in _modules.Values.OfType<IAfterModule>())
            {
                module.AfterInitialize(this);
            }
        }
        public T GetModule<T>()
        {
            if (_modules.TryGetValue(typeof(T), out IModule module))
            {
                return (T)module;
            }

            IModule findModule = _modules.Values.FirstOrDefault(module => module is T);

            if (findModule is T castModule)
                return castModule;

            return default;
        }
    }
}


