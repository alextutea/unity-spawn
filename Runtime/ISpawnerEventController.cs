using System;

namespace Spawn
{
    public interface ISpawnerEventController
    {
        public event Action<Poolable> OnBeforeSpawn;
        public event Action<Poolable> OnAfterSpawn;
    }
}