using UnityEngine;

namespace Ksy.Manager
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private T _instance;
        private bool _quitting;
        private object _lock;
        public T Instance
        {
            get
            {
                lock(_lock)
                {
                    if(_quitting) return null;
                    if(_instance == null)
                    {
                        _instance = FindAnyObjectByType<T>();

                        if(_instance == null)
                        {
                            string name = typeof(T).Name;
                            var instance = new GameObject(name);

                            _instance = instance.AddComponent(typeof(T)) as T;
                        }
                    }
                
                    return _instance;
                }

            }
        }

        protected virtual void Awake()
        {
            
        }

        void OnApplicationQuit()
        {
            _quitting = true;
        }
    }
}