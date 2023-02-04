using System;
using Systems.GameEvents;
using UnityEngine;

namespace Runtime.Resources
{
    [Serializable]
    public class Requirement
    {
        public ScriptableResource scriptableRequirement;
        public int amount;
        
        [Header("Event")]
        public ResourceGameEvent gameEvent;
        
        public void AmountMet()
        {
            if(Inventory.Inventory.CheckRequirement(this))
            {
                MonoBehaviour.print("aaa");
            }
        }
    }
}