using System;
using Runtime.Resources;
using Systems.GameEvents;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public enum InteractionType
    {
        Pickup,
        Upgrade,
        Interact
    }
    
    public class InteractionAction : MonoBehaviour, IInteractionAction
    {
        [SerializeField] private InteractionType interactionType;
        [SerializeField] private Resource resource;


        public InteractionType Type => interactionType;

        private Collider _triggerCollider;

        private void Awake()
        {
            DetectTriggerCollider();
            resource.scriptableResource.SetResourceAmount(resource.amount);
        }

        public void DoInteraction()
        {
            _triggerCollider.enabled = false;
            
            switch (Type)
            {
                case InteractionType.Pickup:
                    resource.AddResourceToInventory();
                    break;
                case InteractionType.Upgrade:
                    break;
                case InteractionType.Interact:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DetectTriggerCollider()
        {
            foreach (var comp in gameObject.GetComponents<Collider>())
            {
                if (!comp.isTrigger) continue;
                _triggerCollider = comp;
                break;
            }
        }
    }
}