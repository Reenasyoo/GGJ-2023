using System;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        [SerializeField] private NavMeshAgent navMeshAgent;

        private bool targetInRange = false;

        private void Awake()
        {
            // SetDestination();
        }

        private void Update()
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
            Debug.Log(navMeshAgent.destination);
            navMeshAgent.isStopped = false;
        }
    }
}