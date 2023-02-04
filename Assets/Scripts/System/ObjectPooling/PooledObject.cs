using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Systems.ObjectPooling
{
    [Serializable]
    public class PooledObject<T>
    {
        public PoolableObject<T> poolable;
        
        public PooledObject(PoolableObject<T> obj)
        {
            poolable = obj;
        }
        
        // Get one object from specified list
        // public GameObject GetObjectFromPooledList(string objectName) => pooledList.FirstOrDefault(t => t.activeInHierarchy);
        
        // // Activates specified lists objects with specified object count
        // public void ActivatePooledObjects(int objectCount, Transform parent)
        // {
        //     for (int i = 0; i < objectCount; i++)
        //     { 
        //         var obj = pooledList[i];
        //         obj.SetActive(true);
        //         activeList.Add(obj);
        //     }
        //     ChangeParent(parent);
        // }
        //
        // // Deactivates all active objects from specified list
        // public void DeactivateObjects()
        // {
        //     foreach (var activeObject in activeList)
        //     {
        //         activeObject.SetActive(false);
        //     }
        //     ChangeParent(_parent);
        // }
        //
        // public void DeactivateObject(int id)
        // {
        //     var tmp = activeList.ElementAt(id);
        //     tmp.transform.SetParent(_parent);
        //     tmp.SetActive(false);
        // }
        //
        // public void ChangeParent(Transform parent)
        // {
        //     foreach (var o in activeList)
        //     {
        //         o.transform.SetParent(parent);
        //     }
        // }
    }
}