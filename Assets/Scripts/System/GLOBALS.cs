using UnityEngine;

namespace Systems
{
    public static class GLOBALS
    {
        public const string HorizontalString = "Horizontal";
        public const string VerticalString = "Vertical";
        
        public static readonly Vector3 DownDirection = new Vector3(0, -1, 0);
        public static readonly Vector3 UpDirection = new Vector3(0, 1, 0);
        public static readonly Vector3 ZeroVector = new Vector3(0, 0, 0);

        public static readonly Quaternion ZeroRotation = Quaternion.identity;

        public const float FloatTolerance = 0.000000001f;
        
        public static readonly Vector3 Gravity = Physics.gravity;
        
        
        public static readonly int ForwardVelocity = Animator.StringToHash("ForwardVelocity");
        public static readonly int AttackAnimation = Animator.StringToHash("Attack");
    }
}