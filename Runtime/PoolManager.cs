using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class PoolManager : MonoBehaviour
    {
        private readonly Dictionary<Type, Pool> _dict = new Dictionary<Type, Pool>();
        private static PoolManager _singleton;

        private static PoolManager Singleton
        {
            get
            {
                if (_singleton) return _singleton;
                var obj = new GameObject("#PoolManager", typeof(PoolManager));
                _singleton = obj.GetComponent<PoolManager>();
                return _singleton;
            }
        }

        private void Awake()
        {
            if (_singleton == null)
            {
                _singleton = this;
                return;
            }
            if (_singleton == this) return;
            Destroy(this);
        }

        private bool AddInstance(Poolable p)
        {
            var type = p.GetType();
            if (!_dict.ContainsKey(type)) _dict.Add(type, new Pool(p));
            return _dict[type].Add(p);
        }

        private GameObject GetInstance(Poolable p, Vector3 pos, Quaternion rot)
        {
            var type = p.GetType();
            if (!_dict.ContainsKey(type)) _dict.Add(type, new Pool(p));
            var obj = _dict[type].Get().gameObject;
            obj.transform.position = pos;
            obj.transform.rotation = rot;
            return obj;
        }
        
        public static GameObject Get(Poolable p, Vector3 pos, Quaternion rot)
        {
            return Singleton.GetInstance(p, pos, rot);
        }

        public static void AddNew(Poolable p, int howMany = 1)
        {
            for (var i = 0; i < howMany; i++)
            {
                Singleton.AddInstance(Instantiate(p));
            }
        }

        public static bool Add(Poolable p)
        {
            return Singleton.AddInstance(p);
        }
    }
}

