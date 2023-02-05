 using System;
 using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyAttackController : MonoBehaviour
    {
        [SerializeField] private EnemyFacade _facade;
        [SerializeField] private int damageAmount;
        [SerializeField] private float cooldown;

        private float lastAttackedAt = -9999;

        public bool CanAttack { get; set; } = false;

        private void Update()
        {
            if (CanAttack)
            {
                if (Time.time > lastAttackedAt + cooldown) {
                    _facade.ShieldController.TakeDamage(-damageAmount);
                    _facade.AnimationController.TriggerAttack();
                    lastAttackedAt = Time.time;
                }
            }
        }
    }
}