using System.Collections.Generic;
using Runtime.Resources;
using UnityEngine;

namespace Runtime.Inventory
{
    public class AddableItem
    {
        public readonly int Index;
        public ScriptableResource Resource;

        public AddableItem(int id, ScriptableResource resource)
        {
            Index = id;
            Resource = resource;
        }
    }
    
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ScriptableResource> itemTypes = new List<ScriptableResource>();
        private static List<InventoryItem> items = new List<InventoryItem>();

        private void Awake()
        {
            CreateInventory();
        }

        private void CreateInventory()
        {
            foreach (var itemType in itemTypes)
            {
                items.Add(new InventoryItem(itemType));
            }
        }
        public void AddResource(Resource resource)
        {
            var item = ItemExistsInInventory(resource.scriptableResource);
            
            if (item == null) return;
            
            print("added");
            items[item.Index].resource.amount.value += resource.GetAmount();
        }

        private static AddableItem ItemExistsInInventory(ScriptableResource resource)
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

        public static bool CheckRequirement(ScriptableResource req)
        {
            var item = ItemExistsInInventory(req);
            var value = items[item.Index].resource.amount.GetValue();
            return value >= req.reqAmount;
        }

        public static void RemoveResource(ScriptableResource req, int amount)
        {
            var item = ItemExistsInInventory(req);
            var value = items[item.Index].resource.amount.GetValue();
            value -= amount;
            items[item.Index].resource.amount.value = value;
        }
    }
}