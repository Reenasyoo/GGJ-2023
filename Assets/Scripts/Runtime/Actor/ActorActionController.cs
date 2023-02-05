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

        public ActionInput CurrentActionInput { get; private set; }

        #endregion

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
            if (CurrentActionInput != null)
            {
                if (CurrentActionInput.Pressed())
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
            CurrentActionInput = GetInputType(interaction.Type);
            if (CurrentActionInput != null)
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