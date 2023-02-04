using System;
using UnityEngine;

namespace Runtime.Actor.InteractActions
{
    public abstract class InteractionAction : MonoBehaviour, IInteractionAction
    {
        public abstract InteractionType Type { get; }

        private Collider _triggerCollider;

        protected delegate void InteractionCallback();
        protected event InteractionCallback Callback;

        protected virtual void Awake()
        {
            DetectTriggerCollider();
        }

        public void DoInteraction()
        {
            _triggerCollider.enabled = false;
            
            switch (Type)
            {
                case InteractionType.Pickup:
                    Callback?.Invoke();
                    break;
                case InteractionType.Upgrade:
                    Callback?.Invoke();
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