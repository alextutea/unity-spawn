using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class Pool
    {
        private readonly Queue<Poolable> _q;
        private readonly HashSet<Poolable> _set;
        private readonly Poolable _src;

        public Pool(Poolable p)
        {
            _set = new HashSet<Poolable>();
            _q = new Queue<Poolable>();
            _src = p;
        }

        public Poolable Get()
        {
            if (Count == 0) PoolManager.AddNew(_src);
            var p = _q.Dequeue();
            _set.Remove(p);
            p.gameObject.SetActive(true);
            return p;
        }

        public bool Add(Poolable p)
        {
            if (!_set.Add(p)) return false;
            p.gameObject.SetActive(false);
            _q.Enqueue(p);
            return true;
        }

        public int Count => _set.Count;

        public void Clear()
        {
            _set.Clear();
            _q.Clear();
        }

        public bool Contains(Poolable p) => _set.Contains(p);

        public Poolable Peek() => _q.Peek();
    }
}

