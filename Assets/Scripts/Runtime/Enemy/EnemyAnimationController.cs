using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        public Animator anim;
        [SerializeField] private EnemyFacade _facade;
        NavMeshAgent agent;

        private void Start()
        {
            _facade = GetComponent<EnemyFacade>();
            agent = _facade._movementController.navMeshAgent;
        }

        private void Update()
        {
            if (agent.velocity.sqrMagnitude > 0)
            {
                anim.SetBool("Move", true);
            }
            else
            {
                anim.SetBool("Move", false);
                //attac


            }
        }

        public void TriggerAttack()
        {
            anim.SetTrigger("Attack");
        }
    }
}