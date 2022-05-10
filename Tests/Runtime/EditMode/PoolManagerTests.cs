using System.Collections.Generic;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Spawn
{
    public class PoolManagerTests
    {
        public class TestObject : Poolable{}
        
        [Test]
        public void TestPoolManager()
        {
            var poolManagerGameObj = GameObject.Find("#PoolManager");
            Assert.IsNull(poolManagerGameObj);
            Assert.AreEqual(0, Resources.FindObjectsOfTypeAll<TestObject>().Length);
            
            var obj = new GameObject();
            var tObj = obj.AddComponent<TestObject>();
            Assert.AreEqual(1, Resources.FindObjectsOfTypeAll<TestObject>().Length);

            PoolManager.Get(tObj, new Vector3(), Quaternion.identity);
            Assert.AreEqual(2, Resources.FindObjectsOfTypeAll<TestObject>().Length);

            PoolManager.AddNew(tObj);
            poolManagerGameObj = GameObject.Find("#PoolManager");
            Assert.IsNotNull(poolManagerGameObj);
            Assert.AreEqual(3, Resources.FindObjectsOfTypeAll<TestObject>().Length);
            
            PoolManager.AddNew(tObj, 3);
            Assert.AreEqual(6, Resources.FindObjectsOfTypeAll<TestObject>().Length);
            
            var obj2 = new GameObject();
            var tObj2 = obj2.AddComponent<TestObject>();
            Assert.AreEqual(7, Resources.FindObjectsOfTypeAll<TestObject>().Length);

            PoolManager.Get(tObj2, new Vector3(), Quaternion.identity);
            Assert.AreEqual(7, Resources.FindObjectsOfTypeAll<TestObject>().Length);
        }
    }
}

