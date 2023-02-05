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

        public bool CanMove = true;

        private void Awake()
        {
            _input = GetComponent<IInput>();
            _rigidbodyMovement = new RigidbodyMovement(_input, ref _settings.WalkingSpeed);
        }

        private void FixedUpdate()
        {
            if (CanMove)
                _rigidbody.velocity = _rigidbodyMovement.ReturnFixedVelocity(_rigidbody);
        }

        private void Update()
        {

            if (_rigidbody.velocity != Vector3.zero)
            {
                float heading = Mathf.Atan2(_rigidbody.velocity.x, _rigidbody.velocity.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, heading, 0);
                transform.rotation = rotation;
            }


            if (_rigidbodyMovement.IsMoving && CanMove)
            {
                SetWalking();
            }
            else
            {
                _facade.AnimationController.SetState(ActionState.IDLE);
            }
        }

        private void SetWalking()
        {
            _rigidbodyMovement.SetMoveSpeed(ref _settings.WalkingSpeed);
            _facade.AnimationController.SetState(ActionState.WALKING);
        }
    }
}