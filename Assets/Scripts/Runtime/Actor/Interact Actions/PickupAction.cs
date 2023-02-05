using Runtime.Resources;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public class PickupAction : InteractionAction
    {
        [SerializeField] private Resource resource;

        public override InteractionType Type => InteractionType.Pickup;
        public PickupController pickupController;

        protected override void Awake()
        {
            base.Awake();
            Callback += resource.AddResourceToInventory;
        }

        public override void DoInteraction()
        {
            base.DoInteraction();
            pickupController.pickupsActive--;
            pickupController.spawnedPickups.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}