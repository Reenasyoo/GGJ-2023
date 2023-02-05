using System;
using Runtime.Actor.InteractActions;
using Systems.GameEvents;
using UnityEngine;

namespace Runtime.Actor
{
    public class ActorCollisionController : MonoBehaviour
    {
        [SerializeField] private ActorFacade _facade;
        [SerializeField] private InputGameEvent showPopupEvent;
        [SerializeField] private GameEvent disablePopupEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Interactable")) return;
            var interaction = other.GetComponent<IInteractionAction>();
            _facade.ActionController.StartListeningForInput(interaction);
            showPopupEvent.Raise(_facade.ActionController.CurrentActionInput);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Interactable")) return;
            _facade.ActionController.StopListeningForInput();
            disablePopupEvent.Raise();
        }
    }
}