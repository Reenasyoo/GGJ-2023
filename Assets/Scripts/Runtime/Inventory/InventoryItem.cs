using System;
using Runtime.Resources;
using UnityEngine;

namespace Runtime.Inventory
{
    [Serializable]
    public class InventoryItem
    {
        public ScriptableResource resource;
        public int amount;
    }
}