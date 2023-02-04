using System;
using UnityEngine;

namespace Systems.ObjectPooling
{
    [Serializable]
    public class PoolableObject<T>
    {
        public T objectPrefab;
        public PoolableObject(T prefab)
        {
            objectPrefab = prefab;
        }
    }
}