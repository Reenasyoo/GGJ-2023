using System;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        [SerializeField] private EnemyMovementController _movementController;
        [SerializeField] private EnemyCollisionController _collisionController;
        [SerializeField] private Transform _target;

        [SerializeField] private int Health = 100;
        public Action _callback;

        public EnemyMovementController MovementController => _movementController;
        public EnemyCollisionController CollisionController => _collisionController;

        public Transform Target
        {
            get => _target;
            set => _target = value;
        }

        public void TakeDamage(int damage)
        {
            Health += damage;
            if (Health <= 0)
            {
                _callback();
            }

        }
    }
}