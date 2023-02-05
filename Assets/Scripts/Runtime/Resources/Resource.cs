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
        public int addableAmount;
        
        [Header("Event")]
        public ResourceGameEvent gameEvent;
        
        public void AddResourceToInventory() => gameEvent.Raise(this);
        // public void SetResourceAmount(int amount) => Amount = amount;
        public int GetAmount() => addableAmount;
    }
}