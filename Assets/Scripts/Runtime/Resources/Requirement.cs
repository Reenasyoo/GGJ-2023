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
            if (Inventory.Inventory.CheckRequirement(this))
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