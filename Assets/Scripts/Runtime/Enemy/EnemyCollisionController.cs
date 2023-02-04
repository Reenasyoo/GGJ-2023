using System;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyCollisionController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Shield"))
            {
                _facade.MovementController.DisableMovement();
            }
        }
    }
}