using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems.ObjectPooling
{
    [Serializable]
    public class InstantiadedObject
    {
        public int id;
        public GameObject obj;

        public InstantiadedObject(int index, GameObject obje)
        {
            id = index;
            obj = obje;
        }
    }

    [Serializable]
    public class InstantiatedObjects
    {
        public List<InstantiadedObject> list = new List<InstantiadedObject>();
        public List<InstantiadedObject> active = new List<InstantiadedObject>();
        
        public void ActivateObjectById(int id)
        {
            var tmp = list[id];
            active.Add(tmp);
            list.Remove(tmp);
        }
        
        public void DeactivateObjectById(int id)
        {
            var tmp = active[id];
            list.Add(tmp);
            active.Remove(tmp);
        }
        
        public void ActivateObject()
        {
            
            var tmp = list.FirstOrDefault();
            active.Add(tmp);
            list.Remove(tmp);
            
            if (list.Count == 0)
            {
                var copyArray = new InstantiadedObject[active.Count];
                active.CopyTo(copyArray);

                foreach (var o in copyArray)
                {
                    list.Add(o);
                }
                active.Clear();
            }
        }
        
        public void DeactivateObject()
        {
            var tmp = active.FirstOrDefault();
            list.Add(tmp);
            active.Remove(tmp);
        }
    }
    
    public class ObjectPool<T>
    {
        private PoolableObject<T> _poolableObject;
        
        public List<PooledObject<T>> PooledObjects = new List<PooledObject<T>>();
        public List<PooledObject<T>> ActiveObjects = new List<PooledObject<T>>();
        
        private int _poolAmount = 0;

        public ObjectPool(T item, int amount)
        {
            _poolAmount = amount;
            _poolableObject = new PoolableObject<T>(item);
            PoolObjects();
        }
        
        // Create list/s of specified objects from list
        private void PoolObjects()
        {
            for (int i = 0; i < _poolAmount; i++)
            {
                var pooledObject = new PooledObject<T>(_poolableObject);
                PooledObjects.Add(pooledObject);
            }
        }

        public void ActivateObject()
        {
            var tmp = PooledObjects.FirstOrDefault();
            ActiveObjects.Add(tmp);
            PooledObjects.Remove(tmp);

            if (PooledObjects.Count == 0)
            {
                var copyArray = new PooledObject<T>[ActiveObjects.Count];
                ActiveObjects.CopyTo(copyArray);

                foreach (var o in copyArray)
                {
                    PooledObjects.Add(o);
                }
                ActiveObjects.Clear();
            }
        }
        
        public void DeactivateObject()
        {

            var tmp = ActiveObjects.FirstOrDefault();
            PooledObjects.Add(tmp);
            ActiveObjects.Remove(tmp);
        }
        
        public void ActivateObjectById(int id)
        {
            var tmp = PooledObjects[id];
            ActiveObjects.Add(tmp);
            PooledObjects.Remove(tmp);
        }
        
        public void DeactivateObjectById(int id)
        {
            var tmp = ActiveObjects[id];
            PooledObjects.Add(tmp);
            ActiveObjects.Remove(tmp);
        }

        // Get specified list from all pulled objects
        // public PooledObject<T> GetPooledObject(string objectName) => pooledObjects.FirstOrDefault(o => o.name == objectName);
    }
}