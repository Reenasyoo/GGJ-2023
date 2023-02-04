using Runtime.Actor.InteractActions;
using UnityEngine;

namespace Runtime.Actor
{
    public class ActorCollisionController : MonoBehaviour
    {
        [SerializeField] private ActorFacade _facade;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Interactable")) return;
            var interaction = other.GetComponent<IInteractionAction>();
            _facade.ActionController.StartListeningForInput(interaction);
        }
    }
}