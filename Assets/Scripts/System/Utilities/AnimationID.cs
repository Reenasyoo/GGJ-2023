using UnityEngine;
namespace Systems.Utilities
{
    public static class AnimationID
    {
        public static readonly int FORWARD_VELOCITY = Animator.StringToHash("ForwardVelocity");
        public static readonly int STRAFE_VELOCITY = Animator.StringToHash("StrafeVelocity");
        public static readonly int CHARACTER_ROTATION_Y = Animator.StringToHash("CharacterRotation_Y");
        public static readonly int PICKUP_TRIGGER = Animator.StringToHash("Pickup");
    }
}