using System;
using System.Linq;
using Systems.ObjectPooling;
using UnityEngine;

namespace Runtime.Buildables.Turret
{
    public class TurretAttackController : MonoBehaviour
    {
        [SerializeField] private GameObject ammunition;
        [SerializeField] private Transform attackFromPoint;

        private ObjectPool<GameObject> _ammoPool;
        private InstantiatedObjects objList = new InstantiatedObjects();

        public float range = 15f;
        public float fireRate = 1f;
        private float fireCountdown = 0;
        private Transform target;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _ammoPool = new ObjectPool<GameObject>(ammunition, 5);
            InstantiatePoolObjects();
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        private void InstantiatePoolObjects()
        {
            foreach (var ammo in _ammoPool.PooledObjects)
            {
                var tmp = Instantiate(ammo.poolable.objectPrefab, transform);
                tmp.SetActive(false);
                var temp = new InstantiadedObject(_ammoPool.PooledObjects.IndexOf(ammo), tmp);
                objList.list.Add(temp);
            }
        }

        private void ActivateBullet()
        {
            var tmp = objList.list.FirstOrDefault();
            _ammoPool.ActivateObject();
            objList.ActivateObject();

            tmp.obj.transform.position = attackFromPoint.position;

            tmp.obj.SetActive(true);


            if (tmp.obj.activeInHierarchy) tmp.obj.GetComponent<TurretBullet>().Seek(target);
            tmp.obj.GetComponent<TurretBullet>().controller = this;
        }

        public void DeactivateBullet()
        {
            var tmp = objList.active.FirstOrDefault();
            _ammoPool.DeactivateObject();
            objList.DeactivateObject();

            tmp.obj.SetActive(false);
        }

        private void Attack()
        {
            ActivateBullet();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Attack();
            }

            if (target == null) return;

            if (fireCountdown <= 0f)
            {
                Attack();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //change later if needed
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            if (enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                //targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
            else
            {
                target = null;
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}