﻿using System;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        [SerializeField] private NavMeshAgent navMeshAgent;


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
            navMeshAgent.SetDestination(_facade.Target.position);
            navMeshAgent.isStopped = false;
        }
    }
}