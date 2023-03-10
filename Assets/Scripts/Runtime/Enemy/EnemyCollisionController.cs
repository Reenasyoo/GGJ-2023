using System;
using Runtime.Gameplay;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyCollisionController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Shield"))
            {
                _facade.ShieldController = other.collider.GetComponent<ShieldController>();
                _facade.MovementController.DisableMovement();
                _facade.AttackController.CanAttack = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Shield"))
            {
                _facade.MovementController.DisableMovement();
            }
        }
    }
}