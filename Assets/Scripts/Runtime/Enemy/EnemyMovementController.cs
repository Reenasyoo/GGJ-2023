using System;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        [SerializeField] public NavMeshAgent navMeshAgent;

        private bool targetInRange = false;

        private void Start()
        {
            SetDestination();
        }

        public void DisableMovement()
        {
            navMeshAgent.isStopped = true;

        }

        public void SetDestination()
        {
            if (_facade.Target != null) navMeshAgent.SetDestination(_facade.Target.position);
            navMeshAgent.isStopped = false;
        }
    }
}