using System;
using UnityEngine;

namespace Spawn
{
    public abstract class Poolable : MonoBehaviour, IPoolableEventController
    {
        public event Action OnBeforeGetFromPool = delegate { };
        public event Action OnAfterGetFromPool = delegate { };
        public event Action OnBeforeReturnToPool = delegate {  };
        public event Action OnAfterReturnToPool = delegate {  };
        
        private void OnEnable()
        {
            OnBeforeGetFromPool();
            OnAfterGetFromPool();
        }
        
        protected void ReturnToPool()
        {
            OnBeforeReturnToPool();
            PoolManager.Add(this);
            OnAfterReturnToPool();
        }
    }
}

