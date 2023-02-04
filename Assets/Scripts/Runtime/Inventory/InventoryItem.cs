using System;
using Runtime.Resources;
using UnityEngine;

namespace Runtime.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ScriptableResource resource;
        public int amount = 0;
        public InventoryItem(ScriptableResource res)
        {
            resource = res;
            amount = 0;
        }
    }
}