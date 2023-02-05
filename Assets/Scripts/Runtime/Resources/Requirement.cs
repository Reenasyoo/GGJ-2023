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

        public bool AmountMet()
        {

            scriptableRequirement.reqAmount = amount;
            if(Inventory.Inventory.CheckRequirement(scriptableRequirement))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}