 using System.Collections.Generic;
using Runtime.Actor.InteractActions;
using UnityEngine;

namespace Runtime.Actor
{
    public class ActorActionController : MonoBehaviour
    {
        [SerializeField] private ActorFacade facade;
        [SerializeField] private List<ActionInput> inputs = new List<ActionInput>();

        #region Properties

        public bool CanListenForInput
        {
            set => _canListenForInput = value;
        }

        #endregion
        
        private ActionInput _currentInteractionType;
        private IInteractionAction _currentInteraction;
        private bool _canListenForInput = false;

        private void Update()
        {
            if (_canListenForInput)
            {
                ListenForActionInput();
            }
        }

        private void ListenForActionInput()
        {
            if (_currentInteractionType != null)
            {
                if (_currentInteractionType.Pressed())
                {
                    print("Pressed");
                    facade.AnimationController.TriggerPickupAnimation();
                    _currentInteraction.DoInteraction();
                    _canListenForInput = false;
                }
            }
        }

        public void StartListeningForInput(IInteractionAction interaction)
        {
            _canListenForInput = true;
            _currentInteractionType = GetInputType(interaction.Type);
            if (_currentInteractionType != null)
            {
                _currentInteraction = interaction;
            }
        }

        public void StopListeningForInput()
        {
            _canListenForInput = false;
        }
        
        private ActionInput GetInputType(InteractionType type)
        {
            foreach (var input in inputs)
            {
                if (type == input.type) return input;
            }

            return null;
        }
    }
}