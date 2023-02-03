using System;
using System.Utilities;
using UnityEngine;

namespace Runtime.Actor
{
    
    public enum ActionState
    {
        IDLE = 0,
        WALKING = 1,
        RUNNING = 2,
        SPRINTING = 3,
        BACK_WALKING = 4,
        BACK_RUNNING = 5,
        JOGGING
    }

    public class ActorAnimationController : MonoBehaviour
    {
        [SerializeField] private ActorFacade _facade;
        [SerializeField] private Animator animator = null;
        

        private readonly float[] forwardVelocityAnimationSpeed = new[]
        {
            1f,    // Walking 
            2f,    // Jog
            0.75f,       // Run
            1f,    // Sprint
        };
        
        private readonly float[] strafeVelocityAnimationSpeed = new[]
        {
            0.5f,    // Walking 
            0.75f,    // Running
            1f        // Sprinting
        };
        
        private readonly float[] characterRotationAngles = new[]
        {
            -1f,    // [0] Left 90 turn
            0,        // [1] 0
            1f,     // [2] Right 90 turn
        };

        #region MyRegion
        public void SetState(ActionState state)
        {
            SwitchAnimationState(state);
        }

        private void SwitchAnimationState(ActionState state)
        {
            var forward = 0f;

            switch (state)
            {
                case ActionState.IDLE:
                    break;
                case ActionState.WALKING:
                    forward = forwardVelocityAnimationSpeed[0];
                    break;
                case ActionState.JOGGING:
                    forward = forwardVelocityAnimationSpeed[1];
                    break;
                case ActionState.RUNNING:
                    forward = forwardVelocityAnimationSpeed[2];
                    break;
                case ActionState.SPRINTING:
                    forward = forwardVelocityAnimationSpeed[3];
                    break;
                case ActionState.BACK_WALKING:
                    break;
                case ActionState.BACK_RUNNING:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
            
            SetForwardVelocity(forward);
        }

        private void SetVelocityAnimationSpeed(float forwardSpeed, float strafeSpeed)
        {
            animator.SetFloat(AnimationID.FORWARD_VELOCITY, forwardSpeed, 0.1f, Time.fixedDeltaTime);
            animator.SetFloat(AnimationID.STRAFE_VELOCITY, strafeSpeed, 0.1f, Time.fixedDeltaTime);
        }

        public void ParseValuesToAnimator(float[] values)
        {
            animator.SetFloat(AnimationID.FORWARD_VELOCITY, values[0], 0.1f, Time.fixedDeltaTime);
            animator.SetFloat(AnimationID.STRAFE_VELOCITY, values[1], 0.1f, Time.fixedDeltaTime);
            animator.SetFloat(AnimationID.CHARACTER_ROTATION_Y, values[2], 0.1f, Time.fixedDeltaTime);
        }

        public void SetForwardVelocity(float value)
        {
            animator.SetFloat(AnimationID.FORWARD_VELOCITY, value);
        }

        private void SetStrafeVelocity(float value)
        {
            animator.SetFloat(AnimationID.STRAFE_VELOCITY, value);
        }

        #endregion
    }
}