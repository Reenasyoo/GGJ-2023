using System;
using Systems.GameEvents;
using UnityEngine;

namespace Runtime.Resources
{
    [Serializable]
    public class Resource
    {
        [Header("Resource")]
        public ScriptableResource scriptableResource;
        public int amount;
        
        [Header("Event")]
        public ResourceGameEvent gameEvent;
        
        public void AddResourceToInventory() => gameEvent.Raise(scriptableResource);
    }
}