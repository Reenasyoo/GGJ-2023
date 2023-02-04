using Runtime.Resources;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public class PickupAction : InteractionAction
    {
        [SerializeField] private Resource resource;
        
        protected override void Awake()
        {
            base.Awake();
            resource.scriptableResource.SetResourceAmount(resource.amount);
            Callback += resource.AddResourceToInventory;
        }
    }
}