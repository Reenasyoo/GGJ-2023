using System;
using Lumios.System.ScriptableValues;
using Runtime.Resources;
using UnityEngine;

namespace Runtime.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ScriptableResource resource;
        // public IntValue amount;
        public InventoryItem(ScriptableResource res)
        {
            resource = res;
            resource.amount.SetValue(0);
        }
    }
}