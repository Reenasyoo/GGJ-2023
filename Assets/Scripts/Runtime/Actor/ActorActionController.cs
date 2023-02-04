using System;
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
                print("listening");
                ListenForActionInput();
            }
        }

        private void ListenForActionInput()
        {
            if (_currentInteractionType != null)
            {
                if (_currentInteractionType.Pressed())
                {
                    Debug.Log("Pressed");
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
        
        private ActionInput GetInputType(InteractionType type)
        {
            foreach (var input in inputs)
            {
                if (type == input.type) return input;
            }

            return null;
        }
        
        
        // private void DoAction()
        // {
        //     switch (_currentAction)
        //     {
        //         case InteractionType.Pickup:
        //             Pickup();
        //             break;
        //         case InteractionType.Upgrade:
        //             break;
        //         case InteractionType.Interact:
        //             Interact();
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        private void Attack()
        {
            
        }

        private void Pickup()
        {
            
        }

        private void Interact()
        {
            
        }
    }
}