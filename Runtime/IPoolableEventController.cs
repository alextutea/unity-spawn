using System;

namespace Spawn
{
    public interface IPoolableEventController
    {
        public event Action OnBeforeGetFromPool;
        public event Action OnAfterGetFromPool;
        public event Action OnBeforeReturnToPool;
        public event Action OnAfterReturnToPool;
    }
}