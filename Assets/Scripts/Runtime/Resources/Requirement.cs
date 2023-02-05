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
            scriptableRequirement.reqAmount = amount;
            if(Inventory.Inventory.CheckRequirement(scriptableRequirement))
            {
                MonoBehaviour.print("aaa");
            }
        }
    }
}