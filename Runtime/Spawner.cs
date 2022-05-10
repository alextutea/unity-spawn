using System;
using UnityEngine;

namespace Spawn
{
    public class Spawner : MonoBehaviour, ISpawnerEventController
    {
        public event Action<Poolable> OnBeforeSpawn = delegate {  };
        public event Action<Poolable> OnAfterSpawn = delegate {  };
        
        [SerializeField] private Poolable poolable;

        public GameObject Spawn(Vector3 pos, Quaternion rot)
        {
            OnBeforeSpawn(poolable);
            var obj = PoolManager.Get(poolable, pos, rot);
            OnAfterSpawn(poolable);
            return obj;
        }
    }
}
