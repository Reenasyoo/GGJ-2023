using UnityEngine;

namespace Runtime.Actor
{
    [System.Serializable, CreateAssetMenu(fileName = "ActorSettings", menuName = "Actor/ActorSettings")]
    public class ActorSettings : ScriptableObject
    {
        public float WalkingSpeed = 10f;
        public float RunSpeed = 10f;
        public float JumpHeight = 2f;
    }
}