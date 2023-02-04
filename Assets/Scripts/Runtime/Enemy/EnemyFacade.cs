using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyFacade : MonoBehaviour
    {
        [SerializeField] private EnemyMovementController _movementController;
        [SerializeField] private EnemyCollisionController _collisionController;
        
        
        [SerializeField] private Transform _target;

        public EnemyMovementController MovementController => _movementController;
        public EnemyCollisionController CollisionController => _collisionController;

        public Transform Target => _target;
    }
}