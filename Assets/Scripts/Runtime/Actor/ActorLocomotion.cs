using System;
using Systems.Utilities;
using UnityEngine;

namespace Runtime.Actor
{
    public class ActorLocomotion : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        
        [SerializeField] private ActorFacade _facade;
        [SerializeField] private ActorSettings _settings;        
        
        private IInput _input;
        private RigidbodyMovement _rigidbodyMovement;

        private void Awake()
        {
            _input = GetComponent<IInput>();
            _rigidbodyMovement = new RigidbodyMovement(_input, ref _settings.WalkingSpeed);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _rigidbodyMovement.ReturnFixedVelocity(_rigidbody);
        }

        private void Update()
        {
            if(_rigidbodyMovement.IsMoving)
            {
                SetWalking();
            }
        }
        
        private void SetWalking()
        {
            _rigidbodyMovement.SetMoveSpeed(ref _settings.WalkingSpeed);
            // _facade.AnimationController.SetState(ActionState.WALKING);
        }
    }
}