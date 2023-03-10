using System;
using Runtime.Gameplay;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        [SerializeField] public EnemyMovementController _movementController;
        [SerializeField] private EnemyCollisionController _collisionController;
        [SerializeField] private EnemyAttackController _attackController;
        [SerializeField] private EnemyAnimationController _animationController;
        [SerializeField] private Transform _target;

        [SerializeField] private int Health = 100;
        public Action _callback;

        public EnemyCollisionController CollisionController => _collisionController;
        public EnemyAttackController AttackController => _attackController;
        public EnemyMovementController MovementController => _movementController;
        public EnemyAnimationController AnimationController => _animationController;
        public ShieldController ShieldController { get; set; }


        public AudioClip hit;
        public AudioSource _audio;

        public Transform Target
        {
            get => _target;
            set => _target = value;
        }

        public void TakeDamage(int damage)
        {
            _audio.clip = hit;
            _audio.Play();
            Health += damage;
            if (Health <= 0)
            {
                _callback();
            }

        }
    }
}