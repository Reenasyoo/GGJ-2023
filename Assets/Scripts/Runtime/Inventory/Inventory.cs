using System.Collections.Generic;
using Runtime.Resources;
using Systems.GameEvents;
using UnityEngine;

namespace Runtime.Inventory
{
    public class AddableItem
    {
        public int Index;
        public ScriptableResource Resource;

        public AddableItem(int id, ScriptableResource resource)
        {
            Index = id;
            Resource = resource;
        }
    }
    
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> items = new List<InventoryItem>();
        
        public void AddResource(ScriptableResource resource)
        {
            var item = ItemExistsInInventory(resource);
            if ( item != null)
            {
                print("added");
                items[item.Index].amount += resource.GetAmount();
            }
        }

        private AddableItem ItemExistsInInventory(ScriptableResource resource)
        {
            foreach (var item in items)
            {
                if (item.resource.Name == resource.Name)
                {
                    return new AddableItem(items.IndexOf(item), resource);
                }
            }

            return null;
        }
    }
}