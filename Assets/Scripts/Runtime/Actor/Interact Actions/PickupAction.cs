using Runtime.Resources;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public class PickupAction : InteractionAction
    {
        [SerializeField] private Resource resource;
        
        public override InteractionType Type => InteractionType.Pickup;

        protected override void Awake()
        {
            base.Awake();
            // resource.SetResourceAmount(resource.amount);
            Callback += resource.AddResourceToInventory;
        }
    }
}