using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Runtime.Actor
{
    public class ActorFacade : MonoBehaviour
    {
        public ActorLocomotion Locomotion => _locomotion;
        public ActorCollisionController CollisionController => _collisionController;
        public ActorAnimationController AnimationController => _animationController;
        public ActorActionController ActionController => _actionController;
        
        [SerializeField] private ActorLocomotion _locomotion;
        [SerializeField] private ActorCollisionController _collisionController;
        [SerializeField] private ActorAnimationController _animationController;
        [SerializeField] private ActorActionController _actionController;


    }
}